using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
using WebApiMiniPj.Modeles;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using WpfApp1.pages;
using WpfApp1;

using System.Net.Http.Json;
using System.Collections;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
using System.Windows.Navigation;
using WpfApp1.pages;

using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections;
using Azure;

namespace WpfApp1.pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        string str;
        string str2;
        string usermode;
        public string sqlcon;

        HttpClient client = new HttpClient();

        public Page2()
        {
                       InitializeComponent();           
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public object NavigationService { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int usrchk = 0;
            string sqlcon = ("Data Source=LAP-2023-LUX3\\SQLEXPRESS;" +
            "User ID=skillquizusr;" +
                "Password=SkillQuiz5!;" +
                "Initial Catalog=skillquizdb;" +
                "Encrypt = False;" +
                "Integrated Security=True;");
            SqlConnection myConnection = new SqlConnection(sqlcon);

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("select * from [skillquizdb].[dbo].[Usr] where LoginTxt = '" + str.ToString() + "'", myConnection);

            SqlDataReader myReader = myCommand.ExecuteReader();
            myReader.Read();

            //          MessageBox.Show("message-1");
            client.BaseAddress = new Uri("http://localhost:5093");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/api/Usr").Result;

            try
            {
                string strBdd = myReader["LoginTxt"].ToString();

                // MessageBox.Show(myReader["LoginId"].ToString());
                if (str != strBdd)
                {
                    usrchk = 0;
                    MessageBox.Show("message-f");
                }
                else
                {
                    //                   MessageBox.Show("message-t");
                    str2 = passwordBox1.Password;
                    //                MessageBox.Show("messagebt");
                    if (str2 == myReader["PasswordTxt"].ToString())
                    {
                        usrchk = 1;
                        //                        this.Navigate("pages/Page1.xaml");
                        //                        Uri uri = new Uri("pages/Page1.xaml", UriKind.Relative);
                        //                        this.Navigate(uri);
                        //                        Uri uri = new Uri("pages/Page1.xaml", UriKind.Relative);
                        //                        NavigationService ns = NavigationService.GetNavigationService(this);
                        //                        frame.Navigate(uri);
                        //                        this.NavigationService.Refresh();
                        //                        ns.Navigate(uri);

                        //                    MessageBox.Show("messageap");


                        //                        MessageBox.Show("message0");
                        if (response.IsSuccessStatusCode)
                        {
                            //                          MessageBox.Show("message1" );

                            //Add ref System.Net.Http.Formatting.dll => search formatting
                            //                          MessageBox.Show("message10" + str);


                            //                            var usrList = await response.Content.ReadAsAsync<IEnumerable<Usr>>();

                            // Parse the response body.
                            //var param1 = response.Content.ReadAsAsync<IEnumerable<ParameterType>>().Result.First();
                            //var parameter = response.Content.ReadAsAsync<ParameterType>().Result;
                            //invoiceFolder = parameter.Value;
                            //EmployeeList.Where()
                            //                           string message = string.Empty;
                            //                          MessageBox.Show("message11"+ str);
                            //                          Usr usrlist = usrList.Where(x => x.LastName == str).FirstOrDefault();

                            // message = usrlogged.FirstOrDefault() + Environment.NewLine;

                            //message = usrlist.LastName;
                            string usridbdd = myReader["TypeUserId"].ToString();
                            usermode = "candidat";
                            if (usridbdd == "1")                          
                            {
                                usermode = "admin";
                            };

                            MessageBox.Show("cnx user : " + str);

                            this.Navigate("pages/Page1.xaml");

                            if (usridbdd == "1")                            
                            {
                                //                                                            this.Content = new Page1();

                                this.Navigate("pages/Page1.xaml");



                               //             this.Content = new Page1(usrList.ToList());

                                // users.Add(new User() { Name = usrlist.LastName });
                                //users.Add(new User() { Name = message });
                                //users.Add(new User() { Name = usrList.ToString() });
                                //users.Add(new User() { Name = usrlist.ToString() });
                                //users.Add(new User() { Name = usrList.All<> });
                            }
                            else
                            {
                                //             DataGridDetailsSample dgs = new DataGridDetailsSample(usrlist.FirstName);
                                //             dgs.Title = "test de : " + usrlist.FirstName;
                                //                                dgs.Show();                                
                            }

                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            MessageBox.Show("Error : (" + response.StatusCode + ") " + response.ReasonPhrase);
                        }

                        MessageBox.Show("you are logged in " + usermode);

                        return;

                        //                        this.Close();
                    }
                    else
                    {
                        usrchk = 2;
                        MessageBox.Show("Mot de passe inconnu");
                        return;
                    }

                }


                //  MessageBox.Show(myReader["LoginTxt"].ToString());
                //               this.Content = new Page1();
                // myReader.Read();

                if (usrchk == 2)
                {
                    MessageBox.Show("Mot de passe inconnu");
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                if (usrchk == 0)
                {
                    MessageBox.Show("Utilisateur inconnu");
                }
            }
        }

        private void Navigate(string page)
        {
//            this.Navigate(page);
            MainWindow.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            str = tb.Text;
        }

        public class User
        {
            public string Name { get; set; }

            public string Details
            {
                get
                {
                    return String.Format("{0} was born on {1} and this is a long description of the person.", this.Name);
                }
            }
        }
    }
}
