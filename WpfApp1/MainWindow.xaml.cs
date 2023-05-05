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

        public MainWindow()
        {

            //            _NavigationFrame.Navigate(new Page1());

            //           MessageBox.Show("tb.Text");
             InitializeComponent();

            this.Navigate("pages/Page2.xaml"); // this.Content = new Page2();

            // this.Navigate("pages/Page2.xaml");

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

        }

        public void Navigate(string page)
        {
            MainFrame.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
//            MessageBox.Show("Menu2");
            this.Navigate("pages/Page3.xaml");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
 //           MessageBox.Show("Menu3");
            this.Navigate("pages/Page1.xaml");
        }

//        internal static void Navigate(Uri uri)
//       {
//           MessageBox.Show("Coucou");
            //throw new NotImplementedException();
//            MainFrame.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
//        }
    }
}