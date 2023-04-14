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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str;
        string str2;
        public MainWindow()
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
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

            try
            {
                string strbdd = myReader["LoginTxt"].ToString();

                // MessageBox.Show(myReader["LoginId"].ToString());
                if (str != strbdd)
                {
                    usrchk = 0;
                }
                else
                {
                    str2 = passwordBox1.Password;
                    if (str2 == myReader["PasswordTxt"].ToString())
                    {
                        this.Close();
                        usrchk = 1;
                        return;
                    }
                    else
                    {
                        usrchk = 2;
                        MessageBox.Show("Mot de passe inconnu");
                        return;
                    }
                }

                //  MessageBox.Show(myReader["LoginTxt"].ToString());
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

    }
}