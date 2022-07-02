using System;
using System.Collections.Generic;
using System.Data;

namespace QuizzCross
{
    public class Domanda
    {
        private int id;
        private string testo;
        private List<string> risposte;
        private string soluzione;
        private int punti;
        private string categoria;

        public int Id
        { get { return this.id; } }

        public string Testo
        { get { return this.testo; } }

        public List<string> Risposte
        { get { return this.risposte; } }

        public string Soluzione
        { get { return this.soluzione; } }

        public int Punti
        { get { return this.punti; } }

        public string Categoria
        { get { return this.categoria; } }

        public Domanda(DataTable dati)
        {
            this.id = Int32.Parse(dati.Rows[0]["ID_DOMANDA"].ToString());
            this.testo = dati.Rows[0]["Testo"].ToString();
            this.risposte = new List<string>()
            {
                dati.Rows[0]["Risposta0"].ToString(), dati.Rows[0]["Risposta1"].ToString(),
                dati.Rows[0]["Risposta2"].ToString(), dati.Rows[0]["Risposta3"].ToString()
            };
            this.soluzione = dati.Rows[0]["Soluzione"].ToString();
            this.punti = Int32.Parse(dati.Rows[0]["Punti"].ToString());
            this.categoria = dati.Rows[0]["FK_ID_GENERE"].ToString();
        }

        public bool IsCorretta(string risposta)
        {
            return (risposta.Equals(soluzione));
        }

        public void MischiaRisposte()
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
                Scambia(random.Next(0, risposte.Count), random.Next(0, risposte.Count));
        }

        private void Scambia(int primo, int secondo)
        {
            string tmp;
            tmp = risposte[primo];
            risposte[primo] = risposte[secondo];
            risposte[secondo] = tmp;
        }

        public int PosRispCoretta()
        {
            for (int i = 0; i < risposte.Count; i++)
                if (risposte[i].Equals(soluzione))
                    return i;
            return -1;
        }
    }
}
