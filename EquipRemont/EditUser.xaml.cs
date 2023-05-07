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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser(Users us)
        {
            InitializeComponent();
            surnameT.Text = us.Surname;
            nameT.Text = us.Name;
            loginT.Text = us.Login;
            passwordT.Text = us.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (surnameT.Text != "" && nameT.Text != "" && loginT.Text != "" && passwordT.Text != "") DialogResult = true;
        }
    }
}
