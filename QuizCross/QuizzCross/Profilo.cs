namespace QuizzCross
{
    public class Profilo
    {
        private string username;
        private int punteggio;
        private string nomeImage;
        private int partiteVinte;

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public int Punteggio
        { get { return this.punteggio; } }

        public string NomeImage
        { get { return this.nomeImage; } }

        public int PartiteVinte
        { get { return this.partiteVinte; } }

        public Profilo(string username)
        {
            this.username = username;
            TrovaAvatar();
        }

        public void CercaPunteggio()
        {
            this.punteggio = GestioneConnessione.CercaPunteggio(this.username);
        }

        public void CercaPariteVinte()
        {
            this.partiteVinte = GestioneConnessione.CercaPartite(this.username);
        }

        private void TrovaAvatar()
        {
            nomeImage = GestioneConnessione.TrovaAvatar(this.username);
        }
    }
}
