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

namespace UFFICIO
{
    public static class CSerialDeserial
    {

		public static void WriteFile(CDataBlock db)
		{
			XmlSerializer formatterWR = new XmlSerializer(typeof(CDataBlock));
			Stream myStreamWR = new FileStream(db.DBname + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
			formatterWR.Serialize(myStreamWR, db);
			myStreamWR.Close();
		}

		public static void ReadFile(ref CDataBlock db)
		{
			XmlSerializer formatterRD = new XmlSerializer(typeof(CDataBlock));
			try
			{
				Stream myStreamRD = new FileStream(db.DBname + ".xml", FileMode.Open, FileAccess.Read, FileShare.Write);
				db = (CDataBlock)formatterRD.Deserialize(myStreamRD);
				myStreamRD.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	}
}
