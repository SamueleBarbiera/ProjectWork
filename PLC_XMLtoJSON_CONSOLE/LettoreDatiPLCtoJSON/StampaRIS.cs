using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Configuration;
using System.Timers;
using Newtonsoft.Json;

namespace LettoreDatiPLCtoJSON
{
    static class StampaRIS
    {
		//Creo oggetto Client per connettermi o disconnetermi
		static public S7Client Client = new S7Client();
		//Creo oggetto per lettura db3
		static public CDataBlock db3 = new CDataBlock();
		//Creo oggetto che uso come base per la stringa JSON
		static public OggettoInvio json = new OggettoInvio();
		//Variabile che uso per controllare lo stato delle connessioni e delle operazioni sul PLC
		static private int result;

		//Buffer pe la gestione dei DB del PLC
		#region "Buffer"
		static private byte[] db3Buffer = new byte[235];
		static private byte[] data = new byte[224];
		static private byte[] ControlloBuffer1 = new byte[2];
		static private byte[] ControlloBuffer2 = new byte[2];
        #endregion

		//Funzione per connettermi al PLC
		static public string Connettere(){
			string testo = ("Connessione al PLC: ");
			testo += "@";
			try
			{
				//Passo parametri connsessione la PLC tramite file APP.config
				string IP = ConfigurationManager.AppSettings["ip_address_PLC"];
				int Rack = int.Parse(ConfigurationManager.AppSettings["rack"]);
				int Slot = int.Parse(ConfigurationManager.AppSettings["slot"]);
				//Funzione per connettermi al PLC
				int Result = Client.ConnectTo(IP, Rack, Slot);

				if (Result == 0)
				{
					testo += ("SUCCESSO@");
				}
				else
				{
					testo += ("FALLITO@");
				}
			}
			catch (Exception ex)
			{
				testo += "@";
				result = -1;
				testo += ("ERRORE:" + ex.Message);
			}
			return testo;
		}

		//Funzione per disconnettremi al PLC
		static public void Disconnettere()
        {
			Client.Disconnect();
		}

		static public string LeggiDati(){
			string testo = ("Connessione al Database PLC: ");
			try
			{
				//connessione al database (nome, Non so, dimensione in byte , buffer di cio che ho letto)
				result = Client.DBRead(3, 0, 235, db3Buffer);
				testo += "@";

				if (result == 0)
                {
					//Qui leggo dal PLC il db3 e setto le variabili sull'oggetto
					db3.CODICE = S7.GetStringAt(db3Buffer, 0);
					db3.ARTICOLO = S7.GetStringAt(db3Buffer, 52);
					db3.CONTROLLO = S7.GetIntAt(db3Buffer, 104);
					db3.TEMPO_DI_PRODUZIONE = S7.GetDIntAt(db3Buffer, 106);
					db3.PEZZI_BUONI = S7.GetUDIntAt(db3Buffer, 110);
					db3.TEMPO_DI_PRODUZIONE_MOMENTANEO = S7.GetDIntAt(db3Buffer, 114);
					db3.PEZZI_SCARTI = S7.GetUDIntAt(db3Buffer, 118);
					db3.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA = S7.GetUDIntAt(db3Buffer, 122);
					db3.VELOCITA_MACCHINA_ATTUALE = S7.GetIntAt(db3Buffer, 126);
					db3.PEZZI_SCARTO_RIUTILIZZABILI = S7.GetUDIntAt(db3Buffer, 128);
					db3.AVVISO_PER_UFFICIO_DA_OPERATORE = S7.GetStringAt(db3Buffer, 132);
					db3.STATO_MACCHINA_DB = S7.GetByteAt(db3Buffer, 234);

					result = Client.DBRead(2, 0, 224, data);
					

					if (result == 0)
					{
						//Passo stringa di successo solo se entrambe le connessioni sono andate a buon fine
						testo += ("SUCCESSO@");

						//Qui leggo dal PLC il db2 e setto le variabili sull'oggetto
						json.PEZZI_TOTALI = S7.GetUDIntAt(data, 106);
						json.DATACONSEGNA = S7.GetDateAt(data, 222);

						json.DATAATTUALE = DateTime.UtcNow;
						json.CODICE = db3.CODICE;
						json.ARTICOLO = db3.ARTICOLO;
						json.TEMPO_DI_PRODUZIONE = db3.TEMPO_DI_PRODUZIONE;
						json.PEZZI_BUONI = db3.PEZZI_BUONI;
						json.TEMPO_DI_PRODUZIONE_MOMENTANEO = db3.TEMPO_DI_PRODUZIONE_MOMENTANEO;
						json.PEZZI_SCARTI = db3.PEZZI_SCARTI;
						json.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA = db3.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA;
						json.VELOCITA_MACCHINA_ATTUALE = db3.VELOCITA_MACCHINA_ATTUALE;
						json.PEZZI_SCARTO_RIUTILIZZABILI = db3.PEZZI_SCARTO_RIUTILIZZABILI;
						json.AVVISO_PER_UFFICIO_DA_OPERATORE = db3.AVVISO_PER_UFFICIO_DA_OPERATORE;

						//Controllo lo stato della macchina basandomi su un numero passato dal PLC
						switch (db3.STATO_MACCHINA_DB)
						{
							case 0:
								//Macchina in START
								json.STATOMACCHINA = "Macchina in START";
								json.MANUALE = false;
								break;
							case 1:
								//Macchina in STOP
								json.STATOMACCHINA = "Macchina in STOP";
								json.MANUALE = false;
								break;
							case 2:
								//Macchina in manuale
								json.STATOMACCHINA = "";
								json.MANUALE = true;
								break;
							case 3:
								//Macchina in emergenza
								json.STATOMACCHINA = "Macchina in emergenza";
								json.MANUALE = false;
								break;
							case 4:
								//Allarmi in atto
								json.STATOMACCHINA = "Allarmi in atto";
								json.MANUALE = false;
								break;
							case 5:
								//Macchina in manutenzione
								json.STATOMACCHINA = "Macchina in manutenzione";
								json.MANUALE = false;
								break;
							case 6:
								//Macchina preinpostata per lo start automatico
								json.STATOMACCHINA = "Macchina preinpostata per lo start automatico";
								json.MANUALE = false;
								break;
							default:
								break;
						}

						//Controllo se lo stato della commessa è ancora attivo o meno
						if (json.PEZZI_TOTALI < json.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA - json.PEZZI_SCARTI)
						{
							json.STATOPROD = "Attiva";
						}
						else
						{
							json.STATOPROD = "Inattiva";
						}

						testo += "|@";

						//Converto l'oggetto db3 in una stringa JSON
						string stringjson = JsonConvert.SerializeObject(json);

						//Funzione per la stampa del log su file JSON
						SaveToDB.StoreDB(json.CODICE, stringjson);

						//Invio la stringa alla funzione responsabile all'invio dei dati all'API
						//testo += (POSTAPI.POSTData(stringjson));
					}
					else
					{
						testo += ("FALLITO@");
					}
				}
				else
                {
					testo += ("FALLITO@");
				}
			}
			catch (Exception ex)
			{
				testo += "@|@";
				result = -1;
				testo += ("ERRORE@:" + ex.Message);
			}
			return testo;
		}

		static public string Controllo()
		{
			string testo = ("Lettura del WatchDog: ");
			try
			{
				//connessione al database (nome, byte dalla quale parto a leggere, dimensione in byte, buffer di cio che ho letto)
				Int16 CONTROLLO = 3;
				int risultato1 = Client.DBRead(31, 0, 2, ControlloBuffer1);
				testo += "@";

				//controllo il risultato se 0 sucesso altrimenti fallito
				if (risultato1 == 0)
                {
					testo += ("SUCCESSO@");
					CONTROLLO = S7.GetIntAt(ControlloBuffer1, 0);

					testo += "|@";

					//controllo la variabile controllo se 2 entro nel ciclo altrimenti uol dire che il PLC non ha ancora cambiato la variabile
					if (CONTROLLO == 2)
					{
						CONTROLLO = 1;
						S7.SetIntAt(ControlloBuffer2, 0, CONTROLLO);
						int risultato2 = Client.DBWrite(31, 0, ControlloBuffer2.Length, ControlloBuffer2);

						testo += ("Scrittura del WatchDog: ");
						testo += "@";

						//Se il risultato è 0 vuol dire che si è connsesso
						if (risultato2 == 0)
						{
							testo += ("SUCCESSO@");
						}
						else
						{
							testo += ("FALLITO@");
						}
					}
				}
                else{
					testo += ("FALLITO@");
				}
				
			}
			catch (Exception ex)
			{
				testo += "@|@";
				result = -1;
				testo += ("ERRORE@: " + ex.Message);
			}
			return testo;
		}
	}
}
