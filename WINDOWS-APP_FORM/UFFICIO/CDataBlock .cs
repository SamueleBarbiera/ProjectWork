using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFFICIO
{
	public class CDataBlock : IDataBlock
	{
		//variabili
		private string dbName;
		private string codice;
		private string articolo;
		private UInt32 pezzi_da_produrre;
		private UInt16 delay_ufficio;
		private int possibili_guasti_simulati;
		private string avviso_per_operatore_da_ufficio;
		private short contr;
		private byte ufficio_operatore;

		//passaggio variabili dalla classe IDataBlock
		public string DBname
		{ get { return this.dbName; } set { this.dbName = value; } }

		public string CODICE
		{ get { return this.codice; } set { this.codice = value; } }

		public string ARTICOLO
		{ get { return this.articolo; } set { this.articolo = value; } }

		public UInt32 PEZZI_DA_PRODURRE
		{ get { return this.pezzi_da_produrre; } set { this.pezzi_da_produrre = value; } }

		public UInt16 DELAY_UFFICIO
		{ get { return this.delay_ufficio; } set { this.delay_ufficio = value; } }

		public int POSSIBILI_GUASTI_SIMULATI
		{ get { return this.possibili_guasti_simulati; } set { this.possibili_guasti_simulati = value; } }

		public string AVVISO_DA_UFFICIO_PER_OPERATORE
		{ get { return this.avviso_per_operatore_da_ufficio; } set { this.avviso_per_operatore_da_ufficio = value; } }

		public short CONTROLLO
		{ get { return this.contr; } set { this.contr = value; } }

		public byte UFFICIO_OPERATORE
			{ get { return this.ufficio_operatore; } set { this.ufficio_operatore = value; } }

	}

    
    
}
