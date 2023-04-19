using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
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
using WebApiMiniPj.Modeles;
using System.Collections;
//using static WpfApp1.MainWindow;
//using static WpfApp1.pages.Page1;

namespace WpfApp1


{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str;
        string str2;

        public object NavigationService { get; private set; }
        HttpClient client = new HttpClient();

        public MainWindow()
        {
   
            //            _NavigationFrame.Navigate(new Page1());

            //           MessageBox.Show("tb.Text");
            InitializeComponent();

            //string sqlcon = ("Data Source=LAP-2023-LUX3\\SQLEXPRESS;" +
            //     "User ID=skillquizusr;" +
            //"Password=SkillQuiz5!;" +
            //    "Initial Catalog=skillquizdb;" +
            //"Encrypt = False;" +
            //   "Integrated Security=True;");

            //SqlConnection myConnection = new SqlConnection(sqlcon);

            //myConnection.Open();

            //            SqlCommand myCommand = new SqlCommand("select * from usr" , myConnection);
            //SqlCommand myCommand = new SqlCommand("select * from usr", myConnection);

            //          SqlCommand myCommand = new SqlCommand("select * from usr", myConnection);
            //SqlDataReader myReader = myCommand.ExecuteReader();
            //try
            //{

            //myCommand.ExecuteNonQuery();

            //                myCommand.CommandText = "select * from usr";

            //while (myReader.Read())
            //{
            //Console.WriteLine(myReader["firstname"].ToString());
            //Console.WriteLine(myReader["age"].ToString());
            //}
            //}
            //catch (Exception e)
            //{
            //Console.WriteLine(e.ToString());
            //}
            //finally
            //{
            //myReader.Close();
            //myConnection.Close();
            //            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int usrchk = 0;
            string sqlcon = (   "Data Source=LAP-2023-LUX3\\SQLEXPRESS;" +
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
                        client.BaseAddress = new Uri("http://localhost:5093");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.GetAsync("/api/Usr").Result;

//                        MessageBox.Show("message0");

                        if (response.IsSuccessStatusCode)
                        {

                            //                          MessageBox.Show("message1" );

                            //Add ref System.Net.Http.Formatting.dll => search formatting
                            //                          MessageBox.Show("message10" + str);
                            // IList<Usr> usr = response.Content.ReadAsAsync<IList<Usr>>().Result;
                            var usrList = await  response.Content.ReadAsAsync<IEnumerable<Usr>>();
                            // Parse the response body.
                            //var param1 = response.Content.ReadAsAsync<IEnumerable<ParameterType>>().Result.First();
                            //var parameter = response.Content.ReadAsAsync<ParameterType>().Result;
                            //invoiceFolder = parameter.Value;
                            //EmployeeList.Where()
                            string message = string.Empty;
  //                          MessageBox.Show("message11"+ str);
                            Usr usrlist = usrList.Where(x => x.LastName == str).FirstOrDefault();
                            
                            // message = usrlogged.FirstOrDefault() + Environment.NewLine;
                            message = usrlist.LastName;

                            MessageBox.Show("message : " + message);

                            //                            DataGridDetailsSample dgs = new DataGridDetailsSample(usrlist.FirstName);
                            //                            dgs.Title = "toto";                          
                            //                            dgs.Show();

                            //                            this.Content = new Page1();

                            List<User> users = new List<User>();
                            
                            this.Content = new Page1(usrList.ToList());

                           // users.Add(new User() { Name = usrlist.LastName });
                            //users.Add(new User() { Name = message });
                            //users.Add(new User() { Name = usrList.ToString() });
                            //users.Add(new User() { Name = usrlist.ToString() });
                            //users.Add(new User() { Name = usrList.All<> });


                            //                       page.NavigationService.Navigate(page, message); 

                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            MessageBox.Show("Error : (" + response.StatusCode + ") " + response.ReasonPhrase);
                        }

                        MessageBox.Show("messagesp");

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            str = tb.Text;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

//            NavigationService ns = NavigationService.GetNavigationService(this);
//            ns.Navigate("pages/Page1.xaml");
//            this.NavigationService.Navigate(new Uri("pages/Page1.xaml", UriKind.Relative));
//            this.Content = new Page1();
        }

       

        public partial class DataGridDetailsSample : Window
        {
        
            public DataGridDetailsSample(string usrList)
            {
 //               InitializeComponent();
 //               this.Content = new Page1();
                // MessageBox.Show(message);
                //                            MessageBox.Show(usr.All().FirstName);
                //  MessageBox.Show(usr.FirstOrDefault().FirstName);
                //                            var Page1 = sender as Page1;
                List<User> users = new List<User>();
                //                           users.Add(new User() {  Name = usrlist.LastName });
                //                            users.Add(new User() {  Name = usrlist.LastName });
                users.Add(new User() { Name = "Sammy Doe" });
                //                            Page1.DataGrid.ToString()="usr";
                //                            Page1 = usr.LastName;
//                dgUsers.ItemsSource = users;
            }
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