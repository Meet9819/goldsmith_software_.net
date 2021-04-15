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
using System.Drawing.Printing;
using DGVPrinterHelper;

namespace GoldSmithApplication
{
    public partial class Summary : Form
    {
        public static float grandtotal=0;
        public static float grandtotal1=0;
        public static float grandtotal2 = 0;
        PrintPreviewDialog prntprw = new PrintPreviewDialog();
        PrintDocument pntDoc = new PrintDocument();
        public int id;
        public static string totin;
        public static string totout;
        public static string totloss;
        public static string bag;
        public static string etc;
        public static string net;

        public Summary()
        {
            InitializeComponent();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            disp();
            grandtotals();
            //try
            //{
            //    string constring = AppSetting.ConnectionString();
            //    MySqlConnection con = new MySqlConnection(constring);
            //    MySqlCommand command;
            //    MySqlDataReader mdr;
            //    con.Open();
            //    string selectQuery = "select totalloss,totaletc from `clientcontact`";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        coll.Add(mdr.GetString("name"));
            //    }
            //    mdr.Close();
            //}
            //catch (Exception exe)
            //{
            //    MessageBox.Show(exe.Message);
            //}
           




        }
       public void disp()
        {
            try
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand command;
                MySqlDataAdapter da;
                DataTable table = new DataTable();
                string selectQuery = "SELECT id, date as DATE,totalloss as LOSS,recovery as REC,totalnet as AMT FROM summary";
                command = new MySqlCommand(selectQuery, con);
                da = new MySqlDataAdapter(command);
                //for inward data display
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 20;
                dataGridView1.AllowUserToAddRows = false;

                da.Fill(table);
                dataGridView1.DataSource = table;
               // dataGridView1.Columns[0].Visible = false;

                grandtotals();

            }
            catch (Exception )
            {
              //  MessageBox.Show(exe.Message);
            }
            //try
            //{
            //    string constring = AppSetting.ConnectionString();
            //    MySqlConnection con = new MySqlConnection(constring);
            //    MySqlCommand command;
            //    MySqlDataReader mdr;
            //    con.Open();
            //    string selectQuery = "select Round(Sum(wt),2) as 'totalinward' from `inwardoutward` where mode='IN'";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totalinward.Text = mdr.GetString("totalinward");
            //    }
            //    mdr.Close();
            //    selectQuery = "select Round(Sum(outwt),2) as 'totaloutward' from `inwardoutward` where mode='OUT'";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totaloutward.Text = mdr.GetString("totaloutward");
            //    }
            //    mdr.Close();
            //    selectQuery = "select Round(Sum(bagweight),2) as 'bgweight' from `inwardoutward`";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totalbag.Text = mdr.GetString("bgweight");
            //    }
            //    mdr.Close();
            //    selectQuery = "select Round(Sum(etc),2) as 'etc' from `inwardoutward` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        textBox4.Text = mdr.GetString("etc");
            //    }
            //    mdr.Close();
            //    selectQuery = "select Round(Sum(loss),2) as 'loss' from `inwardoutward` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        textBox5.Text = mdr.GetString("loss");
            //    }
            //    mdr.Close();
            //    selectQuery = "select Round(Sum(netamount),2) as 'net' from `inwardoutward` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totalnet.Text = mdr.GetString("net");
            //    }
            //    mdr.Close();


            //    //summary values
            //    selectQuery = "select Round(Sum(totalloss),2) as 'loss' from `summary` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totalloss.Text = mdr.GetString("loss");
            //    }
            //    mdr.Close();

            //    selectQuery = "select Round(Sum(totalnet),2) as 'nett' from `summary` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        totaletc.Text = mdr.GetString("nett");
            //    }
            //    mdr.Close();

            //    selectQuery = "select Round(Sum(recovery),2) as 'rec' from `summary` ";
            //    command = new MySqlCommand(selectQuery, con);
            //    mdr = command.ExecuteReader();
            //    if (mdr.Read())
            //    {
            //        rec.Text = mdr.GetString("rec");
            //    }
            //    mdr.Close();





            //}
            //catch (Exception)
            //{
            //    // MessageBox.Show(exe.Message);
            //}

        }
        private void grandtotals()
        {
            grandtotal = 0;
            grandtotal1 = 0;
            grandtotal2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                grandtotal += float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                grandtotal1 += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                grandtotal2 += float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
           totalloss .Text = grandtotal.ToString();
            totaletc.Text = grandtotal1.ToString();
            rec.Text = grandtotal2.ToString();
          
        }

        private void delinward_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to Delete All  Records from Database?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete  from  inwardoutward";
                   

                    
                    cmd.ExecuteNonQuery();
                    billdel();
                    MessageBox.Show("Deleted Successfully");
                    disp();

                }

                catch (Exception )
                {
                  //  MessageBox.Show(exe.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

       void billdel()
        {

                string constring = AppSetting.ConnectionString();
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand();

                try
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete  from  bill";
                   


                    
                    cmd.ExecuteNonQuery();
                   // MessageBox.Show("Deleted Successfully");
                    disp();

                }

                catch (Exception )
                {
                  //  MessageBox.Show(exe.Message);
                }
                finally
                {
                    con.Close();
                }
            
        }

        private void delsummary_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to Delete All Summary Records?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sumdel("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                sumdel("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
            }
        }

        private void sumdel(string v)
        {
           // string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Delete  from  Summary";




                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");

                disp();
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {

                if (MessageBox.Show("Do you really want to Delete All Summary Records?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    keydel("Server = localhost; port = 3306; Database = Goldsmith; Uid = 'root'; ");
                    keydel("Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'");
                }

                else
                {
                    disp();
                }
            }
        }

        void keydel(string v)
        {

            //string constring = AppSetting.ConnectionString();
            MySqlConnection con = new MySqlConnection(v);
            MySqlCommand cmd = new MySqlCommand();

            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Delete  from  Summary where id=?id";
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;




                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");

                disp();
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
    


        //print



        public void ptr(DataGridView p)
        {
            PrinterSettings ps = new PrinterSettings();
            dataGridView1 = p;
            getprintarea(p);
            prntprw.Document = pntDoc;
            pntDoc.PrintPage += new PrintPageEventHandler(pntDoc_printpage);
            prntprw.ShowDialog();


        }
        public void pntDoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width/2 ) - (this.dataGridView1.Width/2 ), this.dataGridView1.Location.Y);
        }
        Bitmap memoryimg;
        public void getprintarea(DataGridView p)
        {
            memoryimg = new Bitmap(p.Width, p.Height);
            p.DrawToBitmap(memoryimg, new Rectangle(0, 0, p.Width, p.Height));

        }

        private void print_Click(object sender, EventArgs e)
        {
           // ptr(dataGridView1);

            DGVPrinter printer = new DGVPrinter();
            printer.PrintDataGridView(dataGridView1);
            // printer.ShowTotalPageNumber = false;

            printer.PageNumbers = false;
            printer.Footer = "Loss:" + totalloss.Text + "Amt:" + totaletc.Text + "rec: " + rec.Text;
            //MessageBox.Show("Loss:" + totalloss.Text + "Amt:" + totaletc.Text + "rec: " + rec.Text);
        }
        private void summary_Click(object sender, EventArgs e)
        {
            recovery rc = new recovery();
            //     public static float totin;
            //public static float totout;
            //public static float totloss;
            //public static float bag;
            //public static float etc;
            //public static float net;
            totin = totalinward.Text;
            totout = totaloutward.Text;
            bag = totalbag.Text;
            etc = totaletc.Text;
            totloss = textBox5.Text;
            etc = textBox4.Text;
            net = totalnet.Text;

      

            rc.Show();
           // Form1 ab = new Form1();
            

            disp();
            grandtotals();

            

        }
    }
}
