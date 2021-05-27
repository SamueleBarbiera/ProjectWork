using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettoreDatiPLCtoJSON
{
	public interface IDataBlock
	{
		//PLC to PC
		string CODICE { get; set; }
		string ARTICOLO { get; set; }
		long PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA { get; set; }
		long PEZZI_BUONI { get; set; }
		long PEZZI_SCARTI { get; set; }
		short VELOCITA_MACCHINA_ATTUALE { get; set; }
		long PEZZI_SCARTO_RIUTILIZZABILI { get; set; }
		string AVVISO_PER_UFFICIO_DA_OPERATORE { get; set; }
		long TEMPO_DI_PRODUZIONE { get; set; }
		long TEMPO_DI_PRODUZIONE_MOMENTANEO { get; set; }
		int CONTROLLO { get; set; }
		byte STATO_MACCHINA_DB { get; set; }
	}
}

