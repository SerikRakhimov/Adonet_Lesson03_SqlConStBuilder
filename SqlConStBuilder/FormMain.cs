using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlConStBuilder
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder SqlConnBuild = new SqlConnectionStringBuilder();
 
            if (textBoxLogin.Text != "" && textBoxPassword.Text != "")
            {
                SqlConnBuild.DataSource = @"(LocalDb)\MSSQLLocalDB";
                SqlConnBuild.InitialCatalog = "InternetShop.DataContext";
                SqlConnBuild.IntegratedSecurity = true;
                SqlConnBuild.UserID = textBoxLogin.Text;
                SqlConnBuild.Password = textBoxPassword.Text;
                SqlConnection con = new SqlConnection(SqlConnBuild.ConnectionString);
                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                        MessageBox.Show("Успешное подключение!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сообщение: " + "\n" + ex.Message);
                }
                finally
                {
                    con?.Close();
                }

            }
        }
    }
}
