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
    public partial class recovery : Form
    {

        public float rec;
        public recovery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            summarysave("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
            summarysave("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
            this.Close();
           
        }

        private void summarysave(string v)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Recover Amount");
            }
            else
            {
                //string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(v);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO summary(date,totalinward,totaloutward,totalbag,totalloss,totaletc,totalnet,recovery) VALUES(?date,?totalinward,?totaloutward,?totalbag,?totalloss,?totaletc,?totalnet,?recovery)";
                    cmd.Parameters.Add("?date", MySqlDbType.VarChar).Value = DateTime.Now.ToString("dd.MM.yyyy hh:mm tt");
                    cmd.Parameters.Add("?totalinward", MySqlDbType.VarChar).Value = InwardOutward.netinward;
                    cmd.Parameters.Add("?totaloutward", MySqlDbType.VarChar).Value = InwardOutward.netoutward;
                    cmd.Parameters.Add("?totalbag", MySqlDbType.VarChar).Value = InwardOutward.netbag;
                    cmd.Parameters.Add("?totalloss", MySqlDbType.VarChar).Value = InwardOutward.netloss;
                    cmd.Parameters.Add("?totaletc", MySqlDbType.VarChar).Value = InwardOutward.netetc;
                    cmd.Parameters.Add("?totalnet", MySqlDbType.VarChar).Value = InwardOutward.netnet;
                    cmd.Parameters.Add("?recovery", MySqlDbType.VarChar).Value = textBox1.Text;



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                    //disp();
                   


                }

                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
                finally
                {
                    con.Close();
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Aqua;
           
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }
    }
}
