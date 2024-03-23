using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database.Entities entities = new Database.Entities();
        public MainWindow()
        {
            InitializeComponent();

            ClientsOutput.ItemsSource = entities.Clients.ToList();
            AgentsOutput.ItemsSource = entities.Agents.ToList();
        }

        private void ClientsButtom_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow.Visibility = Visibility.Visible;
            AgentsWindow.Visibility = Visibility.Hidden;
        }

        private void AgentsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow.Visibility = Visibility.Hidden;
            AgentsWindow.Visibility = Visibility.Visible;
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            WindowGroup.AddClientWindow addClientWindow = new WindowGroup.AddClientWindow(entities, new Database.Clients());
            if (addClientWindow.ShowDialog() == true)
            {
                FindClientinput_TextChanged(null, null);
            }
        }

        private void ReplaseClientButton_Click(object sender, RoutedEventArgs e)
        {
            var rowSelected = ClientsOutput.SelectedItem as Database.Clients;

            if (rowSelected == null)
            {
                MessageBox.Show("Не выбрана строка для редактирования!");
            }
            else
            {
                WindowGroup.AddClientWindow addClientWindow = new WindowGroup.AddClientWindow(entities, rowSelected);
                if (addClientWindow.ShowDialog() == true)
                {
                    FindClientinput_TextChanged(null, null);
                }
            }
        }

        private void RemoveClientButton_Click(object sender, RoutedEventArgs e)
        {
            var rowSelected = ClientsOutput.SelectedItem as Database.Clients;

            if(rowSelected == null)
            {
                MessageBox.Show("Не выбрана строка для удаления!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите " +
                    "удалить клиента?", "Уведомление!", MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    if(rowSelected.ObjectDemands.Count() == 0 && 
                        rowSelected.Deal.Count() == 0)
                    {
                        entities.Clients.Remove(rowSelected);
                        entities.SaveChanges();
                        FindClientinput_TextChanged(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Данный клиент не может быть удален," +
                            "\nтак как имеет дополнительные записи!", "Ошибка!",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void AddAgentButton_Click(object sender, RoutedEventArgs e)
        {
            WindowGroup.AddAgentWindow addAgentWindow = new WindowGroup.AddAgentWindow(entities, new Database.Agents());
            if (addAgentWindow.ShowDialog() == true)
            {
                FindAgentInput_TextChanged(null, null);
            }
        }

        private void ReplaseAgentButton_Click(object sender, RoutedEventArgs e)
        {
            var rowSelected = AgentsOutput.SelectedItem as Database.Agents;

            if (rowSelected == null)
            {
                MessageBox.Show("Не выбрана строка для редактирования!");
            }
            else
            {
                WindowGroup.AddAgentWindow addAgentWindow = new WindowGroup.AddAgentWindow(entities, rowSelected);
                if (addAgentWindow.ShowDialog() == true)
                {
                    FindAgentInput_TextChanged(null, null);
                }
            }
        }

        private void RemoveAgentButton_Click(object sender, RoutedEventArgs e)
        {
            var rowSelected = AgentsOutput.SelectedItem as Database.Agents;

            if (rowSelected == null)
            {
                MessageBox.Show("Не выбрана строка для удаления!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите " +
                    "удалить риэлтора?", "Уведомление!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    if (rowSelected.ObjectDemands.Count() == 0 &&
                        rowSelected.Deal.Count() == 0)
                    {
                        entities.Agents.Remove(rowSelected);
                        entities.SaveChanges();
                        FindAgentInput_TextChanged(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Данный клиент не может быть удален," +
                            "\nтак как имеет дополнительные записи!", "Ошибка!",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void FindClientinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = FindClientinput.Text;

            if (text == string.Empty)
            {
                ClientsOutput.ItemsSource = entities.Clients.ToList();
            }
            else
            {
                ClientsOutput.ItemsSource = entities.Clients
                    .Where(x => x.FirstName.Contains(text) ||
                    x.MiddleName.Contains(text) ||
                    x.LastName.Contains(text))
                    .ToList();
            }
        }

        private void FindAgentInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = FindAgentInput.Text;

            if (text == string.Empty)
            {
                AgentsOutput.ItemsSource = entities.Agents.ToList();
            }
            else
            {
                AgentsOutput.ItemsSource = entities.Agents
                    .Where(x => x.FirstName.Contains(text) ||
                    x.MiddleName.Contains(text) ||
                    x.LastName.Contains(text))
                    .ToList();
            }
        }
    }
}
