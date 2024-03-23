using RealEstateAgency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RealEstateAgency.WindowGroup
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        Entities entities;
        Clients client;
        public AddClientWindow(Entities entities, Clients client)
        {
            InitializeComponent();
            this.entities = entities;

            if (client.Id != 0)
            {
                FirstNameInput.Text = client.FirstName;
                LastNameInput.Text = client.LastName;
                MiddleNameInput.Text = client.MiddleName;
                PhoneInput.Text = client.Phone;
                EmailInput.Text = client.Email;
            }

            this.client = client;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameInput.Text == string.Empty ||
                LastNameInput.Text == string.Empty ||
                PhoneInput.Text == string.Empty ||
                EmailInput.Text == string.Empty ||
                MiddleNameInput.Text == string.Empty)
            {
                MessageBox.Show("Не все данные введены!");
            }
            else
            {
                //^ — начало
                //$ — конец
                //\w — буква или цифра
                //+ — 1 или больше предыдущего символа
                var regexEmail = new Regex(@"^\w+@\w+\.\w+$");
                //Если эмайл не совпадает с <буквы-цифры@буквы-цифры.буквы-цифры>
                if (!regexEmail.IsMatch(EmailInput.Text))
                {
                    MessageBox.Show("Некорректный email!");
                    return;
                }

                var id = entities.Clients.Max(x => x.Id) + 1;
                if (client.Id == 0)
                {
                    client.Id = id;
                    client.FirstName = FirstNameInput.Text;
                    client.LastName = LastNameInput.Text;
                    client.MiddleName = MiddleNameInput.Text;
                    client.Phone = PhoneInput.Text;
                    client.Email = EmailInput.Text;

                    entities.Clients.Add(client);
                    entities.SaveChanges();

                    DialogResult = true;
                }
                else
                {
                    client.FirstName = FirstNameInput.Text;
                    client.LastName = LastNameInput.Text;
                    client.MiddleName = MiddleNameInput.Text;
                    client.Phone = PhoneInput.Text;
                    client.Email = EmailInput.Text;
                    entities.SaveChanges();

                    DialogResult = true;
                }
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void PhoneInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
