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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        DatabaseREntities db = new DatabaseREntities();
        public AdminMenu()
        {
            InitializeComponent();
            dgOrder.ItemsSource = db.Orders.ToList();
            dgRem.ItemsSource = db.Orders.Where(x => x.Answer_id == 3).ToList();
            dgUser.ItemsSource = db.Users.ToList();
        }

        private void answSave_Click(object sender, RoutedEventArgs e)
        {
            EditComboBox eCB = new EditComboBox();
            eCB.answerCB.ItemsSource = db.Answer.ToList();
            eCB.ShowDialog();
            
            if(eCB.DialogResult == true)
            {
                var order = dgOrder.SelectedItem as Orders;
                order.Answer_id = Convert.ToInt32(eCB.answerCB.SelectedValue);
                db.SaveChanges();
                dgOrder.ItemsSource = db.Orders.ToList();
                dgRem.ItemsSource = db.Orders.Where(x => x.Answer_id == 3).ToList();
            }

        }

        private void statSave_Click(object sender, RoutedEventArgs e)
        {
            EditComboBox eCB = new EditComboBox();
            eCB.answerCB.ItemsSource = db.Status.ToList();
            eCB.ShowDialog();
            
            if (eCB.DialogResult == true)
            {
                var order = dgRem.SelectedItem as Orders;
                order.Status_id = Convert.ToInt32(eCB.answerCB.SelectedValue);
                db.SaveChanges();
                dgOrder.ItemsSource = db.Orders.ToList();
                dgRem.ItemsSource = db.Orders.Where(x => x.Answer_id == 3).ToList();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
