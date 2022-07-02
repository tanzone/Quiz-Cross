using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneProgetto
{
    public partial class formAggiungi : Form
    {
        #region variabili
        private Label label1;
        private Label label2;
        private TextBox domanda;
        private TextBox risposta0;
        private TextBox risposta1;
        private TextBox risposta2;
        private TextBox risposta3;
        private Label label3;
        private Button button1;
        private TextBox punti;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox categoria;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        #endregion
        
        private static string stringaConn = "Server=localhost;Database=quizcross;Uid=root;Pwd=''";
        private static MySqlConnection connessione = new MySqlConnection(stringaConn);
        private static MySqlCommand com = new MySqlCommand();
        private static MySqlDataAdapter sqlData = new MySqlDataAdapter();


        public formAggiungi()
        {
            InitializeComponent();
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton4);

            MySqlConnection connessione = new MySqlConnection(stringaConn);
            MySqlCommand com = new MySqlCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataReader reader;
            List<String> categorie = new List<String>();

            connessione.Open();
            com.Connection = connessione;
            com.CommandText = "SELECT ID_GENERE from generi";
            com.ExecuteNonQuery();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                categorie.Add(reader[0].ToString());
            }

            foreach (string i in categorie)
            {
                categoria.Items.Add(i.ToString());
            }

            connessione.Close();
        }

        private void InitializeComponent()
        {
            this.categoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.domanda = new System.Windows.Forms.TextBox();
            this.risposta0 = new System.Windows.Forms.TextBox();
            this.risposta1 = new System.Windows.Forms.TextBox();
            this.risposta2 = new System.Windows.Forms.TextBox();
            this.risposta3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.punti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoria
            // 
            this.categoria.FormattingEnabled = true;
            this.categoria.Location = new System.Drawing.Point(12, 26);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(285, 24);
            this.categoria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Domanda";
            // 
            // domanda
            // 
            this.domanda.Location = new System.Drawing.Point(12, 88);
            this.domanda.Name = "domanda";
            this.domanda.Size = new System.Drawing.Size(285, 22);
            this.domanda.TabIndex = 3;
            // 
            // risposta0
            // 
            this.risposta0.Location = new System.Drawing.Point(12, 145);
            this.risposta0.Name = "risposta0";
            this.risposta0.Size = new System.Drawing.Size(285, 22);
            this.risposta0.TabIndex = 4;
            // 
            // risposta1
            // 
            this.risposta1.Location = new System.Drawing.Point(12, 171);
            this.risposta1.Name = "risposta1";
            this.risposta1.Size = new System.Drawing.Size(285, 22);
            this.risposta1.TabIndex = 5;
            // 
            // risposta2
            // 
            this.risposta2.Location = new System.Drawing.Point(12, 197);
            this.risposta2.Name = "risposta2";
            this.risposta2.Size = new System.Drawing.Size(285, 22);
            this.risposta2.TabIndex = 6;
            // 
            // risposta3
            // 
            this.risposta3.Location = new System.Drawing.Point(12, 223);
            this.risposta3.Name = "risposta3";
            this.risposta3.Size = new System.Drawing.Size(285, 22);
            this.risposta3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Risposte";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Conferma";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // punti
            // 
            this.punti.Location = new System.Drawing.Point(12, 276);
            this.punti.Name = "punti";
            this.punti.Size = new System.Drawing.Size(54, 22);
            this.punti.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Punti";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(300, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(58, 120);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 101);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(17, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 74);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(17, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(17, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(17, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // formAggiungi
            // 
            this.ClientSize = new System.Drawing.Size(354, 310);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.punti);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.risposta3);
            this.Controls.Add(this.risposta2);
            this.Controls.Add(this.risposta1);
            this.Controls.Add(this.risposta0);
            this.Controls.Add(this.domanda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoria);
            this.Name = "formAggiungi";
            this.Text = "AGGIUNGI NUOVA DOMANDA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connessione = new MySqlConnection(stringaConn);
            MySqlCommand com = new MySqlCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataReader reader;
            bool ok = true;
            int it = 0;
            int r = 0;

            TextBox[] risposte = { risposta0, risposta1, risposta2, risposta3 };

            connessione.Open();
            com.Connection = connessione;
            com.CommandText = "SELECT Testo from domande Where Testo Like ?Richiesta";
            com.Parameters.Add("?Richiesta", MySqlDbType.VarChar).Value = domanda.Text;
            com.ExecuteNonQuery();
            reader = com.ExecuteReader();

            if (reader.Read().ToString().Equals("True"))
            {
                ok = false;
            }

            reader.Close();
            

            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        r = it;
                    }
                }

                it++;
            }

            if(ok)
            {
                com.Parameters.Add("?Testo", MySqlDbType.VarChar).Value = domanda.Text;
                com.Parameters.Add("?R1", MySqlDbType.VarChar).Value = risposta0.Text;
                com.Parameters.Add("?R2", MySqlDbType.VarChar).Value = risposta1.Text;
                com.Parameters.Add("?R3", MySqlDbType.VarChar).Value = risposta2.Text;
                com.Parameters.Add("?R4", MySqlDbType.VarChar).Value = risposta3.Text;
                com.Parameters.Add("?RG", MySqlDbType.VarChar).Value = risposte[r].Text;
                com.Parameters.Add("?PUNTI", MySqlDbType.Int32).Value = punti.Text;
                com.Parameters.Add("?Arg", MySqlDbType.VarChar).Value = categoria.Text;

                com.CommandText = "INSERT INTO `domande` (`ID_DOMANDA`, `Testo`, `Risposta0`, `Risposta1`, `Risposta2`, `Risposta3`, `Soluzione`, `Punti`, `FK_ID_GENERE`) " +
                "VALUES (NULL, ?Testo, ?R1, ?R2, ?R3, ?R4, ?RG, ?PUNTI, ?Arg)";

                com.ExecuteNonQuery();
            }

            else
            {
                MessageBox.Show("Domanda già presente");
            }

            connessione.Close();

        }


    }
    
}
