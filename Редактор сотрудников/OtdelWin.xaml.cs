using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Редактор_сотрудников
{
    /// <summary>
    /// Логика взаимодействия для OtdelWin.xaml
    /// </summary>
    public partial class OtdelWin : Window, INotifyPropertyChanged
    {
        private Otdel selectedOtdel;

        public Otdel SelectedOtdel
        {
            get => selectedOtdel;
            set
            {
                selectedOtdel = value;
                Signal();
            }
        }

            void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Otdel> Otdels
        {
            get => Data.Otdels;
        }
        public ObservableCollection<Glava> Glavas
        {
            get => Data.Glavas;
        }
        public ObservableCollection<Position> Positions
        {
            get => Data.Positions;
        }
        public OtdelWin()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void AddOtdel(object sender, RoutedEventArgs e)
        {
            Otdels.Add(new Otdel { Title = "Новый отдел" });
        }

        private void DeleteOtdel(object sender, RoutedEventArgs e)
        {
            if (SelectedOtdel == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный отдел?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Otdels.Remove(SelectedOtdel);
            }
        }

    }
}
