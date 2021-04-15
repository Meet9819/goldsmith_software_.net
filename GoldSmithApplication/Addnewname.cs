using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GoldSmithApplication
{
    public partial class Addnewname : Form
    {
        public Addnewname()
        {
            InitializeComponent();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtname.Text = "hello ";
            txtemail.Text = "hello";
            txtcontact.Text = "hello";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            insert("Server=localhost;port=3306;Database=Goldsmith;Uid='root';");
            insert("Server = 148.72.232.171; port = 3306; Database = goldsmith; username = 'goldsmith'; Password = 'loveyoudad9820102993'");
        }



        void insert(string str)
        {

            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Customer name cannot be blank");
            }
            else
            {
                //string constring = AppSetting.ConnectionString(1);
                //MySqlConnection con = new MySqlConnection(constring);
                MySqlConnection con = new MySqlConnection(str);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO  clientcontact(name,contact,email) VALUES(?name,?contact,?email)";
                    cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = txtname.Text;
                    cmd.Parameters.Add("?contact", MySqlDbType.VarChar).Value = txtcontact.Text;
                    cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = txtemail.Text;


                    MessageBox.Show("Inserted Successfully");
                    cmd.ExecuteNonQuery();
                    clear();
                    con.Close();
                    this.Close();
                }

                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            }
        }
        void clear()
        {
            txtname.Text = txtcontact.Text = txtemail.Text = "";

        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
