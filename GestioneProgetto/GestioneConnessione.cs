using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneProgetto
{
    public class GestioneConnessione
    {
        private static string stringaConn = "Server = localhost; Database=quizcross;Uid=root;Pwd='';Convert Zero Datetime=True";
        private static MySqlConnection connessione = new MySqlConnection(stringaConn);
        private static MySqlCommand com = new MySqlCommand();
        private static MySqlDataAdapter sqlData = new MySqlDataAdapter();

        private static bool EseguiUpdate(string query)
        {
            connessione.Open();
            com.Connection = connessione;
            com.CommandText = query;
            com.ExecuteNonQuery();
            connessione.Close();
            return true;
        }

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


        /// <summary>
        /// Metodo che crea tutte le sfide giornaliere, trovando prima tutte le coppie di utenti per poi creare le partite
        /// </summary>
        /// 

        public static void CancellaSfideObsolete()
        {
            String comandoRicerca = "Select sfide.FK_ID_PARTITA, sfide.ID_SFIDA,sfide.DataScadenza From sfide Inner Join partite on sfide.FK_ID_PARTITA = partite.ID_PARTITA";
            DataTable dt_sfidePartiteObsolete = InviaQuery(comandoRicerca);

            foreach (DataRow r in dt_sfidePartiteObsolete.Rows)
            {

                DateTime dataScadenza = (DateTime)(r[2]);

                if (dataScadenza.CompareTo(DateTime.Today) <= 0)
                {
                    String comandoEliminazione = "DELETE FROM sfide WHERE sfide.ID_SFIDA =" + (int)r[1] + " ; ";
                    EseguiUpdate(comandoEliminazione);

                    comandoEliminazione = "DELETE FROM partite WHERE partite.ID_PARTITA =" + (int)r[0] + " ; ";
                    EseguiUpdate(comandoEliminazione);

                    MessageBox.Show("OBSOLETA Eliminata id " + (int)r[1] + " " + r[0]);

                }


                DateTime dt = new DateTime();
            }

            return;
        }

        public static void CreaSfide()
        {
            DataTable dt_usernameList = InviaQuery("SELECT USERNAME FROM giocatori");
            int NUMERO_GIORNI_SFIDE = 1; //#COSTANTE

            // Creo una sfida per gni coppia di giocatori
            for (int i = 0; i < dt_usernameList.Rows.Count - 1; i++)
            {
                String szPlayer1 = (string)(dt_usernameList.Rows[i]["USERNAME"]);

                for (int j = i + 1; j < dt_usernameList.Rows.Count; j++)
                {
                    String szPlayer2 = (string)(dt_usernameList.Rows[j]["USERNAME"]);

                    if (szPlayer1 != szPlayer2)
                    {
                        // CREA SFIDA CASUALE TRA DUE PLAYRS
                        //data inizioSfida
                        DateTime oggi = DateTime.Today;

                        //Data fineSfida
                        DateTime scadenza = oggi.AddDays(NUMERO_GIORNI_SFIDE);


                        String comandoInserimento = "" + "INSERT INTO `sfide` (`ID_SFIDA`, `FK_ID_PARTITA`, `DataInizio`, `DataScadenza`)" +
                                                                                         " VALUES (NULL, '" + CreaPartitaInSfida(szPlayer1, szPlayer2) + "', '" +
                                                                                         oggi.ToString("yyyy-mm-dd") + "', '" +
                                                                                         scadenza.ToString("yyyy-mm-dd") + "')";
                        EseguiUpdate(comandoInserimento);

                        MessageBox.Show("sfida creata dATA " + scadenza);
                    }
                }
            }

            return;
        }


        private static int CreaPartitaInSfida(String player1, String player2)
        {
            int idPartita;
            String comandoAggiunta = "INSERT INTO `partite` (`ID_PARTITA`, `Punti1`, `Punti2`, `FK_USERNAME1`, `FK_USERNAME2`, `FK_USERNAME_VINCITORE`)" +
                                                             " VALUES (NULL, NULL, NULL,'" + player1 + "','" + player2 + "', NULL);";

            //EseguiUpdate
            EseguiUpdate(comandoAggiunta);

            //Rimedio l'id dell'ultima partita
            DataTable dt = InviaQuery("SELECT LAST_INSERT_ID()");
            Int32.TryParse((string)(dt.Rows[0][0] + ""), out idPartita);

            //Crea Rounds collegati alla partita
            CreaRounds(idPartita);

            return idPartita;
        }


        private static void CreaRounds(int id_partitaCollegata)
        {
            int NUMERO_ROUNDS_PARTITE = 1; // #COSTANTE 

            // Creo il numero desiderato di rounds
            for (int i = 0; i < NUMERO_ROUNDS_PARTITE; i++)
            {
                // Aggiungo un round collegato alla partita collegata
                String comandoAggiunta = "INSERT INTO `rounds` (`ID_ROUND`, `FK_ID_PARTITA`, `NumeroRound`) VALUES (NULL," + "'" + id_partitaCollegata + "','" + i + "1');";
                EseguiUpdate(comandoAggiunta);

                //Riprendo l'id dell'ultimo round aggiunto
                int idRoundInserito;
                DataTable dt = InviaQuery("SELECT LAST_INSERT_ID()");
                Int32.TryParse((string)(dt.Rows[0][0] + ""), out idRoundInserito);

                //Aggiungo le partite al round
                CreaRelazioneRoundPartita(idRoundInserito);
            }

            return;
        }

        private static void CreaRelazioneRoundPartita(int id_roundCollegato)
        {
            int NUMERO_DOMANDE_ROUND = 2;  // #COSTANTE

            // Aggiungo al Round il numero di partite prefissato
            for (int i = 0; i < NUMERO_DOMANDE_ROUND; i++)
            {
                //Prendo una domanda casuale
                String comandoRicerca = "SELECT ID_DOMANDA FROM domande  ORDER BY RAND() LIMIT 1";
                DataTable dt = InviaQuery(comandoRicerca);
                int id_domanda;
                Int32.TryParse((String)("" + dt.Rows[0][0]), out id_domanda);

                //Collego la domanda al suo round corrispondente
                String comandoAggiunta = "INSERT INTO `domandenelround` (`FK_ID_ROUND`, `FK_ID_DOMANDA`) VALUES ('" + id_roundCollegato + "'," + "'" + id_domanda + "');";
                EseguiUpdate(comandoAggiunta);
            }
            return;
        }
    }
}
