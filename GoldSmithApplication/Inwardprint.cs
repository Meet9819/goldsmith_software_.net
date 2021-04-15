using DGVPrinterHelper;
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
    public partial class Inwardprint : Form
    {
        PrintPreviewDialog prntprw = new PrintPreviewDialog();
        PrintDocument pntDoc = new PrintDocument();
      

        public Inwardprint()
        {
            InitializeComponent();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Inwardprint_Load(object sender, EventArgs e)
        {
            int ind = InwardOutward.inwtt.IndexOf('.');
            string s = InwardOutward.inwtt;
            if (ind >= 0)
            {
                //int ind = InwardOutward.inwtt.IndexOf('.');
                s = s.Insert(ind + 1, " ");
              s = s.Insert(ind, " ");
              s= s.Replace('.', ':');
            }
           
           

            custname.Text = InwardOutward.usrnm;
            srno.Text = InwardOutward.billno;
            indttm.Text = InwardOutward.indt;
            inwt.Text = s + "  g";//InwardOutward.inwtt.Replace('.',':') + "  g";
            deliverytm.Text = InwardOutward.delivrytm ;

            print(this.panel1);

            //printDocument1.Print();
            this.Close();
        }

        string rep(string s)
        {
            //int ind;
            string sm = s;
            for (int i = 0; i < sm.Length; i++)
            {
                if(sm[i]=='.')
                {
                    sm = s.Insert(sm[i] + 1, " ");
                    sm = sm.Insert(sm[i], " ");
                }
            }
        

            return sm;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            
        }
        public void print(Panel p)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = p;
            getprintarea(p);
            //prntprw.Document = pntDoc;
            pntDoc.PrintPage += new PrintPageEventHandler(pntDoc_printpage);
            //prntprw.ShowDialog();
            pntDoc.Print();


        }
        public void pntDoc_printpage(object sender,PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        Bitmap memoryimg;
        public void getprintarea(Panel p)
        {
            memoryimg = new Bitmap(p.Width, p.Height);
            p.DrawToBitmap(memoryimg,new Rectangle(0,0,p.Width,p.Height));

        }

     

        private void btncancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }







        private void btnprint_Click_1(object sender, EventArgs e)
        {
            print(this.panel1);

            ////printDocument1.Print();
            this.Close();

           




        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        { 
        }
    }
}
