using Contacts_App.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Contacts_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
          NewContactsWindow newContactsWindow = new NewContactsWindow();
            newContactsWindow.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {           
            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = (connection.Table<Contact>().ToList()).OrderBy(c=>c.Name).ToList();


            }
            if (contacts != null)
            {
                contactListView.ItemsSource = contacts;
            }

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox searchTextbox = sender as TextBox;
            var filteredList = contacts.Where(c => c.ToString().ToLower().Contains(searchTextbox.Text.ToLower())).ToList();
            contactListView.ItemsSource = filteredList;

            //Complete linQ query. same as above.
            //var fileteredList2 = (from c2 in contacts
            //                      where c2.Name.ToLower().Contains(searchTextbox.Text.ToLower())
            //                      orderby c2.Email
            //                      select c2).ToList();
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactListView.SelectedItem;
            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow( selectedContact );
                contactDetailsWindow.ShowDialog();
                ReadDatabase();
            }
        }
    }
}