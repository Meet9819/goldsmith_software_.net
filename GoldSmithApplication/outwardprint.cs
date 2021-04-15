using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldSmithApplication
{
    public partial class outwardprint : Form
    {
        PrintPreviewDialog prntprw = new PrintPreviewDialog();
        PrintDocument pntDoc = new PrintDocument();
        public outwardprint()
        {
            InitializeComponent();
        }
        public void print(Panel p)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = p;
            getprintarea(p);
           // prntprw.Document = pntDoc;
            pntDoc.PrintPage += new PrintPageEventHandler(pntDoc_printpage);
            //prntprw.ShowDialog();
            pntDoc.Print();


        }
        public void pntDoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        Bitmap memoryimg;
        public void getprintarea(Panel p)
        {
            memoryimg = new Bitmap(p.Width, p.Height);
            p.DrawToBitmap(memoryimg, new Rectangle(0, 0, p.Width, p.Height));

        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            print(this.panel1);
            this.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
        
        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }


        private void outwardprint_Load(object sender, EventArgs e)
        {
            custname.Text = InwardOutward.custname;
            srno.Text = InwardOutward.bilsrno;
            currentdttm.Text = InwardOutward.dttm;
            inweight.Text = (InwardOutward.totalin) + "  g";
            inbag.Text = InwardOutward.inwardbag + "  g";
            wt.Text = InwardOutward.totin + "  g";
            outwt.Text = InwardOutward.totalout + "  g";
            loss.Text = InwardOutward.totloss + "  g";
            grosamt.Text = InwardOutward.cutting + "  ₹";
            etc.Text = InwardOutward.khol + "  ₹";
            totalamt.Text =  InwardOutward.totamts + "  ₹";
            //inwt.Height = 16;




            inwt.Text = rep(InwardOutward.totalin.ToString()) + "  g";//(InwardOutward.totalin) + "  g";
            inbg.Text = rep(InwardOutward.inwardbag.ToString()) + "  g";
            intot.Text = rep(InwardOutward.totin.ToString()) + "  g";
            otwt.Text = rep(InwardOutward.totalout.ToString()) + "  g";
            lss.Text = rep(InwardOutward.totloss.ToString()) + "  g";
            ctn.Text =  rep(InwardOutward.cutting.ToString()) + "  ₹";
            khol.Text =  rep(InwardOutward.khol.ToString()) + "  ₹";
            tot.Text =  rep(InwardOutward.totamts.ToString()) + "  ₹";

            print(this.panel1);
            this.Close();

        }
        string rep(string s)
        {
            string sm = s;
            int ind = s.IndexOf('.');
            if (ind >= 0)
            {

                sm = s.Insert(ind + 1, " ");
                sm = sm.Insert(ind, " ");
                sm = sm.Replace('.', ':');
                return sm;
            }
            else
            {
                return sm;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tot_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
