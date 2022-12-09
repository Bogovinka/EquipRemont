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
    /// Логика взаимодействия для ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Window
    {
        DatabaseREntities db = new DatabaseREntities();
        int idU;
        public ClientMenu(int id)
        {
            //заполнение dataGrid
            InitializeComponent();
            idU = id;
            dgOrder.ItemsSource = db.Orders.Where(x => x.User_id == idU).ToList();
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            //добавление нового заказа
            AddOrder aO = new AddOrder();
            aO.EqupT.ItemsSource = db.Equipment.ToList();
            aO.ShowDialog();
            if(aO.DialogResult == true)
            {
                Orders order = new Orders()
                {
                    Equipment_id = Convert.ToInt32(aO.EqupT.SelectedValue),
                    User_id = idU,
                    Comment = aO.comentT.Text,
                    Answer_id = 1,
                    Status_id = 1,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                dgOrder.ItemsSource = db.Orders.Where(x => x.User_id == idU).ToList();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //выход
            if(e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
