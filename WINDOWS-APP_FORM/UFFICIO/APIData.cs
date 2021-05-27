using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFFICIO
{
    public class APIData
    {
      
            public string DATAATTUALE { get; set; }
            public string DATACONSEGNA { get; set; }
            public string CODICE { get; set; }
            public string ARTICOLO { get; set; }
            public int PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA { get; set; }
            public int PEZZI_BUONI { get; set; }
            public int PEZZI_SCARTI { get; set; }
            public int PEZZI_SCARTO_RIUTILIZZABILI { get; set; }
            public string AVVISO_PER_UFFICIO_DA_OPERATORE { get; set; }
            public int TEMPO_DI_PRODUZIONE { get; set; }
            public int TEMPO_DI_PRODUZIONE_MOMENTANEO { get; set; }
            public int VELOCITA_MACCHINA_ATTUALE { get; set; }
            public int PEZZI_TOTALI { get; set; }
            public string STATOPROD { get; set; }
            public string STATOMACCHINA { get; set; }
            public bool MANUALE { get; set; }
        
    }
}
