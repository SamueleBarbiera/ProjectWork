using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettoreDatiPLCtoJSON
{
    class OggettoInvio
	{
		public DateTime DATAATTUALE { get; set; }
		public DateTime DATACONSEGNA { get; set; }
		public string CODICE { get; set; }
		public string ARTICOLO { get; set; }
		public long PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA { get; set; }
		public long PEZZI_BUONI { get; set; }
		public long PEZZI_SCARTI { get; set; }
		public short VELOCITA_MACCHINA_ATTUALE { get; set; }
		public long PEZZI_SCARTO_RIUTILIZZABILI { get; set; }
		public string AVVISO_PER_UFFICIO_DA_OPERATORE { get; set; }
		public long TEMPO_DI_PRODUZIONE { get; set; }
		public long TEMPO_DI_PRODUZIONE_MOMENTANEO { get; set; }
		public long PEZZI_TOTALI { get; set; }
		public string STATOPROD { get; set; }
		public string STATOMACCHINA { get; set; }
		public bool MANUALE { get; set; }



	}
}
