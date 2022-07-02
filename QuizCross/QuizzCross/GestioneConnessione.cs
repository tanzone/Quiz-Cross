using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace QuizzCross
{
    public class GestioneConnessione
    {
        private static MySqlConnection connessione = new MySqlConnection(Costanti.SERVER_CREDENZIALI);
        private static MySqlCommand com = new MySqlCommand();
        private static MySqlDataAdapter sqlData = new MySqlDataAdapter();

        #region Gestione finestra di Login --FINITO--
        public static bool Login(string username, string password)
        {
            return (Connessione("SELECT * FROM giocatori WHERE USERNAME LIKE '" + username + "' AND Password LIKE '" + password + "'", true));
        }

        public static bool Registrazione(string username, string password, int punteggio, int gameVinti, string nomeDiv, string nomeImm)
        {
            if (!Connessione("SELECT username FROM giocatori WHERE username LIKE '" + username + "'", true))
                if (InserisciRegistrazione(username, password, punteggio, gameVinti, nomeDiv, nomeImm))
                    return Login(username, password);
            return false;
        }

        private static bool Connessione(string comando, bool leggi)
        {
            bool risposta = true;

            connessione.Open();
            com.Connection = connessione;
            com.CommandText = comando;
            com.ExecuteNonQuery();
            if(leggi)
                risposta = com.ExecuteReader().Read().ToString().Equals(Costanti.MESSAGGIO_SQL_TRUE);

            connessione.Close();
            return risposta;
        }

        private static bool InserisciRegistrazione(string username, string password, int punteggio, int gameVinti, string nomeDiv, string nomeImm)
        {
            return (Connessione("INSERT INTO giocatori(USERNAME, Password, Punti, PartiteVinte, FK_ID_DIVISIONE, Avatar) VALUES(\"" + username + "\", \"" + password + "\"," + punteggio + "," + gameVinti + ", \"" + nomeDiv + "\",\"" +  nomeImm + "\");", false));
        }
        #endregion

        #region Query con dataBase --FINITO--
        private static DataTable InviaQuery(string query)
        {
            DataTable datiRitorno = new DataTable();
            connessione.Open();
            com.Connection = connessione;
            com.CommandText = query;
            sqlData.SelectCommand = com;
            sqlData.Fill(datiRitorno);
            connessione.Close();
            sqlData.Dispose();

            return datiRitorno;
        }
        #endregion

        #region Richieste della classe Domanda con le info delle domande --FINITO--
        public static DataTable PopolaDomanda(string categoria)
        {
            return InviaQuery("SELECT * FROM domande WHERE FK_ID_GENERE LIKE '" + categoria + "' ORDER BY RAND() LIMIT 1");
        }

        public static void CaricaEsitoDomanda(Domanda dom, Profilo prof)
        {
            EseguiQuery("INSERT INTO rispostegiocatori(FK_USERNAME, FK_ID_DOMANDA) VALUES(\"" + prof.Username + "\"," + dom.Id + "); ");
            EseguiQuery("UPDATE giocatori SET Punti=" + (prof.Punteggio + dom.Punti) + " WHERE USERNAME=\"" + prof.Username + "\"");
            EseguiQuery("UPDATE giocatori SET PartiteVinte=" + (prof.PartiteVinte+1) + " WHERE USERNAME=\"" + prof.Username + "\"");
        }

        private static void EseguiQuery(string query)
        {
            connessione.Open();
            com.Connection = connessione;
            com.CommandText = query;
            com.ExecuteNonQuery();
            connessione.Close();
        }
        #endregion

        #region Richieste della classe Profilo per le informazioni --FINITO--
        public static int CercaPunteggio(string username)
        {
            return LeggiPunteggio(InviaQuery("SELECT punti FROM Giocatori WHERE USERNAME LIKE '" + username + "'"));           
        }

        private static int LeggiPunteggio(DataTable dati)
        {
            return Int32.Parse(dati.Rows[0]["Punti"].ToString());
        }

        public static string TrovaAvatar(string username)
        {
            return LeggiAvatar(InviaQuery("SELECT Avatar FROM Giocatori WHERE USERNAME LIKE '" + username + "'"));
        }

        private static string LeggiAvatar(DataTable dati)
        {
            return dati.Rows[0]["Avatar"].ToString();
        }

        public static int CercaPartite(string username)
        {
            return LeggiPunteggio(InviaQuery("SELECT PartiteVinte FROM Giocatori WHERE USERNAME LIKE '" + username + "'"));
        }

        private static int LeggiPartite(DataTable dt)
        {
            return Int32.Parse(dt.Rows[0]["PartiteVinte"].ToString());
        }
        #endregion

        #region Richieste della classe Statistiche per le informazioni --DA FARE--
        public static DataTable TrovaValoriStat()
        {
            //Da fare la richiesta e sistemare il database
            string query = "";
            return InviaQuery(query);
        }
        #endregion

        #region Cambio dell'Username e della Password --FINITO--
        public static bool CambiaUser(string username, string userNuovo)
        {
            return EseguiUpdate("UPDATE Giocatori SET USERNAME = '" + userNuovo + "' WHERE USERNAME LIKE '" + username + "'");
        }

        public static bool CambiaPass(string username, string passNuova)
        {
            return EseguiUpdate("UPDATE Giocatori SET Password = '" + passNuova + "' WHERE USERNAME LIKE '" + username + "'");
        }

        private static bool EseguiUpdate(string query)
        {
            connessione.Open();
            com.Connection = connessione;
            com.CommandText = query;
            com.ExecuteNonQuery();
            connessione.Close();
            return true;
        }
        #endregion

        #region DataTable delle classifiche  --FINITO--
        public static DataTable TableTopUser(int num)
        {
            return InviaQuery("SELECT USERNAME, Punti, PartiteVinte, FK_ID_DIVISIONE FROM Giocatori ORDER BY Punti DESC LIMIT " + num);
        }

        public static DataTable TableUser()
        {
            return InviaQuery("SELECT USERNAME, Punti, PartiteVinte, FK_ID_DIVISIONE FROM Giocatori ORDER BY Punti DESC;");
        }
        #endregion

        #region Leggi Categorie --FINITO--
        public static void ListaCategorie()
        {
            DataTable dt = InviaQuery("SELECT ID_GENERE FROM Generi");

            foreach(DataRow dr in dt.Rows)
                Costanti.CATEGORIA.Add(dr["ID_GENERE"].ToString());
        }
        #endregion
    }
}
