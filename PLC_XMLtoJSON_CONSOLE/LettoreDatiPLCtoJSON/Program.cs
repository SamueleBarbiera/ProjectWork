using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Configuration;
using System.Timers;
using System.Threading;

namespace LettoreDatiPLCtoJSON
{
	public class Program
	{
		
		//Semaforo per la mutua escusione
		static private Mutex mut = new Mutex();

		#region "Stringhe utilizzate spesso"
		static public string leggiLog = "";
		static public string controllo = "";
		static public string separatore =	"##############################################################################################";
		static public string leggiplc =		"#################################### Lettura del database ####################################";
		static public string watchdog =		"#################################### Gestione del WATCHDOG ###################################";
		static public string esc = "Press ESC to stop";
		#endregion

		static void Main(string[] args)
		{
			//Creazione e istanza dei timer
			//Timer per l'aggiornamento dell'interfaccia
			System.Timers.Timer timerInterfaccia = new System.Timers.Timer();
			//Timer per la lettura del DB del PLC
			System.Timers.Timer timerLOG = new System.Timers.Timer();
			//Timer per la gestione del WATCHDOG
			System.Timers.Timer timerControllo = new System.Timers.Timer();

			Console.Title = "Lettore dati PLC";
			Console.WriteLine("Connessione al PLC...");
			


			//Chiamo la funzione di conessione
			bool valore = StampaDati(StampaRIS.Connettere());
			Console.WriteLine();
			
			//se valore true la connessione è stabilita e continuo altrimenti blocco il progamma
			if (!valore)
            {
            }
            else
            {
				//attivo e setto i parametri timer per il pooling di richiesta al PLC dei dati processati 

				timerLOG.Elapsed += OnTimerEventLog;
				timerLOG.Interval = 2000;
				timerLOG.Enabled = true;
				Console.WriteLine("Pooling LOG partito");

				
				timerControllo.Elapsed += OnTimerEventControllo;
				timerControllo.Interval = 1000;
				timerControllo.Enabled = true;
				Console.WriteLine("Pooling WATCHDOG partito");

				
				timerControllo.Elapsed += OnTimerEventInterfaccia;
				timerControllo.Interval = 1000;
				timerControllo.Enabled = true;
			}

			StampaSeparatore(separatore);
			StampaEsc(esc);

			//La console rimane attiva fino a che non sono viene chiusa o non viene premuto il tato esc
			do
			{

			}
			while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
			{
				//Blocco i timer e mi disconnetto dal PLC
				timerLOG.Stop();
				timerControllo.Stop();
				timerInterfaccia.Stop();
				StampaRIS.Disconnettere();
			}
		}

        #region "Funzioni dei timer"
        
		//Funzione del timer per aggiornare l'interfaccia
		static public void OnTimerEventInterfaccia(object source, System.Timers.ElapsedEventArgs e)
		{
			Console.Clear();
			Console.WriteLine();

			StampaSeparatore(leggiplc);
			StampaDati(leggiLog);
			
			Console.WriteLine();
			StampaSeparatore(separatore);
			

			Console.WriteLine();
			StampaSeparatore(watchdog);
			StampaDati(controllo);
			
			Console.WriteLine();
			StampaSeparatore(separatore);

			StampaEsc(esc);
		}

		static public void OnTimerEventLog(object source, System.Timers.ElapsedEventArgs e)
		{
			leggiLog = "";
			mut.WaitOne();
			//Chiamo la funzione che gestisce i dati letti dal PLC
			leggiLog = StampaRIS.LeggiDati();
			mut.ReleaseMutex();
		}

		static public void OnTimerEventControllo(object source, System.Timers.ElapsedEventArgs e)
		{
			
			//chiamo la funzione che gestisce il watchdog
			mut.WaitOne();
			controllo = "";
			controllo = StampaRIS.Controllo();
			mut.ReleaseMutex();
		}
        #endregion

        #region "Funzioni per la stampa su console"
        static public bool StampaDati(string stringa)
        {
			bool risultato = false;
			string[] arrayStringa = stringa.Split("@".ToCharArray());

			foreach (var testo in arrayStringa)
			{
				if (testo.Equals("|"))
				{
					Console.WriteLine();
				}
				else
				{
					if (testo.Equals("FALLITO"))
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.Red;
						risultato = false;
					}
					else if (testo.Equals("SUCCESSO"))
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.Green;
						risultato = true;
					}
					else if (testo.Equals("ERRORE"))
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						risultato = false;
					}
					else
					{
						Console.ResetColor();
					}
					Console.Write(testo);
				}
			}

			Array.Clear(arrayStringa, 0, arrayStringa.Length);

			return risultato;
		}

		static public void StampaSeparatore(string testo)
        {
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(testo);
			Console.ResetColor();
		}

		static public void StampaEsc(string testo)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(testo);
			Console.ResetColor();
        }
        #endregion
    }
}
