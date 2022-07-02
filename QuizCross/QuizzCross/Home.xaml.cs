using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuizzCross
{
    /// <summary>
    /// Logica di interazione per Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private List<Grid> screens;
        private List<Button> choiseBut;
        private List<string> categorie;
        private List<Button> risposteBut;
        private Profilo profilo;
        private Statistiche stats;
        private Domanda domanda;
        
        #region Costruttore e inizializzazioni --SCOMMENTARE--
        public Home(string username)
        {
            profilo = new Profilo(username);
            stats = new Statistiche();

            InitializeComponent();
            SettaListe();
            SettaLabelUser();
        }

        private void SettaListe()
        {
            GestioneConnessione.ListaCategorie();
            categorie = Costanti.CATEGORIA.ToList();
            screens = new List<Grid>()
            {
                homeScreen, profileScreen, topListScreen, statScreen, choiceScreen, gameScreen
            };

            choiseBut = new List<Button>()
            {
                choiseBut_0, choiseBut_1, choiseBut_2,
                choiseBut_3, choiseBut_4, choiseBut_5,
                choiseBut_6, choiseBut_7, choiseBut_8
            };

            risposteBut = new List<Button>()
            {
                risposta_0, risposta_1, risposta_2, risposta_3
            };
        }

        private void SettaLabelUser()
        {
            statUser.Content = profilo.Username;
            //statImageProfile.Source = new BitmapImage(new Uri(profilo.NomeImage));
            profileUser.Content = profilo.Username;
            //profileImageProfile.Source = new BitmapImage(new Uri(profilo.NomeImage));
            choiceUser.Content = profilo.Username;
            //choiceImageProfile.Source = new BitmapImage(new Uri(profilo.NomeImage));
        }

        #endregion


        #region Azioni dei bottoni sopra per le varie finestre --DA SCOMMENTARE--
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDati(profilePunti, profileImageProfile);
            profileUserChange.Text = profilo.Username;
            MostraFinestra(Costanti.PROFILE_SCREEN);
        }

        private void TopListButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable top = Classifica.TopRank();
            DataTable bot = Classifica.ListUtenti();
            if (top != null && bot != null)
            {
                topRankGrid.ItemsSource = top.DefaultView;
                rankGrid.ItemsSource = bot.DefaultView;
            }
            else
                MessageBox.Show("Errore nel trovare la tabella");

            MostraFinestra(Costanti.TOPLIST_SCREEN);
        }

        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            //stats.TrovaValoriStat();
            RefreshDati(statPunti, statImageProfile);
            VisualizzaStat();
            MostraFinestra(Costanti.STATS_SCREEN);
        }

        private void VisualizzaStat()
        {
            statDivisione.Content = stats.Divisione;
            //statImageRank.Source = new BitmapImage(new Uri(stats.NomeImage));
            statNumPartite.Content = stats.GameGiocati;
            statGameVinti.Content = stats.GameVinti;
            statNumRisp.Content = stats.RisposteDate;
            statPercEsatte.Content = stats.RisposteEsatte;
            statPercErrate.Content = stats.PercPerse();
            statPosizione.Content = stats.PosClassifica;
        }
        #endregion


        #region Azioni Bottoni all'interno della finestra --RefreshDati() Da Scommentare--

        private void SinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            RefreshDati(choicePunti, choiceImageProfile);
            CreaBottoniCasuali();
            MostraFinestra(Costanti.CHOISE_SCREEN);
        }

        private void MultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("In costruzione");
            //RefreshDati(choicePunti, choiceImageProfile);
            //CreaBottoniCasuali();
            //MostraFinestra(Costanti.CHOISE_SCREEN);
        }

        private void TitleBack_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MostraFinestra(Costanti.HOME_SCREEN);
        }

        private void MostraFinestra(int numeroScreen)
        {
            NascondiScreen();
            screens[numeroScreen].Visibility = Visibility.Visible;
        }

        private void NascondiScreen()
        {
            foreach (Grid i in screens)
                i.Visibility = Visibility.Hidden;
        }

        private void CreaBottoniCasuali()
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
                Scambia(random.Next(0, categorie.Count), random.Next(0, categorie.Count));

            for (int i = 0; i < choiseBut.Count; i++)
                choiseBut[i].Content = categorie[i];
        }

        private void Scambia(int primo, int secondo)
        {
            string tmp;
            tmp = categorie[primo];
            categorie[primo] = categorie[secondo];
            categorie[secondo] = tmp;
        }

        private void RefreshDati(Label spec, Image image)
        {
            profilo.CercaPunteggio();
            spec.Content = profilo.Punteggio.ToString();
            //image.Source = new BitmapImage(new Uri(profilo.NomeImage)); 
        }

        private void CambiaUser_Click(object sender, RoutedEventArgs e)
        {
            if (GestioneConnessione.CambiaUser(profilo.Username, profileUserChange.Text))
            {
                profilo.Username = profileUserChange.Text;
                profileUser.Content = profilo.Username;
                MessageBox.Show("Cambio avvenuto con successo");
            }
            else
                MessageBox.Show("Errore durante la modifica");
        }

        private void CambiaPass_Click(object sender, RoutedEventArgs e)
        {
            if (profilePassChange.Password.Equals(profilePassChangeConfirm.Password))
            {
                if (GestioneConnessione.CambiaPass(profilo.Username, profilePassChange.Password))
                    MessageBox.Show("Cambio avvenuto con successo");
                else
                    MessageBox.Show("Errore durante la modifica");
            }
            else
                MessageBox.Show("Le due password non coincidono");
        }
        #endregion


        #region Focus e LostFocus delle textBox --FINITO--
        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(profilo.Username) || string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "";
        }

        private void Username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = profilo.Username;
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Password = "";
        }

        private void PasswordConfirm_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Password = "";
        }
        #endregion


        #region Script per la ricerca delle domande e apertura finestra gioco --FINITO--
        private void Categoria_Click(object sender, RoutedEventArgs e)
        {
            string[] premuto = ((Button)sender).Name.ToString().Split('_');
            string categoriaScelta = categorie[Int32.Parse(premuto[1])];

            if (categoriaScelta.Equals("Casuale"))
                PopolaDomanda(CategoriaCasuale());    
            else
                PopolaDomanda(categoriaScelta);

            SettaBottoniRisposte(true);
        }

        private string CategoriaCasuale()
        {
            return Costanti.CATEGORIA[new Random().Next(1, Costanti.CATEGORIA.Count)];
        }

        private void PopolaDomanda(string categoriaScelta)
        {
            DataTable dati = GestioneConnessione.PopolaDomanda(categoriaScelta);
            if(dati == null)
            {
                MessageBox.Show("Errore Durante la richiesta della domanda");
                MostraFinestra(Costanti.HOME_SCREEN);
                return;
            }
            domanda = new Domanda(dati);
            domanda.MischiaRisposte();

            testoDomanda.Text = domanda.Testo;
            for(int i = 0; i < domanda.Risposte.Count; i++)
                risposteBut[i].Content = domanda.Risposte[i];

            backCategoria.Visibility = Visibility.Hidden;
            MostraFinestra(Costanti.GAME_SCREEN);
        }
        #endregion


        #region Check domanda e vari messaggi per il dataBase
        private void ConfermaRisp_Click(object sender, RoutedEventArgs e)
        {
            string[] premuto = ((Button)sender).Name.ToString().Split('_');
            string risposta = domanda.Risposte[Int32.Parse(premuto[1])];

            SettaBottoniRisposte(false);
            if (domanda.IsCorretta(risposta))
            {
                ((Button)sender).Background = Brushes.Green; //MODIFICARE
                GestioneConnessione.CaricaEsitoDomanda(domanda, profilo);
            }
            else
            {
                ((Button)sender).Background = Brushes.Red; //MODIFICARE
                risposteBut[domanda.PosRispCoretta()].Background = Brushes.Green; //MODIFICARE 
            }
            backCategoria.Visibility = Visibility.Visible;
        }

        private void SettaBottoniRisposte(bool booleano)
        {
            foreach (Button i in risposteBut)
                i.IsEnabled = booleano;
        }

        private void BackCategoria_Click(object sender, RoutedEventArgs e)
        {
            MostraFinestra(Costanti.HOME_SCREEN);
            foreach (Button i in risposteBut) //MODIFICARE
                i.Background = Brushes.Silver; //MODIFICARE
        }
        #endregion



    }
}
