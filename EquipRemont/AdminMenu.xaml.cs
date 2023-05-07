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
            //вставка данных в dataGrid
            InitializeComponent();
            dgOrder.ItemsSource = db.Orders.ToList();
            dgRem.ItemsSource = db.Orders.Where(x => x.Answer_id == 3).ToList();
            dgUser.ItemsSource = db.Users.ToList();
        }

        private void answSave_Click(object sender, RoutedEventArgs e)
        {
            //изменение для ответа
            if (dgOrder.SelectedItem != null)
            {
                EditComboBox eCB = new EditComboBox();
                eCB.answerCB.ItemsSource = db.Answer.ToList();
                eCB.ShowDialog();

                if (eCB.DialogResult == true)
                {
                    var order = dgOrder.SelectedItem as Orders;
                    order.Answer_id = Convert.ToInt32(eCB.answerCB.SelectedValue);
                    db.SaveChanges();
                    dgOrder.ItemsSource = db.Orders.ToList();
                    dgRem.ItemsSource = db.Orders.Where(x => x.Answer_id == 3).ToList();
                }
            }

        }

        private void statSave_Click(object sender, RoutedEventArgs e)
        {
            //изменение для статуса
            if (dgRem.SelectedItem != null)
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
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //выход по кнопке L
            if(e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            dgUser.ItemsSource = db.Users.Where(x => x.Surname.Contains(searchT.Text)).ToList();
        }

        private void editB_Click(object sender, RoutedEventArgs e)
        {
            if(dgUser.SelectedItem != null)
            {
                Users us = (Users)dgUser.SelectedItem;
                EditUser eU = new EditUser(us);
                if(eU.ShowDialog() == true)
                {
                    us.Surname = eU.surnameT.Text;
                    us.Name = eU.nameT.Text;
                    us.Login = eU.loginT.Text;
                    us.Password= eU.passwordT.Text;
                    db.SaveChanges();
                    dgUser.ItemsSource = db.Users.Where(x => x.Surname.Contains(searchT.Text)).ToList();
                }
            }
        }

        private void delB_Click(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedItem != null)
            {
                Users us = (Users)dgUser.SelectedItem;
                if (us.Login != "admin")
                {
                    db.Users.Remove(us);
                    db.SaveChanges();
                    dgUser.ItemsSource = db.Users.Where(x => x.Surname.Contains(searchT.Text)).ToList();
                }
                else MessageBox.Show("Не удаляй админа");
            }
        }
    }
}
