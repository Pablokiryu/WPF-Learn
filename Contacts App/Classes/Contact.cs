using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App.Classes
{
<<<<<<< HEAD
    public class Contact
=======
    class Contact
>>>>>>> master
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
<<<<<<< HEAD
        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }

    
=======
    }
>>>>>>> master
}
