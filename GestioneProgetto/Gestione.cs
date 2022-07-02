using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneProgetto
{
    public partial class Finestra : Form
    {
        private string connessione = "Server=localhost;Uid=root;Pwd=''";

        public Finestra()
        {
            InitializeComponent();
        }

        private void creaDb_Click(object sender, EventArgs e)
        {
            label1.Text = "CARICAMENTO IN CORSO";
            MySqlConnection connessione = new MySqlConnection(this.connessione);
            connessione.Open();
            MySqlScript script = new MySqlScript(connessione, File.ReadAllText("quizcross.sql"));
            script.Delimiter = ";";
            script.Execute();
            label1.Text = "";

            connessione.Close();
        }

        private void eliminaDb_Click(object sender, EventArgs e)
        {
            label1.Text = "CARICAMENTO IN CORSO";
            MySqlConnection connessione = new MySqlConnection(this.connessione);
            connessione.Open();
            MySqlScript script = new MySqlScript(connessione, "DROP DATABASE IF EXISTS quizcross");
            script.Delimiter = ";";
            script.Execute();
            label1.Text = "";
        }

        private void addDomande_Click(object sender, EventArgs e)
        {
            formAggiungi add = new formAggiungi();
            add.ShowDialog();
        }

        private void creaSfide_Click(object sender, EventArgs e)
        {
            GestioneConnessione.CreaSfide();
        }

        private void cancellaSfide_Click(object sender, EventArgs e)
        {
            GestioneConnessione.CancellaSfideObsolete();
        }
    }
}
