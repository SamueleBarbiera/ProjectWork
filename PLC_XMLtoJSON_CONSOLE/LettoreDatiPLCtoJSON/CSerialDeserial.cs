using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace LettoreDatiPLCtoJSON
{
    class CSerialDeserial
    {
		public static void WriteFile(CDataBlock db)
		{
			XmlSerializer formatterWR = new XmlSerializer(typeof(CDataBlock));
			Stream myStreamWR = new FileStream(db.DBName + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
			formatterWR.Serialize(myStreamWR, db);
			myStreamWR.Close();
		}
		public static string ReadFile(CDataBlock db)
		{
			XmlSerializer formatterRD = new XmlSerializer(typeof(CDataBlock));
			string Dati  =  "ERRORE";
			try
			{	string xml = db.ToString();
				Stream myStreamRD = new FileStream(db.DBName + ".xml", FileMode.Open, FileAccess.Read, FileShare.Write);
				db = (CDataBlock)formatterRD.Deserialize(myStreamRD);
				
				Dati =  ConversionXML_JSON(xml);
				myStreamRD.Close();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return Dati;
		}

		public static string ConversionXML_JSON(string xml)
        {
			// To convert an XML node contained in string xml into a JSON string   
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			string jsonText = JsonConvert.SerializeXmlNode(doc);
			
			return jsonText;
		}
	}
}
