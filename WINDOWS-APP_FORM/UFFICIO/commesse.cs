using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFFICIO
{
    public class Commessa
    {
        public int idCommessa { set; get; }
        public string codice { set; get; }
        public int articolo { set; get; }
        public string stato { set; get; }
        public DateTime dataCompletamento { set; get; }
        public UInt32 numeroPezzi { set; get; }
        public DateTime dataconsegna { set; get; }
        public string statoMacchina { set; get; }
        //metodo per mostrare tutte le info associate a parte la data finale dato che è irrilevante ad una singola commessa<
        public  string stampadatiCom()
        {
            string date="";
            DateTime datanulla=Convert.ToDateTime(null);
            if(dataCompletamento!= datanulla)
            {
                date += dataCompletamento;
            }
           
            return idCommessa+ " " + codice + " " + stato + " " + statoMacchina + " "  + numeroPezzi + " " + dataconsegna +" "+date;
        }

      
    }

    public class Articolo
    {
        public int idArticolo { set; get; }
        public string nome { set; get; }
        public string descrizione { set; get; }
        //metodo per mostrare tutte le info associate ad un singolo articolo
        public  string stampadatiArt()
        {
            return idArticolo+" "+nome + " " + descrizione ;
        }
    }

    public  class Produzione
    {
        public int idproduzione { set; get; }
        public int idCommessaProd { set; get; }
        public int pezziProdotti { set; get; }
        public int pezziScartati { set; get; }
        public UInt16 ritardoEsecuzione { set; get; }
        //metodo per mostrare tutte le info associate ad un singolo oggetto produzione
        public  string stampadatiProd()
        {
            return  " Pezzi prodotti buoni "+pezziProdotti + " Pezzi scartati " + pezziScartati + " delay da ufficio " + ritardoEsecuzione;
        }
    }

    public class Storico
    {

        public Produzione P;
        public Commessa C;
        public Articolo A;

        //metodo per mostrare tutte le info associate ad una bolla di produzione
        public  string stampatutto()
        {
            return P.stampadatiProd()+" " + C.stampadatiCom()+" " + A.stampadatiArt();
        }


        //metodo per mostrare tutte le info associate alla singola commessa della bolla
        public  string InfoComm()
        {
            return "Dati commessa " + C.stampadatiCom() +"\nDati articolo "+ A.stampadatiArt()+"\n"+P.stampadatiProd();
        }
        public Storico()
        {
            P = new Produzione();
            C = new Commessa();
            A = new Articolo();
        }
    }
}
