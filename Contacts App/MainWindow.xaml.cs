using Contacts_App.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Contacts_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                var contacts = connection.Table<Contact>().ToList();

            }

        }
    }
}
