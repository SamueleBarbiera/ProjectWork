using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Configuration;
namespace UFFICIO
{
    class Scrittura_PC_PLC
    {
		static public S7Client Client = new S7Client();
		static private int result;
		static public int Connettere()
		{
			int cont = 0;
			try
			{
				string IP = ConfigurationManager.AppSettings["ip_address_PLC"];
				int Rack = Convert.ToInt32(ConfigurationManager.AppSettings["rack"]);
				int Slot = Convert.ToInt32(ConfigurationManager.AppSettings["slot"]);
				result = Client.ConnectTo(IP, Rack, Slot);
				Console.WriteLine("Status conessione: " + result);
				cont = result;
			}
			catch (Exception ex)
			{
				result = -1;
				Console.WriteLine("ERROR:" + ex.Message);
			}
			return cont;
		}


		static public int ScriviSuPLC(Storico pcDati, string erroreUfficio)
		{
			 CDataBlock dbScrittura = new CDataBlock();
			int con=Connettere();
			byte[] bufferDatiComm = new byte[224];
			byte[] bufferSetDatiDB3 = new byte[4];
			byte[] bufferSetDatiStringhe= new byte[104];
			UInt32 cestinoLavico = 20;
			
			try
			{

				//aggiungi data consegna e lettura db locale
				dbScrittura.DBname = "PC_PLC";
				dbScrittura.CODICE = pcDati.C.codice;
				dbScrittura.ARTICOLO = pcDati.A.nome;
				dbScrittura.UFFICIO_OPERATORE = 0;
				dbScrittura.PEZZI_DA_PRODURRE = pcDati.C.numeroPezzi;
				dbScrittura.AVVISO_DA_UFFICIO_PER_OPERATORE = erroreUfficio;
				dbScrittura.CONTROLLO = 1;
				dbScrittura.DELAY_UFFICIO = pcDati.P.ritardoEsecuzione;
				dbScrittura.POSSIBILI_GUASTI_SIMULATI = 0;
				
				S7.SetStringAt(bufferDatiComm, 0, 50, dbScrittura.CODICE);
				S7.SetStringAt(bufferDatiComm, 52 , 50, dbScrittura.ARTICOLO);
				S7.SetByteAt(bufferDatiComm, 104, dbScrittura.UFFICIO_OPERATORE);
				S7.SetUDIntAt(bufferDatiComm, 106,dbScrittura.PEZZI_DA_PRODURRE);
				S7.SetStringAt(bufferDatiComm, 110, 100, dbScrittura.AVVISO_DA_UFFICIO_PER_OPERATORE);
				S7.SetIntAt(bufferDatiComm, 212, dbScrittura.CONTROLLO);
				S7.SetDIntAt(bufferDatiComm, 214, dbScrittura.DELAY_UFFICIO);
				S7.SetIntAt(bufferDatiComm, 218, Convert.ToInt16(dbScrittura.POSSIBILI_GUASTI_SIMULATI));

				S7.SetBitAt(ref bufferDatiComm, 220, 0, true);
				S7.SetDateAt(bufferDatiComm, 222, pcDati.C.dataconsegna);




				result =Client.DBWrite(2, 0, 224, bufferDatiComm);
				
				Console.WriteLine("invio a db2 dati di scrittura " + result);


				//reset bit per carico del cestino e reset  
				S7.SetUDIntAt(bufferSetDatiDB3, 0, cestinoLavico);

				result = Client.DBWrite(1, 2, 4, bufferSetDatiDB3);
				Console.WriteLine("hai funzionato? " + result);


				//scrittura su di cliente e codice commessa per l'api
				S7.SetStringAt(bufferSetDatiStringhe, 0, 50, dbScrittura.CODICE);
				S7.SetStringAt(bufferSetDatiStringhe, 52, 50, dbScrittura.ARTICOLO);
				result = Client.DBWrite(3, 0, 104, bufferSetDatiStringhe);


				Console.WriteLine("invio a db3 dati di codice e Cliente " + result);
			}
			catch (Exception ex)
			{
				result = -1;
				Console.WriteLine("ERRORE scrittura: " + ex.Message);
			}
			return result;

		}

		static public void ModificaVelocitàPLC(UInt16 vel)
		{
			CDataBlock dbScrittura = new CDataBlock();
			Connettere();
			byte[] bufferDatiComm = new byte[10];

			try
			{
				
				S7.SetDIntAt(bufferDatiComm, 0, vel);
				

				result = Client.DBWrite(2, 214, 4, bufferDatiComm);

				Console.WriteLine("invio a db2 dati di scrittura " + result);
			}
			catch (Exception ex)
			{
				result = -1;
				Console.WriteLine("ERRORE scrittura: " + ex.Message);
			}

		}
		static public void ModificaEliminaMessaggioOperatore()
		{
			CDataBlock dbScrittura = new CDataBlock();
			Connettere();
			byte[] bufferDatiComm = new byte[100];

			try
			{

				S7.SetStringAt(bufferDatiComm, 0,100, "");


				result = Client.DBWrite(3, 132, 100, bufferDatiComm);

				Console.WriteLine("invio a db3 dati di scrittura " + result);
			}
			catch (Exception ex)
			{
				result = -1;
				Console.WriteLine("ERRORE scrittura: " + ex.Message);
			}

		}
		static public void ModificaErrore(int POSSIBILI_GUASTI_SIMULATI)
		{
			CDataBlock dbScrittura = new CDataBlock();
			Connettere();
			byte[] bufferDatiComm = new byte[4];

			try
			{


				byte x = Convert.ToByte(POSSIBILI_GUASTI_SIMULATI);
				

				S7.SetByteAt(bufferDatiComm, 0, x);
				result = Client.DBWrite(2, 104, 2, bufferDatiComm);

				Console.WriteLine("invio a db3 dati di scrittura " + result);
			}
			catch (Exception ex)
			{
				result = -1;
				Console.WriteLine("ERRORE scrittura: " + ex.Message);
			}

		}
	}

}
