using System.Data;

namespace QuizzCross
{
    public class Statistiche
    {
        private string divisione;
        private string nomeImage;
        private int risposteDate;
        private int risposteEsatte;
        private int posClassifica;
        private int gameGiocati;
        private int gameVinti;

        public string Divisione
        { get { return this.divisione; } }

        public string NomeImage
        { get { return this.nomeImage; } }

        public int RisposteDate
        { get { return this.risposteDate; } }

        public int RisposteEsatte
        { get { return this.risposteEsatte; } }

        public int PosClassifica
        { get { return this.posClassifica; } }

        public int GameGiocati
        { get { return this.gameGiocati; } }

        public int GameVinti
        { get { return this.gameVinti; } }

        public void TrovaValoriStat()
        {
            DataTable dati = GestioneConnessione.TrovaValoriStat();
            //Elaborazione del databe per trovare le varie informazioni necessarie

        }

        public string PercPerse()
        {
            return null;
        }
    }
}
