using RealEstateAgency.Database;
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
using System.Windows.Shapes;

namespace RealEstateAgency.WindowGroup
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        Entities entities;
        Agents agent;
        public AddAgentWindow(Entities entities, Agents agent)
        {
            InitializeComponent();
            this.entities = entities;

            if (agent.Id != 0)
            {
                FirstNameInput.Text = agent.FirstName;
                LastNameInput.Text = agent.LastName;
                MiddleNameInput.Text = agent.MiddleName;
                DealShareInput.Text = agent.DealShare.ToString();
            }

            this.agent = agent;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameInput.Text == string.Empty ||
                LastNameInput.Text == string.Empty ||
                DealShareInput.Text == string.Empty ||
                MiddleNameInput.Text == string.Empty)
            {
                MessageBox.Show("Не все данные введены!");
            }
            else
            {
                try
                {
                    var dealShare = Convert.ToInt32(DealShareInput.Text);
                    if (dealShare <= 0 || dealShare >= 100)
                    {
                        MessageBox.Show("Процент от сделки должен лежать в диапазоне от 0 до 100!");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Некорректный процент от сделки!");
                    return;
                }

                var id = entities.Agents.Max(x => x.Id) + 1;
                if (agent.Id == 0)
                {
                    agent.Id = id;
                    agent.FirstName = FirstNameInput.Text;
                    agent.LastName = LastNameInput.Text;
                    agent.MiddleName = MiddleNameInput.Text;
                    agent.DealShare = Convert.ToInt32(DealShareInput.Text);

                    entities.Agents.Add(agent);
                    entities.SaveChanges();

                    DialogResult = true;
                }
                else
                {
                    agent.FirstName = FirstNameInput.Text;
                    agent.LastName = LastNameInput.Text;
                    agent.MiddleName = MiddleNameInput.Text;
                    agent.DealShare = Convert.ToInt32(DealShareInput.Text);
                    entities.SaveChanges();

                    DialogResult = true;
                }
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DealShareInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
