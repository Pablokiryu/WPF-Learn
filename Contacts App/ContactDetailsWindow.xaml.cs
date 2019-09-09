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
using SQLite;
using Contacts_App.Classes;

namespace Contacts_App
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact C;
        public ContactDetailsWindow(Contact c)
        {
            InitializeComponent();
            this.C = c;
            nameTextBox.Text = C.Name;
            phoneTextBox.Text = C.Phone;
            emailTextBox.Text = C.Email;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            C.Name = nameTextBox.Text;
            C.Phone = phoneTextBox.Text;
            C.Email = emailTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(C);
            }

            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(C);
            }
            Close();

        }
    }
}
