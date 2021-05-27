using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LettoreDatiPLCtoJSON
{
    static class SaveToDB
    {
        //Funzione per la stampa del log su file JSON
        static public void StoreDB(string commessa, string JSON)
        {
            string FileName = commessa + ".json";
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(JSON);

            sw.Close();
            fs.Close();
        }
    }
}
