namespace FirstSpeechTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.sp_fusionBrain6 = new System.IO.Ports.SerialPort(this.components);
            this.tb_log = new System.Windows.Forms.TextBox();
            this.txb_ch1_on = new System.Windows.Forms.TextBox();
            this.lbl_ch1_on = new System.Windows.Forms.Label();
            this.gb_ch_1 = new System.Windows.Forms.GroupBox();
            this.lbl_ch1_off = new System.Windows.Forms.Label();
            this.txb_ch1_off = new System.Windows.Forms.TextBox();
            this.btn_grammarChange = new System.Windows.Forms.Button();
            this.nud_com_number = new System.Windows.Forms.NumericUpDown();
            this.lbl_com_number = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_ch4_off = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_ch4_on = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_ch3_off = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_ch3_on = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_ch2_off = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_ch2_on = new System.Windows.Forms.TextBox();
            this.btn_addChannel = new System.Windows.Forms.Button();
            this.lbl_allOn = new System.Windows.Forms.Label();
            this.lbl_allOff = new System.Windows.Forms.Label();
            this.txb_all_on = new System.Windows.Forms.TextBox();
            this.txb_all_off = new System.Windows.Forms.TextBox();
            this.lbl_about = new System.Windows.Forms.Label();
            this.gb_ch_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_com_number)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp_fusionBrain6
            // 
            this.sp_fusionBrain6.PortName = "COM8";
            // 
            // tb_log
            // 
            this.tb_log.Enabled = false;
            this.tb_log.Location = new System.Drawing.Point(12, 339);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(516, 171);
            this.tb_log.TabIndex = 1;
            // 
            // txb_ch1_on
            // 
            this.txb_ch1_on.Location = new System.Drawing.Point(47, 16);
            this.txb_ch1_on.Name = "txb_ch1_on";
            this.txb_ch1_on.Size = new System.Drawing.Size(335, 20);
            this.txb_ch1_on.TabIndex = 2;
            this.txb_ch1_on.Text = "light 1 on";
            // 
            // lbl_ch1_on
            // 
            this.lbl_ch1_on.AutoSize = true;
            this.lbl_ch1_on.Location = new System.Drawing.Point(6, 16);
            this.lbl_ch1_on.Name = "lbl_ch1_on";
            this.lbl_ch1_on.Size = new System.Drawing.Size(21, 13);
            this.lbl_ch1_on.TabIndex = 3;
            this.lbl_ch1_on.Text = "On";
            // 
            // gb_ch_1
            // 
            this.gb_ch_1.Controls.Add(this.lbl_ch1_off);
            this.gb_ch_1.Controls.Add(this.txb_ch1_off);
            this.gb_ch_1.Controls.Add(this.lbl_ch1_on);
            this.gb_ch_1.Controls.Add(this.txb_ch1_on);
            this.gb_ch_1.Location = new System.Drawing.Point(3, 3);
            this.gb_ch_1.Name = "gb_ch_1";
            this.gb_ch_1.Size = new System.Drawing.Size(395, 68);
            this.gb_ch_1.TabIndex = 4;
            this.gb_ch_1.TabStop = false;
            this.gb_ch_1.Text = "Channel 1";
            // 
            // lbl_ch1_off
            // 
            this.lbl_ch1_off.AutoSize = true;
            this.lbl_ch1_off.Location = new System.Drawing.Point(6, 41);
            this.lbl_ch1_off.Name = "lbl_ch1_off";
            this.lbl_ch1_off.Size = new System.Drawing.Size(21, 13);
            this.lbl_ch1_off.TabIndex = 5;
            this.lbl_ch1_off.Text = "Off";
            // 
            // txb_ch1_off
            // 
            this.txb_ch1_off.Location = new System.Drawing.Point(47, 41);
            this.txb_ch1_off.Name = "txb_ch1_off";
            this.txb_ch1_off.Size = new System.Drawing.Size(335, 20);
            this.txb_ch1_off.TabIndex = 4;
            this.txb_ch1_off.Text = "light 1 off";
            // 
            // btn_grammarChange
            // 
            this.btn_grammarChange.Location = new System.Drawing.Point(426, 94);
            this.btn_grammarChange.Name = "btn_grammarChange";
            this.btn_grammarChange.Size = new System.Drawing.Size(102, 52);
            this.btn_grammarChange.TabIndex = 6;
            this.btn_grammarChange.Text = "Apply Command Changes";
            this.btn_grammarChange.UseVisualStyleBackColor = true;
            this.btn_grammarChange.Click += new System.EventHandler(this.btn_grammarChange_Click);
            // 
            // nud_com_number
            // 
            this.nud_com_number.Location = new System.Drawing.Point(486, 36);
            this.nud_com_number.Name = "nud_com_number";
            this.nud_com_number.Size = new System.Drawing.Size(42, 20);
            this.nud_com_number.TabIndex = 5;
            this.nud_com_number.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_com_number.ValueChanged += new System.EventHandler(this.nud_com_number_ValueChanged);
            // 
            // lbl_com_number
            // 
            this.lbl_com_number.AutoSize = true;
            this.lbl_com_number.Location = new System.Drawing.Point(428, 38);
            this.lbl_com_number.Name = "lbl_com_number";
            this.lbl_com_number.Size = new System.Drawing.Size(52, 13);
            this.lbl_com_number.TabIndex = 6;
            this.lbl_com_number.Text = "COM port";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gb_ch_1);
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 300);
            this.panel1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txb_ch4_off);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txb_ch4_on);
            this.groupBox3.Location = new System.Drawing.Point(3, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 68);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel 4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Off";
            // 
            // txb_ch4_off
            // 
            this.txb_ch4_off.Location = new System.Drawing.Point(47, 41);
            this.txb_ch4_off.Name = "txb_ch4_off";
            this.txb_ch4_off.Size = new System.Drawing.Size(335, 20);
            this.txb_ch4_off.TabIndex = 4;
            this.txb_ch4_off.Text = "light 4 off";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "On";
            // 
            // txb_ch4_on
            // 
            this.txb_ch4_on.Location = new System.Drawing.Point(47, 16);
            this.txb_ch4_on.Name = "txb_ch4_on";
            this.txb_ch4_on.Size = new System.Drawing.Size(335, 20);
            this.txb_ch4_on.TabIndex = 2;
            this.txb_ch4_on.Text = "light 4 on";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txb_ch3_off);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txb_ch3_on);
            this.groupBox2.Location = new System.Drawing.Point(3, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Off";
            // 
            // txb_ch3_off
            // 
            this.txb_ch3_off.Location = new System.Drawing.Point(47, 41);
            this.txb_ch3_off.Name = "txb_ch3_off";
            this.txb_ch3_off.Size = new System.Drawing.Size(335, 20);
            this.txb_ch3_off.TabIndex = 4;
            this.txb_ch3_off.Text = "light 3 off";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "On";
            // 
            // txb_ch3_on
            // 
            this.txb_ch3_on.Location = new System.Drawing.Point(47, 16);
            this.txb_ch3_on.Name = "txb_ch3_on";
            this.txb_ch3_on.Size = new System.Drawing.Size(335, 20);
            this.txb_ch3_on.TabIndex = 2;
            this.txb_ch3_on.Text = "light 3 on";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_ch2_off);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txb_ch2_on);
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Off";
            // 
            // txb_ch2_off
            // 
            this.txb_ch2_off.Location = new System.Drawing.Point(47, 41);
            this.txb_ch2_off.Name = "txb_ch2_off";
            this.txb_ch2_off.Size = new System.Drawing.Size(335, 20);
            this.txb_ch2_off.TabIndex = 4;
            this.txb_ch2_off.Text = "light 2 off";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "On";
            // 
            // txb_ch2_on
            // 
            this.txb_ch2_on.Location = new System.Drawing.Point(47, 16);
            this.txb_ch2_on.Name = "txb_ch2_on";
            this.txb_ch2_on.Size = new System.Drawing.Size(335, 20);
            this.txb_ch2_on.TabIndex = 2;
            this.txb_ch2_on.Text = "light 2 on";
            // 
            // btn_addChannel
            // 
            this.btn_addChannel.Enabled = false;
            this.btn_addChannel.Location = new System.Drawing.Point(426, 62);
            this.btn_addChannel.Name = "btn_addChannel";
            this.btn_addChannel.Size = new System.Drawing.Size(102, 23);
            this.btn_addChannel.TabIndex = 8;
            this.btn_addChannel.Text = "Add Channel";
            this.btn_addChannel.UseVisualStyleBackColor = true;
            // 
            // lbl_allOn
            // 
            this.lbl_allOn.AutoSize = true;
            this.lbl_allOn.Location = new System.Drawing.Point(21, 9);
            this.lbl_allOn.Name = "lbl_allOn";
            this.lbl_allOn.Size = new System.Drawing.Size(38, 13);
            this.lbl_allOn.TabIndex = 9;
            this.lbl_allOn.Text = "All On:";
            // 
            // lbl_allOff
            // 
            this.lbl_allOff.AutoSize = true;
            this.lbl_allOff.Location = new System.Drawing.Point(280, 9);
            this.lbl_allOff.Name = "lbl_allOff";
            this.lbl_allOff.Size = new System.Drawing.Size(38, 13);
            this.lbl_allOff.TabIndex = 10;
            this.lbl_allOff.Text = "All Off:";
            // 
            // txb_all_on
            // 
            this.txb_all_on.Location = new System.Drawing.Point(62, 6);
            this.txb_all_on.Name = "txb_all_on";
            this.txb_all_on.Size = new System.Drawing.Size(211, 20);
            this.txb_all_on.TabIndex = 11;
            this.txb_all_on.Text = "All lights on";
            // 
            // txb_all_off
            // 
            this.txb_all_off.Location = new System.Drawing.Point(324, 6);
            this.txb_all_off.Name = "txb_all_off";
            this.txb_all_off.Size = new System.Drawing.Size(204, 20);
            this.txb_all_off.TabIndex = 12;
            this.txb_all_off.Text = "All lights off";
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = true;
            this.lbl_about.Location = new System.Drawing.Point(423, 320);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(111, 13);
            this.lbl_about.TabIndex = 13;
            this.lbl_about.Text = "author: i@PixnBits.org";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 522);
            this.Controls.Add(this.lbl_about);
            this.Controls.Add(this.btn_grammarChange);
            this.Controls.Add(this.txb_all_off);
            this.Controls.Add(this.txb_all_on);
            this.Controls.Add(this.lbl_allOff);
            this.Controls.Add(this.lbl_allOn);
            this.Controls.Add(this.btn_addChannel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_com_number);
            this.Controls.Add(this.nud_com_number);
            this.Controls.Add(this.tb_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QnD FB6 Speech Recognition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_ch_1.ResumeLayout(false);
            this.gb_ch_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_com_number)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort sp_fusionBrain6;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TextBox txb_ch1_on;
        private System.Windows.Forms.Label lbl_ch1_on;
        private System.Windows.Forms.GroupBox gb_ch_1;
        private System.Windows.Forms.Label lbl_ch1_off;
        private System.Windows.Forms.TextBox txb_ch1_off;
        private System.Windows.Forms.Button btn_grammarChange;
        private System.Windows.Forms.NumericUpDown nud_com_number;
        private System.Windows.Forms.Label lbl_com_number;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_ch4_off;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_ch4_on;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_ch3_off;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_ch3_on;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_ch2_off;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_ch2_on;
        private System.Windows.Forms.Button btn_addChannel;
        private System.Windows.Forms.Label lbl_allOn;
        private System.Windows.Forms.Label lbl_allOff;
        private System.Windows.Forms.TextBox txb_all_on;
        private System.Windows.Forms.TextBox txb_all_off;
        private System.Windows.Forms.Label lbl_about;
    }
}

