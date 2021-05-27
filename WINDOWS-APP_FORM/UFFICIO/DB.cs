using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFFICIO
{
    static class DB
    {

        //Stringa di connessione al database locale 
        private static string _connectionString = "SERVER=ITS-SEGALLA\\SQLEXPRESS;DATABASE=dbGestioneCommesse;Trusted_connection=TRUE;";
        //private static string _connectionString = "SERVER=MONTELEONE-ITS\\SQLEXPRESS;DATABASE=dbGestioneCommesse;Trusted_connection=TRUE;";


        // private static string _connectionString = "SERVER=SAMUELE-TEST\\SQLEXPRESS;DATABASE=dbGestioneCommesse;Trusted_connection=TRUE;";

    #region "Insert"
    static public void InsertArticolo(Articolo dato)
    {
        SqlConnection con = new SqlConnection(_connectionString);
            ;
            Console.WriteLine(con); 
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO tblArticoli (Nome, Descrizione) " +
            "VALUES(@Nome, @Descrizione)";
        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Nome", dato.nome);
            cmd.Parameters.AddWithValue("Descrizione", dato.descrizione);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    static public int InsertCommessa(Commessa dato)
    {
            int controllo = 0;
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO tblCommesse (Codice, StatoCommessa, idArticolo, NumeroPezzi,DataConsegna,StatoMacchina) " +
            "VALUES(@Codice, @StatoCommessa, @idArticolo , @NumeroPezzi,@DataConsegna,@StatoMacchina)";

        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Codice", dato.codice);
            cmd.Parameters.AddWithValue("StatoCommessa", dato.stato);
            cmd.Parameters.AddWithValue("idArticolo", Convert.ToInt32(dato.articolo));
            cmd.Parameters.AddWithValue("NumeroPezzi", Convert.ToInt32(dato.numeroPezzi));
            cmd.Parameters.AddWithValue("DataConsegna", Convert.ToDateTime(dato.dataconsegna));
            cmd.Parameters.AddWithValue("StatoMacchina", dato.statoMacchina);

            controllo =cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
            
        }
            return controllo;
        }

    static public void InsertProduzione(Produzione dato)
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO tblProduzione (idCommessa, PezziProdotti, PezziScartati, RitardoEsecuzione) " +
            "VALUES(@idCommessa, @PezziProdotti, @PezziScartati, @RitardoEsecuzione)";

        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("idCommessa", Convert.ToInt32(dato.idCommessaProd));
            cmd.Parameters.AddWithValue("PezziProdotti", Convert.ToInt32(dato.pezziProdotti));
            cmd.Parameters.AddWithValue("PezziScartati", Convert.ToInt32(dato.pezziScartati));
            cmd.Parameters.AddWithValue("RitardoEsecuzione", Convert.ToInt32(dato.ritardoEsecuzione));

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region "Update"

    static public void UpdatePezzi(int id, UInt32 PezziProdotti, UInt32 PezziScartati)
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE tblProduzione SET " + "PezziProdotti = @PezziProdotti" + "PezziScartati = @PezziScartati"
        + "WHERE id = @id";

        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("PezziProdotti", PezziProdotti);
            cmd.Parameters.AddWithValue("PezziScartati", PezziScartati);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    static public void UpdateSpeed(int id, int RitardoEsecuzione)
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE tblProduzione SET RitardoEsecuzione = @RitardoEsecuzione "
            + "WHERE id = @id";

        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("RitardoEsecuzione", RitardoEsecuzione);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    static public void UpdateStato(int id, string statoCom,string statoMac)
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE tblCommesse SET StatoCommessa = @Stato ,StatoMacchina=@StatoM  "
            + "WHERE id = @id";

        try
        {
            con.Open();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Stato", statoCom);
            cmd.Parameters.AddWithValue("StatoM", statoMac);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
        static public void UpdateData(int id, DateTime data)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE tblCommesse SET DataCompletamento = @DataCompletamento "
                + "WHERE id = @id";

            try
            {
                con.Open();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("DataCompletamento", data);
                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        static public void ResetCommesse()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE tblCommesse SET StatoCommessa = @statocomm,StatoMacchina=@StatoM "
                + "WHERE StatoCommessa= 'Attiva'";

            try
            {
                con.Open();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("statocomm", "Inattiva");
                cmd.Parameters.AddWithValue("StatoM", "Arresto");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        #endregion

        #region "Select"
        static public List<Articolo> GetArticoli()
        {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblArticoli", con);
        SqlDataReader dr;
        
        List<Articolo> lista = new List<Articolo>();

        try
        {
            con.Open();
            cmd.Parameters.Clear();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Articolo tmp = new Articolo();
                tmp.idArticolo = dr.GetInt32(dr.GetOrdinal("id"));
                tmp.nome = dr.GetString(dr.GetOrdinal("Nome"));
                tmp.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));
                lista.Add(tmp);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return lista;
    }

        static public List<Commessa> GetCommesse()
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCommesse", con);
        SqlDataReader dr;
       
        List<Commessa> lista = new List<Commessa>();

        try
        {
            con.Open();
            cmd.Parameters.Clear();

            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                Commessa tmp = new Commessa();
                tmp.idCommessa = dr.GetInt32(dr.GetOrdinal("id"));
                tmp.codice = dr.GetString(dr.GetOrdinal("Codice"));
                tmp.stato= dr.GetString(dr.GetOrdinal("StatoCommessa"));
                tmp.articolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                tmp.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                    if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                    {
                        tmp.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                    {
                        tmp.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("StatoMacchina")))
                    {
                        tmp.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                    }
                    lista.Add(tmp);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return lista;
    }

        static public List<Produzione> GetProduzione()
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblProduzione", con);
        SqlDataReader dr;
        
        List<Produzione> lista = new List<Produzione>();

        try
        {
            con.Open();
            cmd.Parameters.Clear();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                    Produzione tmp = new Produzione();
                   tmp.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                tmp.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                tmp.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                tmp.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                tmp.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("RitardoEsecuzione")));
                lista.Add(tmp);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return lista;
    }

        static public List<Storico> GetCommesseFinite()
    {
        SqlConnection con = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM ViewTotale WHERE StatoCommessa = 'Conclusa' AND StatoMacchina=Arresto And StatoMacchina=Errore AND DataCompletamento IS NOT NULL", con);
        SqlDataReader dr;
       
        List<Storico> lista = new List<Storico>();

        try
        {
            con.Open();
            cmd.Parameters.Clear();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                    Storico tmp = new Storico();                    
                    tmp.C.idCommessa = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.P.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.C.codice = dr.GetString(dr.GetOrdinal("Codice"));
                    tmp.A.idArticolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                    tmp.C.stato = dr.GetString(dr.GetOrdinal("StatoCommessa"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                    {
                        tmp.C.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                    {
                        tmp.C.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("StatoMacchina")))
                    {
                        tmp.C.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                    }
                   
                    tmp.C.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                    tmp.P.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                    tmp.P.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                    tmp.P.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                    tmp.P.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("ritardoEsecuzione")));
                    tmp.A.nome = dr.GetString(dr.GetOrdinal("Nome"));
                    tmp.A.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));
                    lista.Add(tmp);
                }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return lista;
    }

        static public Storico GetCommessaAttiva()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewTotale WHERE StatoCommessa = 'Attiva'  AND  StatoMacchina ='arresto'", con);
            SqlDataReader dr;

            Storico tmp = new Storico();

            try
            {
                con.Open();
                cmd.Parameters.Clear();

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    tmp.C.idCommessa = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.P.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.C.codice = dr.GetString(dr.GetOrdinal("Codice"));
                    tmp.A.idArticolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                    tmp.C.stato = dr.GetString(dr.GetOrdinal("StatoCommessa"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                    {
                        tmp.C.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                    {
                        tmp.C.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("StatoMacchina")))
                    {
                        tmp.C.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                    }
                    tmp.C.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                    tmp.P.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                    tmp.P.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                    tmp.P.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                    tmp.P.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("ritardoEsecuzione")));
                    tmp.A.nome = dr.GetString(dr.GetOrdinal("Nome"));
                    tmp.A.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return tmp;
        }
            static public Storico GetCommessaCommessaNonArresto()
            {
                SqlConnection con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewTotale WHERE StatoCommessa = 'Attiva' AND  StatoMacchina not like '%arresto%' ", con);
                SqlDataReader dr;

                Storico tmp = new Storico();

                try
                {
                    con.Open();
                    cmd.Parameters.Clear();

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {


                        tmp.C.idCommessa = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                        tmp.P.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                        tmp.C.codice = dr.GetString(dr.GetOrdinal("Codice"));
                        tmp.A.idArticolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                        tmp.C.stato = dr.GetString(dr.GetOrdinal("StatoCommessa"));
                        if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                        {
                            tmp.C.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                        }
                        if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                        {
                            tmp.C.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                        }
                        if (!dr.IsDBNull(dr.GetOrdinal("StatoMacchina")))
                        {
                            tmp.C.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                        }
                        tmp.C.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                        tmp.P.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                        tmp.P.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                        tmp.P.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                        tmp.P.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("ritardoEsecuzione")));
                        tmp.A.nome = dr.GetString(dr.GetOrdinal("Nome"));
                        tmp.A.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return tmp;
            }
        
          static public List<Storico> GetCommesseInattive()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM viewTotale WHERE StatoCommessa='Inattiva'", con);
            SqlDataReader dr;

            List<Storico> lista = new List<Storico>();
            
            try
            {
                con.Open();
                cmd.Parameters.Clear();
                dr = cmd.ExecuteReader();
                

                while (dr.Read())
                {
                    Storico tmp = new Storico();
                    tmp.C.idCommessa = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.P.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                    tmp.C.codice = dr.GetString(dr.GetOrdinal("Codice"));
                    tmp.A.idArticolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                    tmp.C.stato = dr.GetString(dr.GetOrdinal("StatoCommessa"));
                    if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                    {
                        tmp.C.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                    {
                        tmp.C.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("StatoMacchina")))
                    {
                        tmp.C.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                    }
                    tmp.C.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                    tmp.P.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                    tmp.P.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                    tmp.P.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                    tmp.P.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("ritardoEsecuzione")));
                    tmp.A.nome = dr.GetString(dr.GetOrdinal("Nome"));
                    tmp.A.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));
                    lista.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return lista;
        }


        static public int GetIndexCommessa(string m,string dataconsegna)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT id FROM tblCommesse"+"WHERE Codice="+m +"AND"+ " DataConsegna="+dataconsegna, con);
            SqlDataReader dr;
            Commessa tmp = new Commessa();
            int x = 0;

            try
            {
                con.Open();
                cmd.Parameters.Clear();

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tmp.idCommessa = dr.GetInt32(dr.GetOrdinal("id"));
                    x = tmp.idCommessa;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return x;
        }
        static public int GetIndexArticolo(Articolo m)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblArticolo where ID="+m.idArticolo, con);
            SqlDataReader dr;
            Articolo tmp = new Articolo();
            int x = 0;

            try
            {
                con.Open();
                cmd.Parameters.Clear();

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tmp.idArticolo = dr.GetInt32(dr.GetOrdinal("id"));
                    x = tmp.idArticolo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return x;
        }




        static public Storico GetCommessa(int i)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM viewToTale WHERE id=" + i, con);
            SqlDataReader dr;


            Storico tmp = new Storico();

            try
            {
                con.Open();
                cmd.Parameters.Clear();
                dr = cmd.ExecuteReader();


                // DateTime tmpdate = new DateTime();
                // bool controllo=DateTime.TryParse(dr.GetString(dr.GetOrdinal("DataCompletamento")), out tmpdate);
                tmp.C.idCommessa = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                tmp.P.idCommessaProd = dr.GetInt32(dr.GetOrdinal("idCommessa"));
                tmp.C.codice = dr.GetString(dr.GetOrdinal("Codice"));
                tmp.A.idArticolo = dr.GetInt32(dr.GetOrdinal("idArticolo"));
                tmp.C.stato = dr.GetString(dr.GetOrdinal("StatoCommessa"));
                if (!dr.IsDBNull(dr.GetOrdinal("DataCompletamento")))
                {
                    tmp.C.dataCompletamento = dr.GetDateTime(dr.GetOrdinal("DataCompletamento"));
                }
                if (!dr.IsDBNull(dr.GetOrdinal("DataConsegna")))
                {
                    tmp.C.dataconsegna = dr.GetDateTime(dr.GetOrdinal("DataConsegna"));
                }
                tmp.C.statoMacchina = dr.GetString(dr.GetOrdinal("StatoMacchina"));
                tmp.C.numeroPezzi = Convert.ToUInt32(dr.GetInt32(dr.GetOrdinal("NumeroPezzi")));
                tmp.P.idproduzione = dr.GetInt32(dr.GetOrdinal("id"));
                tmp.P.pezziProdotti = dr.GetInt32(dr.GetOrdinal("PezziProdotti"));
                tmp.P.pezziScartati = dr.GetInt32(dr.GetOrdinal("PezziScartati"));
                tmp.P.ritardoEsecuzione = Convert.ToUInt16(dr.GetInt32(dr.GetOrdinal("ritardoEsecuzione")));
                tmp.A.nome = dr.GetString(dr.GetOrdinal("Nome"));
                tmp.A.descrizione = dr.GetString(dr.GetOrdinal("Descrizione"));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return tmp;
        }
            #endregion


    }
}
