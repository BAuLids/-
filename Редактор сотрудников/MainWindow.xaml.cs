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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Редактор_сотрудников
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Sotrudnic selectedSotrudnic;

        public ObservableCollection<Sotrudnic> Sotrudnics
        {
            get => Data.Sotrudnics;
        }

        public Sotrudnic SelectedSotrudnic
        {
            get => selectedSotrudnic;
            set
            {
                selectedSotrudnic = value;
                Signal();
            }
        }
        public ObservableCollection<Otdel> Otdels
        {
            get => Data.Otdels;
        }
        public ObservableCollection<Position> Positions
        {
            get => Data.Positions;
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void AddSotrudnic(object sender, RoutedEventArgs e)
        {
            Sotrudnics.Add(new Sotrudnic
            {
                LastName = "Новый сотрудник",
                Birthday = DateTime.Today
            });
        }

        private void DeleteSotrudnic(object sender, RoutedEventArgs e)
        {
            if (SelectedSotrudnic == null)
                return;
            if (MessageBox.Show("Вы хотите удалить выбранного сотрудника?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Sotrudnics.Remove(SelectedSotrudnic);
                SelectedSotrudnic = null;
            }
        }

        private void OpenOtdel(object sender, RoutedEventArgs e)
        {
            OtdelWin win = new OtdelWin();
            win.ShowDialog();
        }

        private void OpenGlava(object sender, RoutedEventArgs e)
        {
            GlavaWin win = new GlavaWin();
            win.ShowDialog();
        }

        private void OpenPosition(object sender, RoutedEventArgs e)
        {
            PositionWin win = new PositionWin();
            win.ShowDialog();
        }
    }
}
