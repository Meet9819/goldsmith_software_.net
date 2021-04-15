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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(constring);

           
                con.Open();
            
            /*catch (MySqlException exe)
            {
                MessageBox.Show(exe.Message);
            }*/
            

            if(con.State == ConnectionState.Open)
            {
                InwardOutward abc = new InwardOutward();
                MessageBox.Show("ConnectionSuccessful");
                this.Hide();
                abc.Show();
            }
            else
            {
                MessageBox.Show("Connection failed");
            }
        }

        private void elloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InwardOutward inout = new InwardOutward();
            inout.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            // pictureBox1 pc = new pictureBox1
            //this.panel1.Controls.Add(item);
            this.pictureBox1.Show();

           

        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            
            ItemMaster it = new ItemMaster()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
           // item.FormBorderStyle = FormBorderStyle.;
            this.panel1.Controls.Add(it);
            it.Show();
            


        }

        private void inwardOutwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
           

            InwardOutward inout = new InwardOutward()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
           // inout.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(inout);
            
            inout.Show();
            if (inout.party.Focused)
            {
               // MessageBox.Show("Focused");
            }
            else
            {
                inout.party.Focus();
                //MessageBox.Show(" Not Focused");
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
           

            Userdetails usrdtl = new Userdetails()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            // inout.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(usrdtl);

            usrdtl.Show();
           
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();


            Summary usrdtl = new Summary()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            // inout.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(usrdtl);

            usrdtl.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
