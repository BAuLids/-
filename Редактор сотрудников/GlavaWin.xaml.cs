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
    /// Логика взаимодействия для GlavaWin.xaml
    /// </summary>
    public partial class GlavaWin : Window, INotifyPropertyChanged

    {
        private Glava selectedGlava;
        public Glava SelectedGlava
        {
            get => selectedGlava;
            set
            {
                selectedGlava = value;
                Signal();
            }
        }
        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public GlavaWin()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<Glava> Glavas
        {
            get => Data.Glavas;
        }

        private void AddGlava(object sender, RoutedEventArgs e)
        {
            Glavas.Add(new Glava { LastName = "Новый руководитель" });
        }

        private void DeleteGlava(object sender, RoutedEventArgs e)
        {
            if (SelectedGlava == null)
                return;
            if (MessageBox.Show("Вы хотите удалить выбранного руководителя?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Glavas.Remove(SelectedGlava);
            }
        }
    }
}
