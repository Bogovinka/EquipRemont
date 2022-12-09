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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            DatabaseREntities db = new DatabaseREntities();
            if (loginT.Text != "" && passwordT.Text != "" && surnameT.Text != "" && nameT.Text != ""
                && db.Users.Where(x => x.Login == loginT.Text).Count() == 0)
            {
                DialogResult = true;
            }
            else MessageBox.Show("Заполни все поля или такой логин уже есть");
        }
    }
}
