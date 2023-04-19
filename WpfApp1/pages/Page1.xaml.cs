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

namespace WpfApp1.pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1(List<MainWindow.User> users)
        {
          InitializeComponent();
          dgUsers.ItemsSource = (System.Collections.IEnumerable)users;
        }

  //     private void InitializeComponent()
  //     {
  //         throw new NotImplementedException();
  //     }

       private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           MessageBox.Show("clicgriddata");
       }
    }
}
