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
    /// Логика взаимодействия для PositionWin.xaml
    /// </summary>
    public partial class PositionWin : Window, INotifyPropertyChanged
    {
        private Position selectedPosition;
        public Position SelectedPosition
        {
            get => selectedPosition;
            set
            {
                selectedPosition = value;
                Signal();
            }
        }
        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public PositionWin()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<Position> Positions
        {
            get => Data.Positions;
        }
        private void AddPosition(object sender, RoutedEventArgs e)
        {
            Positions.Add(new Position { Title = "Новая должность" });
        }

        private void DeletePosition(object sender, RoutedEventArgs e)
        {
            if (SelectedPosition == null)
                return;
            if (MessageBox.Show("Вы хотите удалить выбранную должность?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Positions.Remove(SelectedPosition);
            }
        }
    }
}
