using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebApiMiniPj.Modeles;
using static WpfApp1.pages.Page2;

namespace WpfApp1.pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        HttpClient client = new HttpClient();
        public Page1() //{ }
 //       public Page1(List<Usr> users)
        {
          InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:5093");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/api/Usr").Result;
            if (response.IsSuccessStatusCode)
            {

                //Add ref System.Net.Http.Formatting.dll => search formatting

//                List<User> users = new List<User>();
//                List<Usr> UsrList = new List<Usr>();

                var UsrList = response.Content.ReadAsAsync<IEnumerable<Usr>>().Result;

                dgUsers.ItemsSource = UsrList;



                // Parse the response body.
                //var param1 = response.Content.ReadAsAsync<IEnumerable<ParameterType>>().Result.First();
                //var parameter = response.Content.ReadAsAsync<ParameterType>().Result;
                //invoiceFolder = parameter.Value;
                //EmployeeList.Where()

                //                MessageBox.Show(UsrList.ToString());

//                                        NavigationService ns = NavigationService.GetNavigationService(this);
                //                        frame.Navigate(uri);
//                                        this.NavigationService.Refresh();

            }
            else
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show("Error : (" + response.StatusCode + ") " + response.ReasonPhrase);
            }

            IList<Usr> usr = response.Content.ReadAsAsync<IList<Usr>>().Result;
                                  
        }

  //     private void InitializeComponent()
  //     {
  //         throw new NotImplementedException();
  //     }

       private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           MessageBox.Show("clicgriddata");
       }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("clicgriddatachg" + " - " + e.ToString()+" - "+sender.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("clicgriddatachg" + " - " + e.ToString() + " - " + sender.ToString());
            HttpResponseMessage response = client.GetAsync("/api/Usr").Result;

        }
    }
}
