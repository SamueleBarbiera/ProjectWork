using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettoreDatiPLCtoJSON
{
	    
	[Serializable]
	public class CDataBlock : IDataBlock
	{
		//variabili
		private string codice;
		private string articolo;
		private long PEZZI_PRODOTTI;
		private long pezzi_b;
		private long pezzi_s;
		private short velocita;
		private long PEZZI_SCARTO;
		private string avvisoUfficio;
		private long temp_pro;
		private long temp_pro_moment;
		private int contr;
		private byte statomacchina;



		//passaggio variabili dalla classe IDataBlock

		public string CODICE
		{ get { return this.codice; } set { this.codice = value; } }

		public string ARTICOLO
		{get { return this.articolo; } set { this.articolo = value; }}

		public long PEZZI_PRODOTTI_PARZIALI_RELATIVI_COMMESSA
		{get { return this.PEZZI_PRODOTTI; } set { this.PEZZI_PRODOTTI = value; }}

		public long PEZZI_BUONI
		{get { return this.pezzi_b; } set { this.pezzi_b = value; }}

		public long PEZZI_SCARTI
		{get { return this.pezzi_s; } set { this.pezzi_s = value; }}

		public short VELOCITA_MACCHINA_ATTUALE
		{get { return this.velocita; } set { this.velocita = value; }}

		public long PEZZI_SCARTO_RIUTILIZZABILI
		{get { return this.PEZZI_SCARTO; } set { this.PEZZI_SCARTO = value; }}

		public string AVVISO_PER_UFFICIO_DA_OPERATORE
		{get { return this.avvisoUfficio; } set { this.avvisoUfficio = value; }}

		public long TEMPO_DI_PRODUZIONE
		{ get { return this.temp_pro; } set { this.temp_pro = value; } }

		public long TEMPO_DI_PRODUZIONE_MOMENTANEO
		{ get { return this.temp_pro_moment; } set { this.temp_pro_moment = value; } }

		public int CONTROLLO 
		{ get { return this.contr; } set { this.contr = value; } }

		public byte STATO_MACCHINA_DB
		{ get { return this.statomacchina; } set { this.statomacchina = value; } }
	}
}

