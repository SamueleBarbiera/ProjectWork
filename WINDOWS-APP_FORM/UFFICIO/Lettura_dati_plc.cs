using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
//libreria che i permette di fare richieste in rete
using System.Net;
using System.IO;
using System.Configuration;

namespace UFFICIO
{
    class Lettura_dati_plc
    {

		
		static public string LeggiDati()
		{

			string indirizzoCloud = ConfigurationManager.AppSettings["ip_address_PLC"];
			string portaCloud = ConfigurationManager.AppSettings["port_API"];
			//qui va inserito l'indirizzo del API
			/*
			string MyURL = "http://"+ indirizzoCloud + ":"+ portaCloud + "/api/status";*/
			string MyURL = "http://50.19.147.177:3000/api/status";
			string messaggio_operatore = "Errore connesione ad API";
			WebRequest request = WebRequest.Create(MyURL);
            try
            {

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string responseFromServer = reader.ReadToEnd();

				reader.Close();
				dataStream.Close();
				response.Close();

				//CONVERSIONE JSON TO CLASS
				APIData wd = new APIData();
				wd = Newtonsoft.Json.JsonConvert.DeserializeObject<APIData>(responseFromServer);
				string codiceComm = wd.CODICE;
				int id = DB.GetIndexCommessa(codiceComm,wd.DATACONSEGNA);
				Storico Stor = DB.GetCommessa(id);
				UInt32 PEZZI_SCARTI = Convert.ToUInt32(wd.PEZZI_SCARTI);
				UInt32 totpezziprod = Convert.ToUInt32(wd.PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA);
				DateTime DataAtt = DateTime.UtcNow;
				string statom = wd.STATOMACCHINA;
				
				DB.UpdateStato(id, wd.STATOPROD, wd.STATOMACCHINA);
				DB.UpdateData(id, DataAtt);
				DB.UpdatePezzi(id, totpezziprod, PEZZI_SCARTI);
				int dealay = wd.VELOCITA_MACCHINA_ATTUALE;
				DB.UpdateSpeed(id, dealay);
				messaggio_operatore = wd.AVVISO_PER_UFFICIO_DA_OPERATORE;
			}
			catch(Exception ex)
            {
				Console.WriteLine("ERRORE scrittura: " + ex.Message);
			}
			return messaggio_operatore;


			

		}
	}
}
