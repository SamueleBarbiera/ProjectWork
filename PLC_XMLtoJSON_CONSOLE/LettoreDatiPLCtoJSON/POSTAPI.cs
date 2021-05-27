using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;

namespace LettoreDatiPLCtoJSON
{
    class POSTAPI
    {
        //Funzione che invia una stringa in formato JSON in POST all'API

        private static HttpClient _httpClient = new HttpClient();

        static public string POSTData(string json)
        {
            
            string testo = "Tentativo di invio dati in POST all'API: ";
            testo += "@";

            //string url = "http://" + ConfigurationManager.AppSettings["ip_address_PLC"] + ConfigurationManager.AppSettings["port_API"] + "/api/logs/"; 
            
            string url = "http://127.0.0.1:3000/api/logs/";
            using (var content = new StringContent(json , System.Text.Encoding.UTF8, "application/json"))
            {
                try
                {
                    //invio dei dati tramite post e ricevo una risposta dello stato http
                    HttpResponseMessage result = _httpClient.PostAsync(url, content).Result;
                    //Se lo stato http è created (201) l'invio dei dati hha avuto successo
                    if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        testo += "SUCCESSO@";
                    }
                    else
                    {
                        testo += ($"FALLITO@: ({result.StatusCode})");
                    }
                    
                }
                catch
                {
                    testo += ("ERRORE@: connessione al server fallita!@");
                }
                return testo;
            }
        }
    }
}
