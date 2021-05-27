using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UFFICIO
{
    public partial class FormVISUAL : Form
    {
        public FormVISUAL()
        {
            InitializeComponent();
			AggiornaInterfaccia();

		}



		private void AggiornaInterfaccia()
		{

			//popolo la DataGriedView Con i dati delle commesse in attesa di esecuzione
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Id Commessa"));
			dt.Columns.Add(new DataColumn("Codice Commessa"));
			dt.Columns.Add(new DataColumn("Stato"));
			dt.Columns.Add(new DataColumn("Nome Articolo"));
			dt.Columns.Add(new DataColumn("Pezzi Da Produrre"));
			List<Storico> lista = DB.GetCommesseFinite();
			foreach (Storico tmpLista in lista)
			{
				dt.Rows.Add(tmpLista.C.idCommessa,tmpLista.C.codice, tmpLista.C.stato, tmpLista.A.nome, tmpLista.C.numeroPezzi);
				//dt.Rows.Add("ciao", "come", "va","aaaa","onnnoooo");
				Console.WriteLine(tmpLista.stampatutto());
			}

			//dt.Rows.Add("ciao", "come", "va", "aaaa", "onnnoooo");
			/*Console.WriteLine(dt.Rows.Count);
			dataGridView1.AutoGenerateColumns = true;
			DataSet ds = new DataSet();
			ds.Tables.Add(dt);*/
			dataGridView1.DataSource = dt;








			
		}

      
    }
}
