using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFFICIO
{


	public interface IDataBlock
	{
		//PC to PLC
		string DBname { get; set; }
		string CODICE { get; set; }
		string ARTICOLO { get; set; }

		byte UFFICIO_OPERATORE{ get; set; }

		UInt32 PEZZI_DA_PRODURRE { get; set; }

		string AVVISO_DA_UFFICIO_PER_OPERATORE { get; set; }
		short CONTROLLO { get; set; }
		UInt16 DELAY_UFFICIO { get; set; }
		int POSSIBILI_GUASTI_SIMULATI { get; set; }
		
		
		}

	
}
