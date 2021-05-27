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
    public partial class FormArticolo : Form
    {
        public FormArticolo()
        {
            InitializeComponent();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            string NomeArticolo = txtNomeArticolo.Text;
            string DescArticolo = txtDescrizione.Text;
            if (NomeArticolo!=""&& DescArticolo!="")
            {
                Articolo Art = new Articolo();
                Art.nome = NomeArticolo;
                Art.descrizione = DescArticolo;
                DB.InsertArticolo(Art);
            }
            else
            {
                if(NomeArticolo == ""&& DescArticolo == "")
                {
                    MessageBox.Show("Attenzione", "I due Campi non sono stati specificati", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(NomeArticolo == "")
                {
                    MessageBox.Show("Attenzione", "Il nome dell'articolo non è stato specificato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
                else
                {
                    MessageBox.Show("Attenzione", "Il la descrizione dell'articolo non è stata specificata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
