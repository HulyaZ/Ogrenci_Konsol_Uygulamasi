using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciUygulamasi
{
    public class PersonData :Adress
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public PersonData()
        {

        }

        public PersonData(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }

      

    }
}
