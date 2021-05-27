using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp7;

namespace UFFICIO
{
    public partial class FormMAIN : Form
    {
        public FormMAIN()
        {
            InitializeComponent();
		
			AggiornaInterfaccia();
			


		}

		private void btnCrea_Click(object sender, EventArgs e)
        {
			//Apro la form di creazione di una nuova commessa
            var myForm = new FormCREA();
            myForm.ShowDialog();
			AggiornaInterfaccia();
			

		}

        private void btnTEST_Click(object sender, EventArgs e)
        {
			//Apro la form di modifica della commessa in esecuzione
			var myForm = new FormMOD();
            myForm.ShowDialog();
            AggiornaInterfaccia();
		}

        private void btnStorico_Click(object sender, EventArgs e)
        {
			//Apro la form di storico  delle commesse eseguite o errrate
			var myForm = new FormVISUAL();
            myForm.ShowDialog();
			AggiornaInterfaccia();
		}

		private void AggiornaInterfaccia()
		{

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Id Commessa"));
			dt.Columns.Add(new DataColumn("Codice Commessa"));
			dt.Columns.Add(new DataColumn("Stato"));
			dt.Columns.Add(new DataColumn("Nome Articolo"));
			dt.Columns.Add(new DataColumn("Pezzi Da Produrre"));
			List<Storico> lista = DB.GetCommesseInattive();
			foreach (Storico tmpLista in lista)
			{
				dt.Rows.Add(tmpLista.C.idCommessa, tmpLista.C.codice, tmpLista.C.stato, tmpLista.A.nome, tmpLista.C.numeroPezzi);
				
				Console.WriteLine(tmpLista.stampatutto());
			}
			dataGridView1.DataSource = dt;


			List<Storico> listain = DB.GetCommesseInattive();
			if (listain.Count > 0)
			{
				btnAddAttiva.Enabled = true;
			}
			else
			{
				btnAddAttiva.Enabled = false;
			}
			DataTable dt2 = new DataTable();

			Storico commnotarr = DB.GetCommessaCommessaNonArresto();
			if (commnotarr.C.codice !=null)
			{
				
				dt2.Columns.Add(new DataColumn("Id Commessa"));
				dt2.Columns.Add(new DataColumn("Codice Commessa"));
				dt2.Columns.Add(new DataColumn("Stato Commessa"));
				dt2.Columns.Add(new DataColumn("Stato Macchina"));
				dt2.Columns.Add(new DataColumn("Nome Articolo"));
				dt2.Columns.Add(new DataColumn("Pezzi Da Produrre"));
				dataGridView2.Visible = true;
				label1.Visible = true;
				btnAddAttiva.Enabled = false;
				dt2.Rows.Add(commnotarr.C.idCommessa, commnotarr.C.codice, commnotarr.C.stato, commnotarr.C.statoMacchina, commnotarr.A.nome, commnotarr.C.numeroPezzi);
				dataGridView2.DataSource = dt2;
				dataGridView2.Visible = true;
				label1.Visible = true;
				BtnResetta.Visible = true;
			}
            else
            {
				
				Storico commattiva = DB.GetCommessaAttiva();
				if (commattiva != null)
				{
					dt2.Columns.Add(new DataColumn("Id Commessa"));
					dt2.Columns.Add(new DataColumn("Codice Commessa"));
					dt2.Columns.Add(new DataColumn("Stato Commessa"));
					dt2.Columns.Add(new DataColumn("Stato Macchina"));
					dt2.Columns.Add(new DataColumn("Nome Articolo"));
					dt2.Columns.Add(new DataColumn("Pezzi Da Produrre"));
					btnAddAttiva.Enabled = true;
					dataGridView2.Visible = true;
					label1.Visible = true;
					dt2.Rows.Add(commattiva.C.idCommessa, commattiva.C.codice, commattiva.C.stato, commattiva.C.statoMacchina, commattiva.A.nome, commattiva.C.numeroPezzi);
					dataGridView2.DataSource = dt2;
					
				}
                else
                {
					dataGridView2.Visible = false;
					label1.Visible = false;
					BtnResetta.Visible = false;

				}
				
			}
			
			

			
			
			
			







			
			List<Storico> listastor = DB.GetCommesseFinite();
			if (listastor.Count>0)
            {
				btnStorico.Enabled = true;
			}
			else
            {
				btnStorico.Enabled = false;
			}
			dataGridView2.DataSource = dt2;
			Storico storicos = DB.GetCommessaAttiva();
			if (storicos.C.codice == null|| commnotarr==null)
			{
				btnAggiungiCommessa.Enabled = true;
				BtnResetta.Enabled = false;
				dataGridView2.DataSource = new DataTable();
				btnAddAttiva.Enabled = false;
				btnInfoCommessa.Enabled = false;
				btnTEST.Enabled = false;
			}
			else
			{
				BtnResetta.Enabled = true;
				btnAggiungiCommessa.Enabled = false;
				btnAddAttiva.Enabled = true;
				btnInfoCommessa.Enabled = true;
				btnTEST.Enabled = true;
			}


		






			string mess = Lettura_dati_plc.LeggiDati();

			lblMessaggioOperatore.Text= mess;


		}

        private void btnInfoCommessa_Click(object sender, EventArgs e)
        {
			Lettura_dati_plc.LeggiDati();

			//tramite un messagebox mostro all'utente le informazioni della commessa in produzione 
			Storico Attiva = DB.GetCommessaAttiva();
			MessageBox.Show(Attiva.InfoComm(),"info specifiche della commessa",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnAddAttiva_Click(object sender, EventArgs e)
        {
			
			
			Storico c = DB.GetCommessaAttiva();
			string messxoper = txtMessaggioOperatore.Text;
			Scrittura_PC_PLC.Connettere();
			int x = Scrittura_PC_PLC.ScriviSuPLC(c,messxoper);
			if(x==0)
            {
				DB.UpdateStato(c.C.idCommessa, "Attiva", "Macchina in START");
			}
            else
            {
				MessageBox.Show("Non connesso al plc", "info specifiche della commessa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
			btnAddAttiva.Enabled = false;
			AggiornaInterfaccia();


		}

        private void FormMAIN_Load(object sender, EventArgs e)
        {

        }

        private void btnAggiungiCommessa_Click(object sender, EventArgs e)
        {
			List<Storico> listastor = DB.GetCommesseInattive();
			if (listastor.Count > 0)
			{

				string dato = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
				int idcommessa = Convert.ToInt32(dato);
				DB.UpdateStato(idcommessa, "Attiva", "Arresto");
			}
			AggiornaInterfaccia();

		}

        private void BtnResetta_Click(object sender, EventArgs e)
        {
			DB.ResetCommesse();
			AggiornaInterfaccia();
        }
    }
}
