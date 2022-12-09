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
    /// Логика взаимодействия для EditComboBox.xaml
    /// </summary>
    public partial class EditComboBox : Window
    {
        public EditComboBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(answerCB.SelectedIndex > -1)
                DialogResult = true;
        }
    }
}
