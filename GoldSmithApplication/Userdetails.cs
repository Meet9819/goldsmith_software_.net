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
    public partial class Userdetails : Form
    {
        public int id;
        public Userdetails()
        {
            InitializeComponent();
            
        }

        private void Userdetails_Load(object sender, EventArgs e)
        {

            disp();
        }
        void disp()
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT id,name FROM clientcontact";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 18);
                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.AllowUserToAddRows = false;
                da.Fill(table);
                
                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Visible = false;
                da.Dispose();
                con.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            custupdate("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
            custupdate("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
        }

        private void custupdate(string v)
        {
            //string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE clientcontact set name = ?name ,email=?email,contact=?contact where id=?id";
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = txtname.Text;
                cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = txtemail.Text;
                cmd.Parameters.Add("?contact", MySqlDbType.VarChar).Value = txtcontact.Text;
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
                con.Close();
                //  clear();
                MessageBox.Show("updated sucessfully");
                disp();
            }

            catch (Exception exe)
            {

                MessageBox.Show(exe.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //string constring = AppSetting.ConnectionString();
            //MySqlConnection con = new MySqlConnection(constring);
            //MySqlCommand cmd = new MySqlCommand();

            //try
            //{

            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "UPDATE clientcontact set name = ?name ,email=?email,contact=?contact where id=?id";
            //    cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = txtname.Text;
            //    cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = txtemail.Text;
            //    cmd.Parameters.Add("?contact", MySqlDbType.VarChar).Value = txtcontact.Text;
            //    cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    //  clear();
            //    disp();
            //}

            //catch (Exception exe)
            //{

            //    MessageBox.Show(exe.Message);
            //}
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
            if(dataGridView1.CurrentRow.Index !=-1)
            {
                txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //txtemail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //txtcontact.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT name FROM clientcontact where name LIKE '%"+txtsearch.Text+"%'";
                command = new MySqlCommand(selectQuery, con);
               // command.Parameters.Add("?search", MySqlDbType.VarChar).Value = txtsearch.Text;
                da = new MySqlDataAdapter(command);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 18);
                dataGridView1.RowTemplate.Height = 25;
                dataGridView1.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView1.DataSource = table;
               // dataGridView1.Columns[1].Visible = false;
                da.Dispose();
                con.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                custdelete("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                custdelete("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");

            }
                MessageBox.Show("Deleted sucessfully");
                disp();



            }

        private void custdelete(string v)
        {
            //string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            con.Open();
            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                try
                {
                    if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                    {
                        //MessageBox.Show(datarow.Cells[1].Value.ToString());


                        // MessageBox.Show("Hello");



                        cmd.Connection = con;
                        cmd.CommandText = "Delete from clientcontact where id='" + datarow.Cells[1].Value.ToString() + "'";
                        //id = Convert.ToInt32(datarow.Cells[1].Value.ToString());
                        //cmd.Parameters.Add("?id", MySqlDbType.Int16).Value = ;
                        cmd.ExecuteNonQuery();
                        // con.Close();
                        //  clear();




                    }
                }
                catch (Exception)
                {
                    // MessageBox.Show(exe.Message);
                }
            }
    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                datarow.Cells[0].Value = checkBox1.CheckState;

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand();

                    con.Open();
                    //foreach (DataGridViewRow datarow in dataGridView1.Rows)
                    //{
                        try
                        {
                        //    if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                        //    {
                                //MessageBox.Show(datarow.Cells[1].Value.ToString());


                                // MessageBox.Show("Hello");



                                cmd.Connection = con;
                                cmd.CommandText = "Delete from clientcontact where id=?id";
                                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                cmd.Parameters.Add("?id", MySqlDbType.Int16).Value = id;
                                cmd.ExecuteNonQuery();
                        con.Close();
                        //  clear();


                        MessageBox.Show("Deleted sucessfully");

                        //}
                    }
                        catch (Exception)
                        {
                            // MessageBox.Show(exe.Message);
                        }
                   // }
                   
                    disp();



                }
                else
                {
                    disp();
                }
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            txtname.BackColor = Color.Aqua;
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            txtname.BackColor = Color.White;
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            txtsearch.BackColor = Color.White;
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            txtsearch.BackColor = Color.Aqua;
        }
    }
}
 