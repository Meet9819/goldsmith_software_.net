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
using System.Text.RegularExpressions;


namespace GoldSmithApplication
{
    
    public partial class InwardOutward : Form
    {
        public static string usrnm;
        public static string billno;
        public static string indt;
        public static string inwtt;
        public static string delivrytm;
        public static int counter;
        public static string finaltot;
        public static string count;
        public static float grandtotal;

        public static string custname;
        public static string bilsrno;
        public static string dttm;
        public static string inwardwt;
        public static string inwardbag;
        public static string totalin;
        public static string totalout;
        public static string totloss;
        public static string cutting;
        public static string khol;
        public static string totamts;
        public static int noo;
        public static float gt;
        public static string totin;


        //total values count variables
        public static float netinward;
        public static float netoutward;
        public static float netloss;
        public static float netbag;
        public static float netetc;
        public static float netnet;


        public int id;
        public InwardOutward()
        {
            InitializeComponent();
            inoutcb.Items.Add("All");
            inoutcb.Items.Add("Inward");
            inoutcb.Items.Add("Outward");
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Inward");
            comboBox1.Items.Add("Outward");
          //  autocomplete();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }   

        //private void btnsave_Click(object sender, EventArgs e)
        //{
        //    string constring = AppSetting.ConnectionString();
        //    MySqlConnection con = new MySqlConnection(constring);
        //    MySqlCommand cmd = new MySqlCommand();

        //    try
        //    {

        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "INSERT INTO users(username,password) VALUES(?username,?password)";
        //        cmd.Parameters.Add("?username", MySqlDbType.VarChar).Value = txtsrno.Text;
        //        cmd.Parameters.Add("?password", MySqlDbType.VarChar).Value = txtparty.Text;
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    catch (Exception exe)
        //    {
        //        MessageBox.Show(exe.Message);
        //    }
        //}

        //private void btndisplay_Click(object sender, EventArgs e)
        //{
        //    string constring = AppSetting.ConnectionString();
        //    MySqlConnection con = new MySqlConnection(constring);
        //    MySqlCommand cmdd = new MySqlCommand();

        //    try
        //    {

        //        con.Open();
        //        cmdd.Connection = con;
        //        cmdd.CommandText = "Select * from Inwardoutward";

        //        var version = cmdd.ExecuteScalar().ToString();
        //        Console.WriteLine($"MySQL version: {version}");
        //        cmdd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    catch (Exception exe)
        //    {
        //        MessageBox.Show(exe.Message);
        //    }

        //}
     

      


        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/
        /* Displaying data in grid view*/
       


        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void InwardOutward_Load(object sender, EventArgs e)
        {
            autocomplete();
            Disp();
            counter = 0;
            noo = 0;
            button1.Visible = false;
            counterno();
            grandtotals();
           

            inwarddttm();
            outwarddttm();

            //DataTable dt = new DataTable();
            itemsadd.ColumnCount = 9;

            itemsadd.Columns[0].Name = "srno";
            itemsadd.Columns[1].Name = "code";
            itemsadd.Columns[2].Name = "Description";
            itemsadd.Columns[3].Name = "quantity";
            itemsadd.Columns[4].Name = "Rate";
            itemsadd.Columns[5].Name = "MinAmount";
            itemsadd.Columns[6].Name = "GrossAmount";
            itemsadd.Columns[7].Name = "NetAmount";
            itemsadd.Columns[8].Name = "Remark";//(, typeof(int));
            //dt.Columns.Add("", typeof(int));
            //dt.Columns.Add("", typeof(String));
            //dt.Columns.Add("", typeof(int));
            //dt.Columns.Add("", typeof(float));
            //dt.Columns.Add("", typeof(string));
            //dt.Columns.Add("", typeof(float));            
            //dt.Columns.Add("", typeof(float));
            //dt.Columns.Add("", typeof(string));

            //itemsadd.DataSource = dt;
            //itemsadd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //panel4.Visible = false;




        }
        void inwarddttm()
        {
           
            indttm.Text = DateTime.Now.ToString("dd--MM--yyyy   hh:mm tt");
            outdttm.Text = DateTime.Now.ToString("dd--MM--yyyy   hh:mm tt");
            //tm.Text = dateTimePicker1.Value.ToString();

        }
        void outwarddttm()
        {
            outitemdt.Text = DateTime.Now.ToString("dd--MM--yyyy   hh:mm tt");
            bagdttm.Text = DateTime.Now.ToString("dd--MM--yyyy   hh:mm tt");
           // loss.Text = DateTime.Now.ToString("dd.mm.yyyy hh:mm tt");

        }

        void Disp()
        {

            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
               // MySqlDataReader mdr;
                DataTable table = new DataTable();
                string selectQuery = "SELECT id,billno as 'Billno', customer as 'Party',mode as 'Mode', wt as 'ItemWt', outitemwt as 'Outwt',outbagwt as 'Bagwt', wt as 'Total Weight',itemdatetime as 'Date',time as 'Delivary Time',etc,netamount,loss FROM inwardoutward order by billno desc";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);
                //for inward data display
               // dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 25;
                this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 15);
                dataGridView2.AllowUserToAddRows = false;


                da.Fill(table);
                dataGridView2.DataSource = table;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //for outward data display


                //dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView3.DefaultCellStyle.Font = new Font("Tahoma", 15);
                dataGridView3.RowTemplate.Height = 25;
                dataGridView3.AllowUserToAddRows = false;               
                dataGridView3.DataSource = table;
                dataGridView3.Columns[1].Visible = false;
                dataGridView3.AutoResizeColumns();
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                da.Dispose();
                //bill generation

                //selectQuery = "Select * from "
                DataTable dt = new DataTable();
                selectQuery = "SELECT * from bill order by billno desc";
                command = new MySqlCommand(selectQuery, con);
               MySqlDataAdapter a = new MySqlDataAdapter(command);
                //for inward data display
                 dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.RowTemplate.Height = 25;
                this.dataGridView4.DefaultCellStyle.Font = new Font("Tahoma", 15);
                dataGridView4.AllowUserToAddRows = false;

                a.Fill(dt);
                dataGridView4.DataSource = dt;
                dataGridView4.AutoResizeColumns();
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView4.Columns[0].Visible = false;
                a.Dispose();

            





                //selectQuery = "Select  Round(Sum(amt),2) as 'amount' from bill ";
                //command = new MySqlCommand(selectQuery, con);
                //con.Open();
                //mdr = command.ExecuteReader();
                //if (mdr.Read())
                //{
                //    disp2();
                //    data();
                //    textBox6.Text =  mdr.GetString("amount");

                //    //int nwno = noo + 1;
                //   // textBox6.Text = noo.ToString();

                //}
                con.Close();
                // mdr.Close();
               








            }
            catch (Exception)
            {
                //MessageBox.Show(exe.Message);
            }
            disp2();
            data();


        }
        void disp2()
        {

            string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand command;
            //MySqlDataAdapter da;
           // MySqlDataReader mdr;
            DataTable dtt = new DataTable();
            string st = "SELECT distinct(billno) as 'srno',mode as 'Mode', loss,netamount as 'amt' FROM `inwardoutward` ORDER BY mode ASC";
            command = new MySqlCommand(st, con);
            MySqlDataAdapter abc = new MySqlDataAdapter(command);
            //for inward data display
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.RowTemplate.Height = 20;
            this.dataGridView4.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridView5.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 20;
            this.dataGridView4.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridView1.AllowUserToAddRows = false;

            abc.Fill(dtt);
            dataGridView5.DataSource = dtt;
            dataGridView1.DataSource = dtt;
            //dataGridView5.Columns[0].Visible = false;
            abc.Dispose();

        }
        void data()
        {
            try
            {
                netinward = 0;
                netoutward = 0;
                netnet = 0;
                netbag = 0;
                netloss = 0;
                netetc = 0;
                try
                {
                    for (int i = (dataGridView2.Rows.Count - 1); i >= 0; i--)
                    {
                        netinward += float.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                        netnet += float.Parse(dataGridView2.Rows[i].Cells[12].Value.ToString());
                        netoutward += float.Parse(dataGridView2.Rows[i].Cells[6].Value.ToString());
                        netbag += float.Parse(dataGridView2.Rows[i].Cells[7].Value.ToString());
                        // netinward += float.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                        netetc += float.Parse(dataGridView2.Rows[i].Cells[11].Value.ToString());                        
                       // 
                    }
                    netloss = netinward - netoutward;
                    totalinward.Text = Math.Round(netinward,2).ToString();
                    totaloutward.Text = Math.Round(netoutward,2).ToString();
                    totalbag.Text = Math.Round(netbag,2).ToString();
                    textBox7.Text = Math.Round(netetc,2).ToString();
                    totalnet.Text = Math.Round(netnet,2).ToString();
                    textBox8.Text = Math.Round(netloss,2).ToString();
                }
                finally
                {
                    totalinward.Text = Math.Round(netinward, 2).ToString();
                    totaloutward.Text = Math.Round(netoutward, 2).ToString();
                    totalbag.Text = Math.Round(netbag, 2).ToString();
                    textBox7.Text = Math.Round(netetc, 2).ToString();
                    totalnet.Text = Math.Round(netnet, 2).ToString();
                    textBox8.Text = Math.Round(netloss, 2).ToString();

                }
            }
            catch(Exception exe) {
                MessageBox.Show(exe.Message);
            }






            //string constring = AppSetting.ConnectionString();
            //MySqlConnection con = new MySqlConnection(constring);
            //MySqlCommand cd;
            //MySqlDataReader mdr;
            //con.Open();
            //string qry = "SELECT billno from inwardoutward";
            //cd = new MySqlCommand(qry, con);
            ////Int32 count = (Int32)cd.execute();
            //mdr = cd.ExecuteReader();
            //if (mdr.Read())
            //{



            //    try
            //    {

            //        MySqlCommand command;
            //        mdr.Close();
            //       // con.Open();
            //        string selectQuery = "select Round(Sum(wt),2) as 'totalinward',count(wt) as cnt from `inwardoutward` where mode='IN'";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        // MessageBox.Show(mdr.GetString("cnt"));
            //        if (mdr.Read())
            //        {
            //            totalinward.Text = mdr.GetString("totalinward");
            //        }
            //        else
            //        {
            //            totalinward.Text = "0";
            //        }
            //        mdr.Close();
            //        selectQuery = "select Round(Sum(outwt),2) as 'totaloutward' from `inwardoutward` where mode='OUT'";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        if (mdr.Read())
            //        {
            //            totaloutward.Text = mdr.GetString("totaloutward");
            //        }
            //        else
            //        {
            //            totaloutward.Text = "0";
            //        }
            //        mdr.Close();
            //        selectQuery = "select Round(Sum(bagweight),2) as 'bgweight' from `inwardoutward`";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        if (mdr.Read())
            //        {
            //            totalbag.Text = mdr.GetString("bgweight");
            //        }
            //        else
            //        {
            //            totalbag.Text = "0";

            //        }
            //        mdr.Close();
            //        selectQuery = "select Round(Sum(etc),2) as 'etc' from `inwardoutward` ";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        if (mdr.Read())
            //        {
            //            textBox7.Text = mdr.GetString("etc");
            //        }
            //        else
            //        {
            //            textBox7.Text = "0";
            //        }
            //        mdr.Close();
            //        selectQuery = "select Round(Sum(loss),2) as 'loss' from `inwardoutward` ";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        if (mdr.Read())
            //        {
            //            textBox8.Text = mdr.GetString("loss");
            //        }
            //        else
            //        {
            //            textBox8.Text = "0";
            //        }
            //        mdr.Close();
            //        selectQuery = "select Round(Sum(netamount),2) as 'net' from `inwardoutward` ";
            //        command = new MySqlCommand(selectQuery, con);
            //        mdr = command.ExecuteReader();
            //        if (mdr.Read())
            //        {
            //            totalnet.Text = mdr.GetString("net");
            //        }
            //        else
            //        {
            //            totalnet.Text = "0";
            //        }
            //        mdr.Close();



            //    }
            //    catch (Exception exe)
            //    {
            //        MessageBox.Show(exe.Message);
            //    }
            //}
            //else
            //{
            //    con.Close();
            //    totalinward.Text = "0";
            //    totaloutward.Text = "0";
            //    totalbag.Text = "0";
            //    textBox7.Text = "0";
            //    textBox8.Text = "0";
            //    totalnet.Text = "0";


            //}

        }

        void counterno()
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataReader mdr;
                con.Open();
                string selectQuery = "select billno  from `inwardoutward`  ORDER BY billno DESC";
                command = new MySqlCommand(selectQuery, con);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                     noo = int.Parse(mdr.GetString("billno"));
                    
                        int nwno = noo + 1;
                        srno.Text = nwno.ToString();
                    
                }
                mdr.Close();
                if(noo == 0)
                {
                    int nos = noo + 1;
                    srno.Text = nos.ToString();
                }
                
            }
            catch (Exception)
            {
               // MessageBox.Show(exe.Message);
            }
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/
        /* Saving data to database*/
        private void savebtn_Click(object sender, EventArgs e)
        {
            tmupdate();
            if (party.Text.Trim() == string.Empty ||inwt.Text == string.Empty || outwt.Text == string.Empty)
            {
                MessageBox.Show("Party name  or weight cannot be blank");
               /// return; // return because we don't want to run normal code of buton click
            }
            else if(tm.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Delivery time cannot be blank");
            }
            else if(wt.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Check your Weight calulation inweight cannot be blank");
            }
            else 
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO inwardoutward(billno,customer,itemscan,itemdatetime,itemweight,bagscan,bagdatetime,bagweight,wt,time,mode) VALUES(?billno,?customer,?itemscan,?itemdatetime,?itemweight,?bagscan,?bagdatetime,?bagweight,?wt,?time,?mode)";
                    cmd.Parameters.Add("?billno", MySqlDbType.VarChar).Value = srno.Text;
                    cmd.Parameters.Add("?customer", MySqlDbType.VarChar).Value = party.Text;
                    cmd.Parameters.Add("?itemscan", MySqlDbType.VarChar).Value = scan.Text;
                    cmd.Parameters.Add("?itemdatetime", MySqlDbType.VarChar).Value = indttm.Text;
                    cmd.Parameters.Add("?itemweight", MySqlDbType.VarChar).Value = inwt.Text;
                    cmd.Parameters.Add("?bagscan", MySqlDbType.VarChar).Value = inbagscan.Text;
                    cmd.Parameters.Add("?bagdatetime", MySqlDbType.VarChar).Value = outdttm.Text;
                    cmd.Parameters.Add("?bagweight", MySqlDbType.VarChar).Value = outwt.Text;
                    cmd.Parameters.Add("?wt", MySqlDbType.VarChar).Value = wt.Text;
                    // cmd.Parameters.Add("?remark", MySqlDbType.VarChar).Value = remark.Text;
                    cmd.Parameters.Add("?time", MySqlDbType.VarChar).Value = textBox3.Text;
                    //   cmd.Parameters.Add("?etc", MySqlDbType.VarChar).Value = etc.Text;
                    cmd.Parameters.Add("?mode", MySqlDbType.VarChar).Value = "IN";


                    MessageBox.Show("Inserted Successfully");
                    cmd.ExecuteNonQuery();
                    // clear();
                    Disp();
                    //counterno();
                    inwarddttm();

                    if (party.Text != "")
                    {

                        usrnm = party.Text;
                        billno = srno.Text;
                        indt = indttm.Text;
                        inwtt = wt.Text;
                        delivrytm = textBox3.Text;
                        Inwardprint inward = new Inwardprint();
                        //inward.print(Panel1);
                        inward.Show();
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Entry to generate INWARD BILL");
                    }
                   

                }

                catch (Exception )
                {
                    //MessageBox.Show(exe.Message);
                }
                finally
                {
                    con.Close();
                    clear();
                    counterno();
                    inwarddttm();
                }
            }
            
        }
        void clear()
        {
           party.Text = scan.Text = indttm.Text = inbagscan.Text = outdttm.Text =outparty.Text= "";
            inwt.Text = "0";
            outwt.Text = "0";
            wt.Text = "0";
            tm.Text = "1";
            outgroswt.Text = "0";
            outgrosswt.Text = "0";

        }
        void clearout()
        {
           textBox3.Text=outsrno.Text = outparty.Text = outscan.Text = outitemdt.Text = outitemwt.Text = outbagscan.Text = bagdttm.Text = bagoutwt.Text =   loss.Text  =textBox11.Text=textBox13.Text= "";
            etcval.Text = "0";
            outitemwt.Text = "0";
            bagoutwt.Text = "0";
            otwt.Text = "0";
            outgroswt.Text = "0";
            outgrosswt.Text = "0";
            nettotal.Text = "0";
           // outgrosswt.Text = "";
        }
        void clearbill()
        {
            billsrno.Text = billitem.Text = billamt.Text =billqty.Text=billremark.Text= "";

        }

        private void itemmaster_Click(object sender, EventArgs e)
        {
            ItemMaster itemmaster = new ItemMaster();
            this.Hide();
            itemmaster.Show();
           
        }

        private void addnm_Click(object sender, EventArgs e)
        {
            custadd("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
            custadd("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
        }

        private void custadd(String str)
        {
            if (party.Text == string.Empty)
            {
                MessageBox.Show("Customer name cannot be blank");
            }
            else
            {
                //string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(str);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO  clientcontact(name) VALUES(?name)";
                    cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = party.Text;
                    //cmd.Parameters.Add("?contact", MySqlDbType.VarChar).Value = txtcontact.Text;
                    //cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = txtemail.Text;



                    cmd.ExecuteNonQuery();
                    //clear();
                    MessageBox.Show("Customer Added  Successfully");
                    con.Close();
                    // this.Close();
                    autocomplete();
                }

                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }



                //Addnewname addnew = new Addnewname();

                //addnew.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT * FROM inwardoutward where billno = '"+textBox1.Text+"'";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView2.DataSource = table;
                dataGridView2.Columns[1].Visible = false;
                da.Dispose();
            }
            catch (Exception )
            {
                //MessageBox.Show(exe.Message);
            }

        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT * FROM inwardoutward where billno = '" + textBox13.Text + "'";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView3.DataSource = table;
                dataGridView3.Columns[1].Visible = false;
                da.Dispose();
            }
            catch (Exception )
            {
                //MessageBox.Show(exe.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT * FROM inwardoutward where customer = '" + textBox2.Text + "'";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView2.DataSource = table;
                dataGridView2.Columns[1].Visible = false;
                da.Dispose();
            }
            catch (Exception )
            {
               // MessageBox.Show(exe.Message);
            }

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT * FROM inwardoutward where customer = '" + textBox11.Text + "'";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);

                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.RowTemplate.Height = 20;
                dataGridView3.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView3.DataSource = table;
                dataGridView3.Columns[1].Visible = false;
                da.Dispose();
            }
            catch (Exception )
            {
               // MessageBox.Show(exe.Message);
            }

        }

        private void inoutcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(inoutcb.SelectedIndex == 0)
            {
                Disp();
            }
            else if(inoutcb.SelectedIndex == 1)
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataAdapter da;
                    DataTable table = new DataTable();
                    string selectQuery = "SELECT * FROM inwardoutward where mode = 'IN'";
                    command = new MySqlCommand(selectQuery, con);
                    da = new MySqlDataAdapter(command);

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.RowTemplate.Height = 20;
                    dataGridView2.AllowUserToAddRows = false;
                    da.Fill(table);
                    dataGridView2.DataSource = table;
                    dataGridView2.Columns[1].Visible = false;
                    da.Dispose();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
            }
            else if (inoutcb.SelectedIndex == 2)
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataAdapter da;
                    DataTable table = new DataTable();
                    string selectQuery = "SELECT * FROM inwardoutward where mode = 'OUT'";
                    command = new MySqlCommand(selectQuery, con);
                    da = new MySqlDataAdapter(command);

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.RowTemplate.Height = 20;
                    dataGridView2.AllowUserToAddRows = false;
                    da.Fill(table);
                    dataGridView2.DataSource = table;
                    dataGridView2.Columns[1].Visible = false;
                    da.Dispose();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
            }
        }

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Disp();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataAdapter da;
                    DataTable table = new DataTable();
                    string selectQuery = "SELECT * FROM inwardoutward where mode = 'IN'";
                    command = new MySqlCommand(selectQuery, con);
                    da = new MySqlDataAdapter(command);

                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView3.RowTemplate.Height = 20;
                    dataGridView3.AllowUserToAddRows = false;
                    da.Fill(table);
                    dataGridView3.DataSource = table;
                    dataGridView3.Columns[1].Visible = false;
                    da.Dispose();
                }
                catch (Exception )
                {
                  //  MessageBox.Show(exe.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand command;
                    MySqlDataAdapter da;
                    DataTable table = new DataTable();
                    string selectQuery = "SELECT * FROM inwardoutward where mode = 'OUT'";
                    command = new MySqlCommand(selectQuery, con);
                    da = new MySqlDataAdapter(command);

                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView3.RowTemplate.Height = 20;
                    dataGridView3.AllowUserToAddRows = false;
                    da.Fill(table);
                    dataGridView3.DataSource = table;
                    dataGridView3.Columns[1].Visible = false;
                    da.Dispose();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
           
           
            //cmd.Parameters.Add("?remark", MySqlDbType.VarChar).Value = remark.Text;
            //cmd.Parameters.Add("?time", MySqlDbType.VarChar).Value = tm.Text;
            //cmd.Parameters.Add("?etc", MySqlDbType.VarChar).Value = etc.Text;
            if (dataGridView2.CurrentRow.Index != -1)
            {
                srno.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                party.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                //scan.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
              //  indttm.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                inwt.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                //inbagscan.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
              //  outdttm.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                outwt.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                wt.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                //remark.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
               // etc.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());

            }
            savebtn.Visible = false;
            button1.Visible = true;
            inwarddttm();
        }
        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {


            ////cmd.Parameters.Add("?remark", MySqlDbType.VarChar).Value = remark.Text;
            ////cmd.Parameters.Add("?time", MySqlDbType.VarChar).Value = tm.Text;
            ////cmd.Parameters.Add("?etc", MySqlDbType.VarChar).Value = etc.Text;
            //if (dataGridView3.CurrentRow.Index != -1)
            //{
            //    outsrno.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            //    outparty.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            //    outscan.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            //    outitemdt.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            //    outitemwt.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            //    outbagscan.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            //    bagdttm.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();
            //    bagoutwt.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString();
            //    outgrosswt.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString();
            //    //outremark.Text = dataGridView3.CurrentRow.Cells[11].Value.ToString();
            //    loss.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString();
            //    outetc.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString();
            //    id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());

            //}
            //button1.Visible = true;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

          textBox3.Text=srno.Text = party.Text = scan.Text = indttm.Text = inwt.Text = inbagscan.Text = outdttm.Text = outwt.Text = wt.Text =  tm.Text =  textBox1.Text = textBox2.Text = "";
            button1.Visible = false;
            savebtn.Visible = true;
            inwt.Text = "0";
            outwt.Text = "0";
            counterno();
            inwarddttm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmupdate();
            if (party.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Party name cannot be blank");
                /// return; // return because we don't want to run normal code of buton click
            }
            else if (tm.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Delivery time cannot be blank");
            }
            else
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE inwardoutward set billno=?billno,customer=?customer,itemdatetime=?itemdatetime,itemweight=?itemweight,bagdatetime=?bagdatetime,bagweight=?bagweight,wt=?wt,time=?time where id=?id";
                    cmd.Parameters.Add("?billno", MySqlDbType.VarChar).Value = srno.Text;
                    cmd.Parameters.Add("?customer", MySqlDbType.VarChar).Value = party.Text;
                    // cmd.Parameters.Add("?itemscan", MySqlDbType.VarChar).Value = scan.Text;
                    cmd.Parameters.Add("?itemdatetime", MySqlDbType.VarChar).Value = indttm.Text;
                    cmd.Parameters.Add("?itemweight", MySqlDbType.VarChar).Value = inwt.Text;
                    //  cmd.Parameters.Add("?bagscan", MySqlDbType.VarChar).Value = inbagscan.Text;
                    cmd.Parameters.Add("?bagdatetime", MySqlDbType.VarChar).Value = outdttm.Text;
                    cmd.Parameters.Add("?bagweight", MySqlDbType.VarChar).Value = outwt.Text;
                    cmd.Parameters.Add("?wt", MySqlDbType.VarChar).Value = wt.Text;
                    //cmd.Parameters.Add("?remark", MySqlDbType.VarChar).Value = remark.Text;
                    cmd.Parameters.Add("?time", MySqlDbType.VarChar).Value = textBox3.Text;
                    // cmd.Parameters.Add("?etc", MySqlDbType.VarChar).Value = etc.Text;
                    cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                   // clear();
                    Disp();
                    if (party.Text != "")
                    {

                        usrnm = party.Text;
                        billno = srno.Text;
                        indt = indttm.Text;
                        inwtt = wt.Text;
                        delivrytm = textBox3.Text;
                        Inwardprint inward = new Inwardprint();
                        //inward.print(Panel1);

                        inward.Show();
                        clear();
                        counterno();
                        inwarddttm();
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Entry to generate INWARD BILL");
                    }

                }

                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
                finally
                {
                    con.Close();
                }
                button1.Visible = false;
                savebtn.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                foreach (DataGridViewRow datarow in dataGridView2.Rows)
                {
                    try
                    {

                        if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                        {


                            cmd.Connection = con;
                            cmd.CommandText = "Delete from  inwardoutward where id='" + datarow.Cells[1].Value.ToString() + "'";
                            //id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                            //cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                            //MessageBox.Show("Deleted Successfully");
                            cmd.ExecuteNonQuery();

                        }
                        counterno();
                    }





                catch (Exception )
                    {
                        //MessageBox.Show(exe.Message);
                    }
                   

                }

                MessageBox.Show("Deleted Successfully");
               // clear();
                con.Close();
                Disp();
                counterno();
            }
        }

        private void outwt_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    float itemwt = float.Parse(inwt.Text);
            //    float bagwt = float.Parse(outwt.Text);
            //    float gross = itemwt - bagwt;
            //    wt.Text = gross.ToString();
            //}
            //catch(Exception)
            //{

            //}

            try
            {
                wt.Text = (float.Parse(inwt.Text) + float.Parse(outwt.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            if (party.Text != "" )
            {

                usrnm = party.Text;
                billno = srno.Text;
                indt = indttm.Text;
                inwtt = wt.Text;
                delivrytm = textBox3.Text;
                Inwardprint inward = new Inwardprint();
                inward.Show();
                clear();
                counterno();
                inwarddttm();
            }
            else
            {
                MessageBox.Show("Please Select a Entry to generate INWARD BILL");
            }

            
        }

        private void itemsadd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void saveoutward_Click(object sender, EventArgs e)
        {
            if(outsrno.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bill no cannot be blank");
            }
            else if(etcval.Text.Trim() == string.Empty || nettotal.Text ==string.Empty)
            {
                MessageBox.Show("ETC value or nettotal  cannot be blank");
            }
            else
            { 
            string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                    loss.Text = (Math.Round(float.Parse(totin) - float.Parse(otwt.Text),2)).ToString();

                con.Open();
                cmd.Connection = con;
                // cmd.CommandText = "UPDATE inwardoutward set outitemwt=?outitemwt,outbagwt=?outbagwt,outwt=?outwt,mode=?mode,loss=?loss,bagscan=?bagscan,bagdatetime=?bagdatetime,bagweight=?bagweight,wt=?wt,time=?time where id=?id";

                cmd.CommandText = "UPDATE inwardoutward set outitemwt=?outitemwt,outbagwt=?outbagwt,outwt=?outwt,mode=?mode,loss=?loss,etc=?etc,netamount=?netamount where billno=?id";
                cmd.Parameters.Add("?outitemwt", MySqlDbType.VarChar).Value = outitemwt.Text;
                cmd.Parameters.Add("?outbagwt", MySqlDbType.VarChar).Value = bagoutwt.Text;
                cmd.Parameters.Add("?outwt", MySqlDbType.VarChar).Value = outwt.Text;
                cmd.Parameters.Add("?mode", MySqlDbType.VarChar).Value = "OUT";
                cmd.Parameters.Add("?loss", MySqlDbType.VarChar).Value = loss.Text;
                cmd.Parameters.Add("?etc", MySqlDbType.VarChar).Value = etcval.Text;
                cmd.Parameters.Add("?netamount", MySqlDbType.VarChar).Value = nettotal.Text;
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = outsrno.Text;





                cmd.ExecuteNonQuery();
                MessageBox.Show("Outward Saved Successfully");
                
                    if (outsrno.Text != "")
                    {

                        custname = outparty.Text;
                        bilsrno = outsrno.Text;//"dd -- MM -- yyyy    hh:mm tt"
                        dttm = outitemdt.Text;
                        inwardwt = textBox5.Text;
                        inwardbag = bagoutwt.Text;
                        totalin = outgrosswt.Text;
                        totalout = otwt.Text;
                        totloss = loss.Text;
                        cutting = outgroswt.Text;
                        khol = etcval.Text;
                        totamts = nettotal.Text;

                        outwardprint op = new outwardprint();
                        op.Show();
                        outwarddttm();
                       
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Entry to generate INWARD BILL");
                    }
                    // clear();
                    clearout();
                    Disp();


                }

            catch (Exception)
            {
                //MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
        }
        }

        private void canoutward_Click(object sender, EventArgs e)
        {
            clearout();
        }

        private void Inward_Click(object sender, EventArgs e)
        {
            inwarddttm();
            if (party.Focused)
            {
                MessageBox.Show("Focused");
            }
            else
            {
                party.Focus();
               // MessageBox.Show(" Not Focused");
            }
        }

        private void Outward_Click(object sender, EventArgs e)
        {
            outwarddttm();
            if (outsrno.Focused)
            {
                //MessageBox.Show("Focused");
            }
            else
            {
                outsrno.Focus();
                // MessageBox.Show(" Not Focused");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            inwarddttm();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            inwarddttm();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            inwarddttm();
        }

        private void label40_Click(object sender, EventArgs e)
        {
            outwarddttm();
        }

        private void label42_Click(object sender, EventArgs e)
        {
            outwarddttm();
        }

        private void label48_Click(object sender, EventArgs e)
        {
            outwarddttm();
        }

        private void billsrno_TextChanged(object sender, EventArgs e)
        {
            if (billsrno.Text == "")
            {
                billparty.Text = "";
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
                string selectQuery = "select customer  from `inwardoutward` where billno = '" + billsrno.Text + "' && mode = 'IN'";
                command = new MySqlCommand(selectQuery, con);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    billparty.Text = mdr.GetString("customer");
                }
                mdr.Close();
            }
            catch (Exception)
            {
               // MessageBox.Show(exe.Message);
            }
         }
        }

        private void billitem_TextChanged(object sender, EventArgs e)
        {
            float drf = 0;

            if (billitem.Text == "")
            {
                billdesc.Text = "";
                billrate.Text = drf.ToString();
                billminamt.Text = drf.ToString();
                billamt.Text = drf.ToString();




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
                    string selectQuery = "select description,rate  from `itemmaster` where code = '"+billitem.Text+"'";
                    command = new MySqlCommand(selectQuery, con);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        billdesc.Text = mdr.GetString("description");
                        billrate.Text = mdr.GetString("rate");
                    }
                    else
                    {
                        billdesc.Text = "";
                        billrate.Text = drf.ToString();
                        billminamt.Text = drf.ToString();
                        billamt.Text = drf.ToString();
                    }
                    mdr.Close();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }
            }
        }

        private void billqty_TextChanged(object sender, EventArgs e)
        {
            string selectQuery;
            if (billrate.Text == "" || billqty.Text == "")
            {
               billrate.Text = "0";
                billqty.Text = "";
                billminamt.Text = "0";

            }
            else
            {
                try
                {
                    float rate = float.Parse(billrate.Text);
                    float quantity = float.Parse(billqty.Text);
                    float amt = rate * quantity;
                    billamt.Text = amt.ToString();

                    

                    try
                    {
                        string constring = AppSetting.ConnectionString();
                        MySqlConnection con = new MySqlConnection(constring);
                        MySqlCommand command;
                        MySqlDataReader mdr;
                        con.Open();
                        selectQuery = "select *  from `itemmaster` where code = '" + billitem.Text + "'";
                        command = new MySqlCommand(selectQuery, con);
                        mdr = command.ExecuteReader();
                        if (mdr.Read())
                        {
                            if(quantity>=float.Parse(mdr.GetString("qf1")) && quantity<= float.Parse(mdr.GetString("qt1")))
                            {
                                billminamt.Text = mdr.GetString("m1");
                            }
                            else if (quantity >= float.Parse(mdr.GetString("qf2")) && quantity <= float.Parse(mdr.GetString("qt2")))
                            {
                                billminamt.Text = mdr.GetString("m2");
                            }
                            else if (quantity >= float.Parse(mdr.GetString("qf3")) && quantity <= float.Parse(mdr.GetString("qt3")))
                            {
                                billminamt.Text = mdr.GetString("m3");
                            }
                            else if (quantity >= float.Parse(mdr.GetString("qf4")) && quantity <= float.Parse(mdr.GetString("qt4")))
                            {
                                billminamt.Text = mdr.GetString("m5");
                            }
                            else if (quantity >= float.Parse(mdr.GetString("qf5")) && quantity <= float.Parse(mdr.GetString("qt5")))
                            {
                                billminamt.Text = mdr.GetString("m5");
                            }
                            
                        }
                        mdr.Close();
                    }
                    catch (Exception )
                    {
                        //MessageBox.Show(exe.Message);
                    }
                }
                catch(Exception)
                {

                }
            }
            // Minimum value calculation on the basis of the quantity entered

            






        }

        private void canbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Cancel the bill?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clearbill();
                itemsadd.Rows.Clear();
                counter = 0;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (billitem.Text == "")
            {
                MessageBox.Show("Enter Item no");
            }
           else if (billitem.Text != "")
            { 
                counter += 1;
            count = counter.ToString();



            adddata(count, billitem.Text, billdesc.Text, billqty.Text, billrate.Text, billminamt.Text, billamt.Text, val(billminamt.Text, billamt.Text), billremark.Text);
            this.billitem.Text = "";
            this.billqty.Text = "";
            this.billremark.Text = "";

            grandtotals();
        }

        }

        private void grandtotals()
        {
            grandtotal = 0;
           for(int i = 0;i<itemsadd.Rows.Count;i++)
            {
                grandtotal += float.Parse(itemsadd.Rows[i].Cells[7].Value.ToString());
            }
            totamt.Text = grandtotal.ToString();



            gt = 0;
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                gt += float.Parse(dataGridView4.Rows[i].Cells[3].Value.ToString());
            }
            textBox6.Text = gt.ToString();
        }

        private void adddata(string count, string billitem, string billdesc, string billqty, string billrate, string billminamt, string billamt,  string finaltot, string billremark)
        {
            string[] row = {count, billitem, billdesc, billqty, billrate, billminamt, billamt, finaltot, billremark };
            itemsadd.Rows.Add(row);
            // this.itemsadd.SortOrder. = true;
            itemsadd.Sort(itemsadd.Columns[0], ListSortDirection.Descending);





        }
        string val(string minamt,string billamt)
        {
            float min = float.Parse(minamt);
            float bill = float.Parse(billamt);
            if(min>bill)
            {
                finaltot = min.ToString(); 
            }
            else if(bill>min)
            {
                finaltot = bill.ToString();

            }
            else if(min == bill)
            {
                finaltot = min.ToString();
            }
            return finaltot;
        }

        private void sve_Click(object sender, EventArgs e)
        {
            string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand abc = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                // cmd.CommandText = "UPDATE inwardoutward set grossamt=?etc where billno=?id";
                cmd.CommandText = "INSERT into bill (billno,party,amt) values(?billno,?party,?amt)";
               
                cmd.Parameters.Add("?billno", MySqlDbType.VarChar).Value = billsrno.Text;
                
                cmd.Parameters.Add("?party", MySqlDbType.VarChar).Value = billparty.Text;
                cmd.Parameters.Add("?amt", MySqlDbType.VarChar).Value = totamt.Text;





                cmd.ExecuteNonQuery();
                abc.Connection = con;
                // cmd.CommandText = "UPDATE inwardoutward set grossamt=?etc where billno=?id";
                abc.CommandText = "UPDATE inwardoutward set grossamt = ?amt where billno = ?billno";

                abc.Parameters.Add("?billno", MySqlDbType.VarChar).Value = billsrno.Text;

               // abc.Parameters.Add("?party", MySqlDbType.VarChar).Value = billparty.Text;
                abc.Parameters.Add("?amt", MySqlDbType.VarChar).Value = totamt.Text;
                abc.ExecuteNonQuery();

                MessageBox.Show("Bill Saved Successfully");
                clear();
                billsrno.Text = "";
                Disp();
                grandtotals();
                itemsadd.Rows.Clear();
            }

            catch (Exception)
            {
               // MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void printout_Click(object sender, EventArgs e)
        {
            if (outsrno.Text != "")
            {

                custname = outparty.Text;
                bilsrno = outsrno.Text;
                dttm = DateTime.Now.ToString("dd.MM.yyyy hh:mm tt");
                inwardwt = textBox5.Text;
                inwardbag = textBox4.Text;
                totalin = outgrosswt.Text;
                totalout = otwt.Text;
                totloss = (Math.Round(float.Parse(totin) - float.Parse(otwt.Text), 2)).ToString();
                cutting = outgroswt.Text;
                khol = etcval.Text;
                totamts = nettotal.Text;

                outwardprint op = new outwardprint();
                op.Show();
                outwarddttm();
            }
            else
            {
                MessageBox.Show("Please Select a Entry to generate INWARD BILL");
            }

            
            
        }

   

        private void srno_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow datarow in dataGridView2.Rows)
            {
                datarow.Cells[0].Value = checkBox1.CheckState;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow datarow in dataGridView3.Rows)
            {
                datarow.Cells[0].Value = checkBox2.CheckState;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                foreach (DataGridViewRow datarow in dataGridView3.Rows)
                {
                    try
                    {

                        if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                        {


                            cmd.Connection = con;
                            cmd.CommandText = "Delete from  inwardoutward where id='" + datarow.Cells[1].Value.ToString() + "'";
                            //id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                            //cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                            //MessageBox.Show("Deleted Successfully");
                            cmd.ExecuteNonQuery();

                        }
                    }





                    catch (Exception)
                    {
                        //MessageBox.Show(exe.Message);
                    }


                }

                MessageBox.Show("Deleted Successfully");
                // clear();
                con.Close();
                Disp();
                //counterno();
            }
        }
        void autocomplete()
        {



            //party.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //party.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            //try
            //{
            //    string constring = AppSetting.ConnectionString();
            //    MySqlConnection con = new MySqlConnection(constring);
            //    MySqlCommand command;
            //    MySqlDataReader mdr;
            //    con.Open();
            //    string selectQuery = "select name from `clientcontact`";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        coll.Add(mdr.GetString("name"));
            //    }
            //    mdr.Close();
       // }
        try
            {
                string constring = AppSetting.ConnectionString();
                
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command = new MySqlCommand("select name from clientcontact",con);
                con.Open();
                MySqlDataReader dr = command.ExecuteReader();
                AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

                while(dr.Read())
                {
                    mycollection.Add(dr.GetString(0));
                }
                //MessageBox.Show(mycollection);
                party.AutoCompleteCustomSource = mycollection;
                con.Close();




            }

            catch (Exception)
            {
              //  MessageBox.Show(exe.Message);
            }
          //  party.AutoCompleteCustomSource = coll;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tm_TextChanged(object sender, EventArgs e)
        {
            // int tmm = Convert.ToInt32(textBox3.Text);
            tmupdate();
        }

        private void outsrno_TextChanged(object sender, EventArgs e)
        {
            if (outsrno.Text == "")
            {
                clearout();   
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
                    string selectQuery = "select *  from `inwardoutward` where billno = '" + outsrno.Text + "'";
                    command = new MySqlCommand(selectQuery, con);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        outparty.Text = mdr.GetString("customer");
                        outgrosswt.Text = mdr.GetString("wt");
                        outgroswt.Text = mdr.GetString("grossamt");
                        textBox4.Text = mdr.GetString("bagweight");
                        textBox5.Text = mdr.GetString("itemweight");
                       

                    }
                    else
                    {
                        clearout();
                    }

                    mdr.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show(exe.Message);
                }
            }
        }

        private void bagoutwt_TextChanged(object sender, EventArgs e)
        {
            inwardcalc();
        }

        private void inwardcalc()
        {
            try
            {
                if (outgrosswt.Text != null && bagoutwt.Text !=null)
                {

                    float itemwt = float.Parse(outgrosswt.Text);
                    float bagwt = float.Parse(bagoutwt.Text);
                    float gross = itemwt + bagwt;
                    totin = gross.ToString();
                }
                else
                {
                    totin = outgrosswt.Text;
                }
            }
            catch (Exception)
            {

            }
        }

        private void otwt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void etc_TextChanged(object sender, EventArgs e)
        {
            if (etcval.Text != "" || outgroswt.Text !="")
            {
                float groswt = float.Parse(outgroswt.Text);
                float etc = float.Parse(etcval.Text);
                float tot = groswt + etc;
                nettotal.Text = tot.ToString();

            }
            else
            {
                nettotal.Text = "0";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void wt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void inwardpannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void scan_TextChanged(object sender, EventArgs e)
        {
           

            //inwt.Text = output;
            //scan.Text = "";


            //28.12.2019     10.15AM
            //                  45.2  g



            //if (scan.Text != "" && scan.Lines.Length>1)
            //{
            //    String str = scan.Text;
            //    string output = scan.Lines[1];
            //    output = output.Substring(0, output.IndexOf("g"));
            //    inwt.Text = output.Trim();
            //    scan.Text = "";
            //}

            // String str = "20.12.2019  5.23PM/36.27g";
            //// str.Split(str);

            // String[] spearator = { "/", "g" };
            // Int32 count = 2;

            // // using the method 
            // String[] strlist = str.Split(spearator, count,
            //        StringSplitOptions.RemoveEmptyEntries);

            // foreach (String s in strlist)
            // {
            //     MessageBox.Show(s);
            // }
        }

        private void inbagscan_TextChanged(object sender, EventArgs e)
        {
           
            //if (inbagscan.Text != "" && inbagscan.Lines.Length>1)
            //{
            //    String str = inbagscan.Text;
            //    string output = inbagscan.Lines[1];
            //    output = output.Substring(0, output.IndexOf("g"));
            //    outwt.Text = output;
            //    inbagscan.Text = "";
            //}
        }

        private void outscan_TextChanged(object sender, EventArgs e)
        {

            //if (outscan.Text != "" && outscan.Lines.Length>1)
            //{
            //    String str = outscan.Text;
            //    string output = outscan.Lines[1];
            //    output = output.Substring(0, output.IndexOf("g"));
            //    outitemwt.Text = output;
            //    outscan.Text = "";

            //    // 12.12.2019  15.56Am/56.456g
            //}
        }

        private void outbagscan_TextChanged(object sender, EventArgs e)
        {

            //if (outbagscan.Text != "" && outbagscan.Lines.Length>1 )
            //{
            //    String str = outbagscan.Text;
            //    string output = outbagscan.Lines[1];
            //    output = output.Substring(0, output.IndexOf("g"));
            //    bagoutwt.Text = output;
            //    outbagscan.Text = "";

            //   // 12.12.2019  15.56Am/56.456g
            //}
        }

        private void party_TextChanged(object sender, EventArgs e)
        {

        }

        private void outparty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

      

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand();
                    con.Open();

                    //foreach (DataGridViewRow datarow in dataGridView2.Rows)
                    //{
                    try
                    {

                        //if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                        //{


                        cmd.Connection = con;
                        cmd.CommandText = "Delete from  inwardoutward where id=?id";
                        id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                        cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                        //MessageBox.Show("Deleted Successfully");
                        cmd.ExecuteNonQuery();

                        //  }
                        counterno();
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception)
                    {
                       // MessageBox.Show(exe.Message);
                    }


                    //}

                   
                    // clear();
                    con.Close();
                    Disp();
                    counterno();
                }
                else //if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Disp();
                    counterno();
                }

            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();

                //foreach (DataGridViewRow datarow in dataGridView2.Rows)
                //{
                try
                {

                    //if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                    //{


                    cmd.Connection = con;
                    cmd.CommandText = "Delete from  inwardoutward where id=?id";
                    id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                    cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                    //MessageBox.Show("Deleted Successfully");
                    cmd.ExecuteNonQuery();

                    //  }
                    counterno();
                }
                catch (Exception )
                {
                   // MessageBox.Show(exe.Message);
                }


                //}

                MessageBox.Show("Deleted Successfully");
                // clear();
                con.Close();
                Disp();
                counterno();
            }
            else //if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                Disp();
            }
        }

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        

            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string constring = AppSetting.ConnectionString();
                        MySqlConnection con = new MySqlConnection(constring);
                        MySqlCommand cmd = new MySqlCommand();
                        con.Open();

                        //foreach (DataGridViewRow datarow in dataGridView2.Rows)
                        //{
                        try
                        {

                            //if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                            //{


                            cmd.Connection = con;
                            cmd.CommandText = "Delete from  inwardoutward where id=?id";
                            id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                            cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                            //MessageBox.Show("Deleted Successfully");
                            cmd.ExecuteNonQuery();

                            //  }
                            counterno();
                        MessageBox.Show("Deleted Successfully");
                    }
                        catch (Exception )
                        {
                           // MessageBox.Show(exe.Message);
                        }


                        //}

                       
                        // clear();
                        con.Close();
                        Disp();
                        counterno();
                    }
                    else //if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        Disp();
                    }

                }
            }

        private void dataGridView4_KeyDown(object sender, KeyEventArgs e)

        {
            int ab;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string constring = AppSetting.ConnectionString();
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlCommand abc = new MySqlCommand();
                    con.Open();

                    //foreach (DataGridViewRow datarow in dataGridView2.Rows)
                    //{
                    try
                    {

                        //if (Boolean.Parse(datarow.Cells[0].Value.ToString()))
                        //{


                        cmd.Connection = con;
                        cmd.CommandText = "Delete from  bill where id=?id";
                        id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;



                        //MessageBox.Show("Deleted Successfully");
                        cmd.ExecuteNonQuery();
                        abc.Connection = con;
                        // cmd.CommandText = "UPDATE inwardoutward set grossamt=?etc where billno=?id";
                        abc.CommandText = "UPDATE inwardoutward set grossamt = ?amt where billno = ?billno";
                        ab = Convert.ToInt32(dataGridView4.CurrentRow.Cells[1].Value.ToString());
                        abc.Parameters.Add("?billno", MySqlDbType.VarChar).Value = ab;

                        abc.Parameters.Add("?amt", MySqlDbType.VarChar).Value = "0";

                        // abc.Parameters.Add("?party", MySqlDbType.VarChar).Value = billparty.Text;
                        //abc.Parameters.Add("?amt", MySqlDbType.VarChar).Value = totamt.Text;
                        abc.ExecuteNonQuery();

                        //  }
                        counterno();
                        

                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception )
                    {
                       // MessageBox.Show(exe.Message);
                    }


                    //}

                    // clear();
                    con.Close();
                    Disp();
                    counterno();
                    grandtotals();
                }
                else //if (MessageBox.Show("Do you really want to Delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Disp();
                }

            }
        }

        private void outwardpannel_TabIndexChanged(object sender, EventArgs e)
        {

            inout.Show();
            if (outsrno.Focused)
            {
                // MessageBox.Show("Focused");
            }
            else
            {
                outsrno.Focus();
                //MessageBox.Show(" Not Focused");
            }
        }

        private void inout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(inout.SelectedIndex == 0)
            {
                party.Focus();
            }
            else if(inout.SelectedIndex == 1)
            {
                outsrno.Focus();
            }
        }

        private void InwardOutward_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                inout.SelectedTab = Outward;
            }
            else if (e.KeyCode == Keys.F1)
            {
                inout.SelectedTab = Inward;
            }
        }

        private void party_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void outsrno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                inout.SelectedTab = Outward;
            }
            else if (e.KeyCode == Keys.F1)
            {
                inout.SelectedTab = Inward;
            }

        }

       

        private void addbtn_KeyDown(object sender, KeyEventArgs e)
        {
            
           if(e.KeyCode == Keys.Right)
            {
                sve.Focus();
                return;
            }

        }

        private void addbtn_Leave(object sender, EventArgs e)
        {
           
                billitem.Focus();
           // addbtn_KeyDown(object sender, KeyEventArgs e);


        }

        private void scan_Leave(object sender, EventArgs e)
        {
            if (scan.Text != " " && scan.Lines.Length > 1)
            {
                String str = scan.Text;
                string output = scan.Lines[1];
                output = output.Substring(0, output.IndexOf("g"));
                inwt.Text = output.Trim();
                scan.Text = "";
            }
            inwarddttm();
            scan.BackColor = Color.White;
        }

        private void inbagscan_Leave(object sender, EventArgs e)
        {
            if (inbagscan.Text != "" && inbagscan.Lines.Length > 1)
            {
                String str = inbagscan.Text;
                string output = inbagscan.Lines[1];
                output = output.Substring(0, output.IndexOf("g"));
                outwt.Text = output.Trim();
                inbagscan.Text = "";
            }
            inbagscan.BackColor = Color.White;
        }

        private void outscan_Leave(object sender, EventArgs e)
        {

            if (outscan.Text != "" && outscan.Lines.Length > 1)
            {
                String str = outscan.Text;
                string output = outscan.Lines[1];
                output = output.Substring(0, output.IndexOf("g"));
                outitemwt.Text = output.Trim();
                outscan.Text = "";

                // 12.12.2019  15.56Am/56.456g
            }
            outwarddttm();
            outscan.BackColor = Color.White;
        }

        private void outbagscan_Leave(object sender, EventArgs e)
        {

            if (outbagscan.Text != "" && outbagscan.Lines.Length > 1)
            {
                String str = outbagscan.Text;
                string output = outbagscan.Lines[1];
                output = output.Substring(0, output.IndexOf("g"));
                bagoutwt.Text = output.Trim();
                outbagscan.Text = "";

                // 12.12.2019  15.56Am/56.456g
            }
            outbagscan.BackColor = Color.White;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            inwt.Enabled = checkBox3.Checked;
            outwt.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            outitemwt.Enabled = checkBox4.Checked;
            bagoutwt.Enabled = checkBox4.Checked;
            outgroswt.Enabled = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            billrate.Enabled = checkBox5.Checked;
            billamt.Enabled = checkBox5.Checked;
            billminamt.Enabled = checkBox5.Checked;

        }

        private void totamt_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemsadd_Enter(object sender, EventArgs e)
        {
            grandtotals();
        }

        private void itemsadd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            grandtotals();
        }

        private void inwt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                wt.Text = (float.Parse(inwt.Text)+float.Parse(outwt.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void outitemwt_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    float itemwt = float.Parse(outitemwt.Text);
            //    float bagwt = float.Parse(bagoutwt.Text);
            //    float gross = itemwt - bagwt;
            //    otwt.Text = gross.ToString();
            //}
            //catch (Exception)
            //{

            //}
        }

        private void outitemwt_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                otwt.Text = outitemwt.Text;
            }
            catch (Exception)
            {

            }
        }

        private void outgrosswt_TextChanged(object sender, EventArgs e)
        {

        }

        private void billamt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sve.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = { 1254, 54121, 421 };
            for (int i=0; i<arr.Length;i++)
            {
                scan.Lines[i] = arr[i].ToString();

            }
           

        }

        private void tm_Leave(object sender, EventArgs e)
        {
            // int tmm = Convert.ToInt32(textBox3.Text);
            if (tm.Text != "")
            {



                textBox3.Text = DateTime.Now.AddHours(double.Parse(tm.Text)).ToString("hh:mm tt");
                // = string.Format("hh:mm tt",deltime);
            }
            else
            {
                textBox3.Text = "";
            }
            tm.BackColor = Color.White;
        }

        private void loss_TextChanged(object sender, EventArgs e)
        {

        }

        private void otwt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void outgroswt_TextChanged(object sender, EventArgs e)
        {
            if (etcval.Text != "" && outgroswt.Text != "")
            {
                float groswt = float.Parse(outgroswt.Text);
                float etc = float.Parse(etcval.Text);
                float tot = groswt + etc;
                nettotal.Text = tot.ToString();

            }
            else
            {
                nettotal.Text = "0";
            }
        }
        void tmupdate()
        {
            if (tm.Text != "")
            {

                textBox3.Text = DateTime.Now.AddHours(double.Parse(tm.Text)).ToString("hh:mm tt");
                // = string.Format("hh:mm tt",deltime);
            }
            else
            {
                MessageBox.Show("Delivery time cannot be blank!");
                tm.Focus();
                textBox3.Text = "";
            }

        }

        private void tm_Enter(object sender, EventArgs e)
        {
            tm.BackColor = Color.Aqua;
        }

        private void srno_Enter(object sender, EventArgs e)
        {
            srno.BackColor = Color.Aqua;
        }

        private void srno_Leave(object sender, EventArgs e)
        {
            srno.BackColor = Color.White;
        }

        private void party_Enter(object sender, EventArgs e)
        {
            party.BackColor = Color.Aqua;
        }

        private void party_Leave(object sender, EventArgs e)
        {
            party.BackColor = Color.White;
        }

        private void scan_Enter(object sender, EventArgs e)
        {
            scan.BackColor = Color.Aqua;
        }

        private void indttm_TextChanged(object sender, EventArgs e)
        {

        }

        private void inbagscan_Enter(object sender, EventArgs e)
        {
            inbagscan.BackColor = Color.Aqua;

        }

        private void outsrno_Enter(object sender, EventArgs e)
        {
            outsrno.BackColor = Color.Aqua;
        }

        private void outsrno_Leave(object sender, EventArgs e)
        {
            outsrno.BackColor = Color.White;
        }

        private void outscan_Enter(object sender, EventArgs e)
        {
            outscan.BackColor = Color.Aqua;
        }

        private void outbagscan_Enter(object sender, EventArgs e)
        {
            outbagscan.BackColor = Color.Aqua;
        }

        private void etcval_Enter(object sender, EventArgs e)
        {
            etcval.BackColor = Color.Aqua;
        }

        private void etcval_Leave(object sender, EventArgs e)
        {
            etcval.BackColor = Color.White;
        }

        private void outitemwt_Enter(object sender, EventArgs e)
        {
            outitemwt.BackColor = Color.Aqua;
        }

        private void outitemwt_Leave(object sender, EventArgs e)
        {
            outitemwt.BackColor = Color.White;
        }

        private void bagoutwt_Enter(object sender, EventArgs e)
        {
            bagoutwt.BackColor = Color.Aqua;
        }

        private void bagoutwt_Leave(object sender, EventArgs e)
        {
            bagoutwt.BackColor = Color.White;
        }

        private void billsrno_Enter(object sender, EventArgs e)
        {
            billsrno.BackColor = Color.Aqua;
        }

        private void billsrno_Leave(object sender, EventArgs e)
        {
            billsrno.BackColor = Color.White;
        }

        private void billitem_Enter(object sender, EventArgs e)
        {
            billitem.BackColor = Color.Aqua;
        }

        private void billitem_Leave(object sender, EventArgs e)
        {
            billitem.BackColor = Color.White;
        }

        private void billqty_Enter(object sender, EventArgs e)
        {
            billqty.BackColor = Color.Aqua;
        }

        private void billqty_Leave(object sender, EventArgs e)
        {
            billqty.BackColor = Color.White;
        }
    }
    
}
