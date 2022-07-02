using System.Data;

namespace QuizzCross
{
    public class Classifica
    {
        public static DataTable TopRank()
        {
            return GestioneConnessione.TableTopUser(3);
        }

        public static DataTable ListUtenti()
        {
            return GestioneConnessione.TableUser();
        }
    }
}
