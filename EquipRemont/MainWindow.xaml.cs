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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipRemont
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DatabaseREntities db = new DatabaseREntities();
        private void regB_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.ShowDialog();
            if(r.DialogResult == true)
            {
                Users user = new Users()
                {
                    Surname = r.surnameT.Text,
                    Name = r.nameT.Text,
                    Login = r.loginT.Text,
                    Password = r.passwordT.Text,
                    Type_acc = 2
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            if (db.Users.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).Count() > 0)
            {
                Users user = db.Users.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).FirstOrDefault();
                if (user.Type_acc == 1)
                {
                    AdminMenu am = new AdminMenu();
                    am.Show();
                    Close();
                }
                else if (user.Type_acc == 2)
                {

                }
            }
            else MessageBox.Show("Ошибка в логине или пароле");
        }
    }
}
