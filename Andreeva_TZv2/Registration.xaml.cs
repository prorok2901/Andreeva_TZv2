using Andreeva_TZv2.Сompound;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;



namespace Andreeva_TZv2
{
    public partial class Registration : Page
    {
        private СonfirmationСode сonfirmation;

        private ComboBox login;

        private string confirmationСode;

        public Registration(ComboBox _login)
        {
            login = _login;
            InitializeComponent();
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {  
            if(Connector.DataBase().client.FirstOrDefault(a => a.email_Adress == EmailAdressClient.Text) == null)
            {
                if(CodePOD.Text == confirmationСode)
                {
                    BD.client client = new BD.client
                    {
                        email_Adress = EmailAdressClient.Text,
                        name = NameBox.Text,
                        passport_details = PassportDataBox.Text
                    };
                    Connector.DataBase().client.Add(client);
                    Connector.DataBase().SaveChanges();
                    ComboBoxLogin();
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Не праильный код подтверждения");
                }
            }
            else
            {
                MessageBox.Show("Такой номер есть, возможно клиент у нас был");
                NavigationService.GoBack();
            }
            
        }

        private void ComboBoxLogin()
        {
            login.Items.Clear();
            foreach (BD.client r in Connector.DataBase().client.ToList())
            {
                login.Items.Add(r.email_Adress);
            }
        }


        private void NameBox_GotFocus(object _sender, RoutedEventArgs _e)
        {
            if (NameBox.Text == "Введите имя клиента")
            {
                NameBox.Text = "";
            }
        }
        private void NameBox_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (NameBox.Text == "")
            {
                NameBox.Text = "Введите имя клиента";
            }
        }

        private void EmailClient_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (EmailAdressClient.Text == "")
            {
                EmailAdressClient.Text = "Электронный адрес клиента";
            }
            EmailCode();
        }
        private void EmailClient_GotFocus(object _sender, RoutedEventArgs _e)
        {

            if (EmailAdressClient.Text == "Электронный адрес клиента")
            {
                EmailAdressClient.Text = "";
            }
        }

        private void PassportData_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (PassportDataBox.Text == "")
            {
                PassportDataBox.Text = "Серия и номер паспорта клиента";
            }
        }
        private void PassportData_GotFocus(object _sender, RoutedEventArgs _e)
        {

            if (PassportDataBox.Text == "Серия и номер паспорта клиента")
            {
                PassportDataBox.Text = "";
            }
        }

        private void EmailCode()
        {
            if(EmailAdressClient.Text != "" && NameBox.Text != "")
            {
                сonfirmation = new СonfirmationСode(EmailAdressClient.Text, NameBox.Text);
                confirmationСode = сonfirmation.GetСonfirmationСode();
            }
        }
    }

}