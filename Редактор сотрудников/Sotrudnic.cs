using System;
using System.Collections.Generic;
using System.Text;

namespace Редактор_сотрудников
{
    public class Sotrudnic
    {
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public double Seria { get; set; }
        public double Nomer { get; set; }

        public Otdel Otdel { get; set; }
        public Position Position { get; set; }
    }
}
