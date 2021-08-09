using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonal
    {
        private int id;
        private string name;
        private string surname;
        private string city;
        private string mission;
        private short wage;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string City { get => city; set => city = value; }
        public string Mission { get => mission; set => mission = value; }
        public short Wage { get => wage; set => wage = value; }
    }
}
