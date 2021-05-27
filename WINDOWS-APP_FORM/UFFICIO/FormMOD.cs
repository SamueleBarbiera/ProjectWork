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
    public partial class FormMOD : Form
    {
        public FormMOD()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
          
            Scrittura_PC_PLC.ModificaErrore(id);
            AggiornaInterfaccia();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Scrittura_PC_PLC.ModificaEliminaMessaggioOperatore();
            AggiornaInterfaccia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            short x = Convert.ToInt16(id);
            Scrittura_PC_PLC.ModificaErrore(x);
            UInt16 newVel = Convert.ToUInt16(numericUpDown1.Value*1000);
            Scrittura_PC_PLC.ModificaVelocitàPLC(newVel);
            AggiornaInterfaccia();
        }

        private void FormMOD_Load(object sender, EventArgs e)
        {
            AggiornaInterfaccia();
        }


        private void AggiornaInterfaccia()
        {

            string[] Errori = { "Tutto OK", "Sacrico Pieno", "Pressa guasta", "Coclea guasta", "Mancanza aria impianto", "ev1 rotta", "ev2 rotta", "ev3 rotta", "ev4 rotta", "sensori fc pistone 1 rotto", "sensori fc pistone 2 rotto", "sensori fc pistone 3 rotto", "sensori fc pistone 4 rotto", "Mancanza pezzi al prelievo" };

            Dictionary<int, string> comboArticoli = new Dictionary<int, string>();

            for (int i = 0; i < Errori.Length; i++)
            {


                comboArticoli.Add(i, Errori[i]);
            }
            if (comboArticoli.Count() > 0)
            {
                comboBox1.DataSource = new BindingSource(comboArticoli, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
            string[] ErroriProd = { "Abilito produzione da ufficio", "Start Programmato da ufficio Pieno", "Blocco incondizionato della produzione", "Blocco per manutenzione dell'impianto", "Blocco Programmato per verifica" };

            Dictionary<int, string> comboprod = new Dictionary<int, string>();

            for (int i = 0; i < ErroriProd.Length; i++)
            {


                comboprod.Add(i, ErroriProd[i]);
            }
            if (comboprod.Count() > 0)
            {
                comboBox2.DataSource = new BindingSource(comboprod, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
            }



            listBox1.Items.Clear();
            string mess = Lettura_dati_plc.LeggiDati();
            int connesso = Scrittura_PC_PLC.Connettere();
            if (connesso == 0)
            {
                if (mess != "Errore connesione ad API")
                {
                    listBox1.Items.Add(mess);
                }
                else
                {
                    listBox1.Items.Add("");
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                listBox1.Items.Add("Non connesso al plc");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            
           

        }
       



        
        
    }
}
