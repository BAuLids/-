using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Редактор_сотрудников
{
    static class Data
    {
        public static ObservableCollection<Sotrudnic> Sotrudnics = new ObservableCollection<Sotrudnic>();
        public static ObservableCollection<Otdel> Otdels = new ObservableCollection<Otdel>();
        public static ObservableCollection<Glava> Glavas = new ObservableCollection<Glava>();
        public static ObservableCollection<Position> Positions = new ObservableCollection<Position>();

    }
}
