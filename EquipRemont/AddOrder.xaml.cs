using System;
using System.Collections.Generic;
using System.Linq;
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

namespace EquipRemont
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            //проверка на поля
            if (EqupT.SelectedIndex > -1 && comentT.Text != "")
                DialogResult = true;
            else MessageBox.Show("Заполни все поля");
        }
    }
}
