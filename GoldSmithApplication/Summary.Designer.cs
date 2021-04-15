namespace GoldSmithApplication
{
    partial class Summary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.delsummary = new System.Windows.Forms.Button();
            this.delinward = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.totaletc = new System.Windows.Forms.TextBox();
            this.totalloss = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rec = new System.Windows.Forms.TextBox();
            this.totalnet = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.totalbag = new System.Windows.Forms.TextBox();
            this.totaloutward = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.totalinward = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.print);
            this.panel1.Controls.Add(this.delsummary);
            this.panel1.Controls.Add(this.delinward);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 509);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(28, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 45);
            this.button1.TabIndex = 61;
            this.button1.Text = "Save summary for the day";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.summary_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(639, 517);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(481, 517);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 6;
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(552, 9);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(188, 45);
            this.print.TabIndex = 3;
            this.print.Text = "PRINT";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // delsummary
            // 
            this.delsummary.Location = new System.Drawing.Point(358, 9);
            this.delsummary.Name = "delsummary";
            this.delsummary.Size = new System.Drawing.Size(188, 45);
            this.delsummary.TabIndex = 3;
            this.delsummary.Text = "Delete SUMMARY records";
            this.delsummary.UseVisualStyleBackColor = true;
            this.delsummary.Click += new System.EventHandler(this.delsummary_Click);
            // 
            // delinward
            // 
            this.delinward.Location = new System.Drawing.Point(193, 9);
            this.delinward.Name = "delinward";
            this.delinward.Size = new System.Drawing.Size(159, 45);
            this.delinward.TabIndex = 3;
            this.delinward.Text = "Delete ALL INWARD /OUTWARD/ BILL";
            this.delinward.UseVisualStyleBackColor = true;
            this.delinward.Click += new System.EventHandler(this.delinward_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1001, 449);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // totaletc
            // 
            this.totaletc.Enabled = false;
            this.totaletc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaletc.Location = new System.Drawing.Point(359, 515);
            this.totaletc.Name = "totaletc";
            this.totaletc.Size = new System.Drawing.Size(100, 26);
            this.totaletc.TabIndex = 7;
            // 
            // totalloss
            // 
            this.totalloss.Enabled = false;
            this.totalloss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalloss.Location = new System.Drawing.Point(124, 518);
            this.totalloss.Name = "totalloss";
            this.totalloss.Size = new System.Drawing.Size(100, 26);
            this.totalloss.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Loss:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(478, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Recover";
            // 
            // rec
            // 
            this.rec.Enabled = false;
            this.rec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rec.Location = new System.Drawing.Point(604, 515);
            this.rec.Name = "rec";
            this.rec.Size = new System.Drawing.Size(100, 26);
            this.rec.TabIndex = 7;
            // 
            // totalnet
            // 
            this.totalnet.Enabled = false;
            this.totalnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalnet.Location = new System.Drawing.Point(529, 598);
            this.totalnet.Name = "totalnet";
            this.totalnet.Size = new System.Drawing.Size(100, 24);
            this.totalnet.TabIndex = 59;
            this.totalnet.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(326, 598);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 24);
            this.textBox4.TabIndex = 60;
            this.textBox4.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(113, 598);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 24);
            this.textBox5.TabIndex = 58;
            this.textBox5.Visible = false;
            // 
            // totalbag
            // 
            this.totalbag.Enabled = false;
            this.totalbag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalbag.Location = new System.Drawing.Point(529, 559);
            this.totalbag.Name = "totalbag";
            this.totalbag.Size = new System.Drawing.Size(100, 24);
            this.totalbag.TabIndex = 57;
            this.totalbag.Visible = false;
            // 
            // totaloutward
            // 
            this.totaloutward.Enabled = false;
            this.totaloutward.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaloutward.Location = new System.Drawing.Point(326, 559);
            this.totaloutward.Name = "totaloutward";
            this.totaloutward.Size = new System.Drawing.Size(100, 24);
            this.totaloutward.TabIndex = 56;
            this.totaloutward.Visible = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(449, 601);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 18);
            this.label51.TabIndex = 53;
            this.label51.Text = "NET:  ₹";
            this.label51.Visible = false;
            // 
            // totalinward
            // 
            this.totalinward.Enabled = false;
            this.totalinward.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalinward.Location = new System.Drawing.Point(113, 559);
            this.totalinward.Name = "totalinward";
            this.totalinward.Size = new System.Drawing.Size(100, 24);
            this.totalinward.TabIndex = 55;
            this.totalinward.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(220, 601);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 18);
            this.label19.TabIndex = 54;
            this.label19.Text = "ETC :   ₹";
            this.label19.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(26, 601);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 18);
            this.label18.TabIndex = 52;
            this.label18.Text = "Tot Loss";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(443, 562);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 18);
            this.label17.TabIndex = 51;
            this.label17.Text = "Total Bag";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(219, 562);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 18);
            this.label16.TabIndex = 50;
            this.label16.Text = "Tot Outward";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 562);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 18);
            this.label15.TabIndex = 49;
            this.label15.Text = "Tot Inward";
            this.label15.Visible = false;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 691);
            this.Controls.Add(this.totalnet);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.totalbag);
            this.Controls.Add(this.totaloutward);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.totalinward);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.rec);
            this.Controls.Add(this.totaletc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalloss);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Summary";
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.Summary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button delinward;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox totaletc;
        private System.Windows.Forms.TextBox totalloss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button delsummary;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rec;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox totalnet;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox totalbag;
        private System.Windows.Forms.TextBox totaloutward;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox totalinward;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}