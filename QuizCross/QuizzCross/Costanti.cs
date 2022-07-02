using System.Collections.Generic;

namespace QuizzCross
{
    public class Costanti
    {
        public static int HOME_SCREEN = 0;
        public static int PROFILE_SCREEN = 1;
        public static int TOPLIST_SCREEN = 2;
        public static int STATS_SCREEN = 3;
        public static int CHOISE_SCREEN = 4;
        public static int GAME_SCREEN = 5;


        public static string MESSAGGIO_SQL_TRUE = "True";


        public static string connessione = "Server=localhost;Uid=root;Pwd=''";
        public static string SERVER_CREDENZIALI = "Server=localhost;Database=quizcross;Uid=root;Pwd=''";

        public static List<string> CATEGORIA = new List<string>(){"Casuale"};
    }
}
