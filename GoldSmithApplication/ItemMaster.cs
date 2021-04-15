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
    public partial class ItemMaster : Form
    {
        public int id;
        public ItemMaster()
        {
            InitializeComponent();
        }
      

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            //string constring = AppSetting.ConnectionString();
            //MySqlConnection con = new MySqlConnection(constring);
            //MySqlCommand command;
            //MySqlDataAdapter da;
            //DataTable table = new DataTable();
            //string selectQuery = "SELECT * FROM itemmaster";
            //command = new MySqlCommand(selectQuery, con);
            //da = new MySqlDataAdapter(command);

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.RowTemplate.Height = 20;
            //dataGridView1.AllowUserToAddRows = false;
            //da.Fill(table);
            //dataGridView1.DataSource = table;
            //da.Dispose();
            getData();
            button1.Visible = false;
            txtcode.Focus();

        }
         void getData()
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT * FROM itemmaster order by code asc";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

               // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 20;
                //this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
               // dataGridView1.DefaultCellStyle  = new DataGridViewCellStyle { ForeColor = Color.Blue };
                this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoResizeRows(
             DataGridViewAutoSizeRowsMode.AllCells);
                da.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.Columns[1].Visible = false;
                da.Dispose();
            }
            catch(Exception )
            {
               // MessageBox.Show(exe.Message);
            }
        }
        private void inout_Click(object sender, EventArgs e)
        {
            InwardOutward inwardoutward = new InwardOutward();
            this.Hide();
            inwardoutward.Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtcode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Code no cannot be blank");
            }
            else if(txtdescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Description cannot be blank");
            }
            else if (txtrate.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Rate cannot be blank");
            }
            else if (mv1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Range 1 value cannot be blank");
            }
            else if (mv2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Range 2 value cannot be blank");
            }
            else if (mv3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Range 3 value cannot be blank");
            }
            else if (mv4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Range 4 value cannot be blank");
            }
            else if (mv5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Range 5 value cannot be blank");
            }
            else
            {
                iteminsert("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                iteminsert("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
            }
        }

        private void iteminsert(string v)
        {
            //string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO itemmaster(code,description,rate,qf1,qt1,m1,qf2,qt2,m2,qf3,qt3,m3,qf4,qt4,m4,qf5,qt5,m5) VALUES(?code,?description,?rate,?qf1,?qt1,?m1,?qf2,?qt2,?m2,?qf3,?qt3,?m3,?qf4,?qt4,?m4,?qf5,?qt5,?m5)";
                cmd.Parameters.Add("?code", MySqlDbType.VarChar).Value = txtcode.Text;
                cmd.Parameters.Add("?description", MySqlDbType.VarChar).Value = txtdescription.Text;
                cmd.Parameters.Add("?rate", MySqlDbType.VarChar).Value = txtrate.Text;
                cmd.Parameters.Add("?qf1", MySqlDbType.VarChar).Value = qtf1.Text;
                cmd.Parameters.Add("?qt1", MySqlDbType.VarChar).Value = qtt.Text;
                cmd.Parameters.Add("?m1", MySqlDbType.VarChar).Value = mv1.Text;
                cmd.Parameters.Add("?qf2", MySqlDbType.VarChar).Value = qtf2.Text;
                cmd.Parameters.Add("?qt2", MySqlDbType.VarChar).Value = qtt2.Text;
                cmd.Parameters.Add("?m2", MySqlDbType.VarChar).Value = mv2.Text;
                cmd.Parameters.Add("?qf3", MySqlDbType.VarChar).Value = qtf3.Text;
                cmd.Parameters.Add("?qt3", MySqlDbType.VarChar).Value = qtt3.Text;
                cmd.Parameters.Add("?m3", MySqlDbType.VarChar).Value = mv3.Text;
                cmd.Parameters.Add("?qf4", MySqlDbType.VarChar).Value = qtf4.Text;
                cmd.Parameters.Add("?qt4", MySqlDbType.VarChar).Value = qtt4.Text;
                cmd.Parameters.Add("?m4", MySqlDbType.VarChar).Value = mv4.Text;
                cmd.Parameters.Add("?qf5", MySqlDbType.VarChar).Value = qtf5.Text;
                cmd.Parameters.Add("?qt5", MySqlDbType.VarChar).Value = qtt5.Text;
                cmd.Parameters.Add("?m5", MySqlDbType.VarChar).Value = mv5.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                getData();
                valfill();
            }

            catch (Exception )
            {

                //MessageBox.Show(exe.Message);
            }
        }

        void valfill()
        {
            qtf1.Text = "1";
            qtf2.Text = "26";
            qtf3.Text = "41";
            qtf4.Text = "61";
            qtf5.Text = "81";
            qtt.Text = "25";
            qtt2.Text = "40";
            qtt3.Text = "60";
            qtt4.Text = "80";
            qtt5.Text = "100";
        }
        void clear()
        {
            txtcode.Text = txtdescription.Text = txtrate.Text = "";
                qtf1.Text = "1";
            qtt.Text = "25";
            qtf2.Text = "26";
            qtt2.Text = "40";
            qtf3.Text = "41";
            qtt3.Text = "60";
            qtf4.Text = "61";
            qtt4.Text = "80";
            qtf5.Text = "81";
            qtt5.Text = "100";
            mv1.Text = mv2.Text = mv3.Text = mv4.Text = mv5.Text = "0";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Index !=-1)
            {
                txtcode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdescription.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtrate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                qtf1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                qtt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                mv1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                qtf2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                qtt2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                mv2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                qtf3.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                qtt3.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                mv3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                qtf4.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                qtt4.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                mv4.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                qtf5.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                qtt5.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                mv5.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            }
            button1.Visible = true;
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            itemupdate("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
            itemupdate("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
            button1.Visible = false;
        }

        private void itemupdate(string v)
        {
           // string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE itemmaster set code = ?code ,description=?description,rate=?rate,qf1=?qf1,qt1=?qt1,m1=?m1,qf2=?qf2,qt2=?qt2,m2=?m2,qf3=?qf3,qt3=?qt3,m3=?m3,qf4=?qf4,qt4=?qt4,m4=?m4,qf5=?qf5,qt5=?qt5,m5=?m5 where id=?id";
                cmd.Parameters.Add("?code", MySqlDbType.VarChar).Value = txtcode.Text;
                cmd.Parameters.Add("?description", MySqlDbType.VarChar).Value = txtdescription.Text;
                cmd.Parameters.Add("?rate", MySqlDbType.VarChar).Value = txtrate.Text;
                cmd.Parameters.Add("?qf1", MySqlDbType.VarChar).Value = qtf1.Text;
                cmd.Parameters.Add("?qt1", MySqlDbType.VarChar).Value = qtt.Text;
                cmd.Parameters.Add("?m1", MySqlDbType.VarChar).Value = mv1.Text;
                cmd.Parameters.Add("?qf2", MySqlDbType.VarChar).Value = qtf2.Text;
                cmd.Parameters.Add("?qt2", MySqlDbType.VarChar).Value = qtt2.Text;
                cmd.Parameters.Add("?m2", MySqlDbType.VarChar).Value = mv2.Text;
                cmd.Parameters.Add("?qf3", MySqlDbType.VarChar).Value = qtf3.Text;
                cmd.Parameters.Add("?qt3", MySqlDbType.VarChar).Value = qtt3.Text;
                cmd.Parameters.Add("?m3", MySqlDbType.VarChar).Value = mv3.Text;
                cmd.Parameters.Add("?qf4", MySqlDbType.VarChar).Value = qtf4.Text;
                cmd.Parameters.Add("?qt4", MySqlDbType.VarChar).Value = qtt4.Text;
                cmd.Parameters.Add("?m4", MySqlDbType.VarChar).Value = mv4.Text;
                cmd.Parameters.Add("?qf5", MySqlDbType.VarChar).Value = qtf5.Text;
                cmd.Parameters.Add("?qt5", MySqlDbType.VarChar).Value = qtt5.Text;
                cmd.Parameters.Add("?m5", MySqlDbType.VarChar).Value = mv5.Text;
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                MessageBox.Show("updated sucessfully");
                getData();
                valfill();


            }

            catch (Exception )
            {

               // MessageBox.Show(exe.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
            button1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btndel("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                btndel("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
            }
        }

        private void btndel(string v)
        {
           // string constring = AppSetting.ConnectionString();
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
                        cmd.CommandText = "Delete from itemmaster where id='" + datarow.Cells[1].Value.ToString() + "'";
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
            MessageBox.Show("Deleted sucessfully");
            getData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow datarow in dataGridView1.Rows)
            {
                datarow.Cells[0].Value = checkBox1.CheckState;

            }
        }

        private void lblcode_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == "")
            {
                txtdescription.Text = "";
                txtrate.Text = "";
                mv1.Text = "";
                mv2.Text = "";
                mv3.Text = "";
                mv4.Text = "";
                mv5.Text = "";

            }
            else
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    con.Open();
                    string selectQuery = "SELECT * FROM itemmaster where code ='" + int.Parse(txtcode.Text) + "'";
                    command = new MySqlCommand(selectQuery, con);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        txtdescription.Text = mdr.GetString("description");
                        txtrate.Text = mdr.GetString("rate");
                        mv1.Text = mdr.GetString("m1");
                        mv2.Text = mdr.GetString("m2");
                        mv3.Text = mdr.GetString("m3");
                        mv4.Text = mdr.GetString("m4");
                        mv5.Text = mdr.GetString("m5");


                    }
                    mdr.Close();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    keydel("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                    keydel("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
                }
            }
            else
            {
                getData();
            }
        }

        private void keydel(string v)
        {
           // string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            con.Open();
            //foreach (DataGridViewRow datarow in dataGridView1.Rows)
            //{
            try
            {
                //if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                //{
                //    //MessageBox.Show(datarow.Cells[1].Value.ToString());


                // MessageBox.Show("Hello");



                cmd.Connection = con;
                cmd.CommandText = "Delete from itemmaster where id=?id";
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.Add("?id", MySqlDbType.Int16).Value = id;
                cmd.ExecuteNonQuery();
                // con.Close();
                //  clear();




                // }
            }
            catch (Exception)
            {
                // MessageBox.Show(exe.Message);
            }
            // }
            MessageBox.Show("Deleted sucessfully");
            getData();
        }

        private void txtcode_Leave(object sender, EventArgs e)
        {
            if (txtcode.Text == "")
            {
                txtdescription.Text = "";
                txtrate.Text = "";
                mv1.Text = "0";
                mv2.Text = "0";
                mv3.Text = "0";
                mv4.Text = "0";
                mv5.Text = "0";

                qtf1.Text = "";
                qtt.Text = "";
                qtf2.Text = "";
                qtt2.Text = "";
                qtf3.Text = "";
                qtt3.Text = "";
                qtf4.Text = "";
                qtt4.Text = "";
                qtf5.Text = "";
                qtt5.Text = "";
                valfill();

            }
            else
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    con.Open();
                    string selectQuery = "SELECT * FROM itemmaster where code ='" + int.Parse(txtcode.Text) + "'";
                    command = new MySqlCommand(selectQuery, con);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        txtdescription.Text = mdr.GetString("description");
                        txtrate.Text = mdr.GetString("rate");
                        mv1.Text = mdr.GetString("m1");
                        mv2.Text = mdr.GetString("m2");
                        mv3.Text = mdr.GetString("m3");
                        mv4.Text = mdr.GetString("m4");
                        mv5.Text = mdr.GetString("m5");

                        qtf1.Text = mdr.GetString("qf1");
                        qtt.Text = mdr.GetString("qt1");
                        qtf2.Text = mdr.GetString("qf2");
                        qtt2.Text = mdr.GetString("qt2");
                        qtf3.Text = mdr.GetString("qf3");
                        qtt3.Text = mdr.GetString("qt3");
                        qtf4.Text = mdr.GetString("qf4");
                        qtt4.Text = mdr.GetString("qt4");
                        qtf5.Text = mdr.GetString("qf5");
                        qtt5.Text = mdr.GetString("qt5");


                    }
                    else
                    {
                        txtdescription.Text = "";
                        txtrate.Text = "";
                        mv1.Text = "0";
                        mv2.Text = "0";
                        mv3.Text = "0";
                        mv4.Text = "0";
                        mv5.Text = "0";

                        qtf1.Text = "";
                        qtt.Text = "";
                        qtf2.Text = "";
                        qtt2.Text = "";
                        qtf3.Text = "";
                        qtt3.Text = "";
                        qtf4.Text = "";
                        qtt4.Text = "";
                        qtf5.Text = "";
                        qtt5.Text = "";
                        valfill();

                    }
                    mdr.Close();
                }
                catch (Exception )
                {
                  //  MessageBox.Show(exe.Message);
                }
            }
            txtcode.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
                if (textBox1.Text == "")
                {
                    getData();
                }
                else
                {
                    try
                    {
                        string constring = AppSetting.ConnectionString();
                        MySqlConnection con = new MySqlConnection(constring);
                        MySqlCommand command;
                        MySqlDataAdapter da;
                        DataTable table = new DataTable();
                        string selectQuery = "SELECT * FROM itemmaster where code = '" + textBox1.Text + "'";
                        command = new MySqlCommand(selectQuery, con);
                        da = new MySqlDataAdapter(command);

                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
                        dataGridView1.RowTemplate.Height = 20;
                        dataGridView1.AllowUserToAddRows = false;
                        da.Fill(table);
                        dataGridView1.DataSource = table;
                        dataGridView1.Columns[1].Visible = false;
                        da.Dispose();
                    }
                    catch (Exception )
                    {
//MessageBox.Show(exe.Message);
                    }
                }
            textBox1.BackColor = Color.White;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void txtcode_Enter(object sender, EventArgs e)
        {
            txtcode.BackColor = Color.Aqua;
        }

        private void txtdescription_Enter(object sender, EventArgs e)
        {
            txtdescription.BackColor = Color.Aqua;
        }

        private void txtdescription_Leave(object sender, EventArgs e)
        {
            txtdescription.BackColor = Color.White;
        }

        private void txtrate_Enter(object sender, EventArgs e)
        {
            txtrate.BackColor = Color.Aqua;
        }

        private void txtrate_Leave(object sender, EventArgs e)
        {
            txtrate.BackColor = Color.White;
        }

        private void mv1_Enter(object sender, EventArgs e)
        {
            mv1.BackColor = Color.Aqua;
        }

        private void mv1_Leave(object sender, EventArgs e)
        {
            mv1.BackColor = Color.White;
        }

        private void mv2_Enter(object sender, EventArgs e)
        {
            mv2.BackColor = Color.Aqua;
        }

        private void mv2_Leave(object sender, EventArgs e)
        {
            mv2.BackColor = Color.White;
        }

        private void mv3_Enter(object sender, EventArgs e)
        {
            mv3.BackColor = Color.Aqua;
        }

        private void mv3_Leave(object sender, EventArgs e)
        {
            mv3.BackColor = Color.White;
        }

        private void mv4_Enter(object sender, EventArgs e)
        {
            mv4.BackColor = Color.Aqua;
        }

        private void mv4_Leave(object sender, EventArgs e)
        {
            mv4.BackColor = Color.White;
        }

        private void mv5_Enter(object sender, EventArgs e)
        {
            mv5.BackColor = Color.Aqua;
        }

        private void mv5_Leave(object sender, EventArgs e)
        {
            mv5.BackColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Aqua;
        }
    }
}
