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
    public partial class FormCREA : Form
    {
        Commessa nomecommessa = new Commessa();
        Produzione produzione = new Produzione();

        public FormCREA()
        {
            InitializeComponent();
            AggiornaInterfaccia();

        }

        private void FormCREA_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            



            nomecommessa.codice = textBox2.Text;

            int id = ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;
            nomecommessa.articolo = id;
            nomecommessa.stato = "Inattiva";
            nomecommessa.numeroPezzi = Convert.ToUInt32(numericUpDown2.Value);
            nomecommessa.dataconsegna = dateTimePicker1.Value;
            nomecommessa.statoMacchina = "arresto";
            DB.InsertCommessa(nomecommessa);
            
            produzione.ritardoEsecuzione = Convert.ToUInt16(numericUpDown1.Value*1000);
            List<Commessa> ListaComm = DB.GetCommesse();
            
            int x= ListaComm[ListaComm.Count-1].idCommessa;
            produzione.idCommessaProd =x;
            produzione.pezziProdotti = 0;
            produzione.pezziScartati = 0;
            DB.InsertProduzione(produzione);
            AggiornaInterfaccia();
        }

       
        private void AggiornaInterfaccia()
        {
         

            if(textBox2.Text!="")
            {
                textBox2.Text = "";
            }
            Dictionary<int, string> comboArticoli = new Dictionary<int, string>();

            foreach (Articolo C in DB.GetArticoli())
            {
                comboArticoli.Add(C.idArticolo, C.nome);
            }
            if (comboArticoli.Count() > 0)
            {
                comboBox2.DataSource = new BindingSource(comboArticoli, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
            }

        }

        private void btnArticolo_Click(object sender, EventArgs e)
        {
            var myForm = new FormArticolo();
            myForm.ShowDialog();
            AggiornaInterfaccia();
        }
    }
}

