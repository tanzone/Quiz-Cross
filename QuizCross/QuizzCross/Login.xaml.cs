using System.Windows;
using System.Windows.Controls;

namespace QuizzCross
{
    /// <summary>
    /// Logica di interazione per Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Azioni bottoni per il login o la registrazione
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Password.ToString()))
            {
                MessageBox.Show("Immettere una password valida");
            }
            else if (GestioneConnessione.Registrazione(username.Text.ToLower(), password.Password, 0, 0, "Bronzo", "terzo"))
            {
                MessageBox.Show("Registrazione avvenuta con successo");
                new Home(username.Text.ToLower()).Show();
                this.Close();
            }
            else
                MessageBox.Show("Username già presente");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (GestioneConnessione.Login(username.Text.ToLower(), password.Password))
            {
                new Home(username.Text.ToLower()).Show();
                this.Close();
            }
            else
                MessageBox.Show("Username o password non esistenti");
        }
        #endregion

        #region PlaceHolder dei bottoni 
        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Equals("Username") || string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "";
        }

        private void Username_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "Username";
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Password = "";
        }
        #endregion
    }
}
