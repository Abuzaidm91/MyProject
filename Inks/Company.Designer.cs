namespace Inks
{
    partial class Company
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Hardware = new System.Windows.Forms.CheckBox();
            this.Printers = new System.Windows.Forms.CheckBox();
            this.Inks = new System.Windows.Forms.CheckBox();
            this.Location = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Company_name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Location);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Phone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Company_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تفاصيل الشركة";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Hardware);
            this.groupBox2.Controls.Add(this.Printers);
            this.groupBox2.Controls.Add(this.Inks);
            this.groupBox2.Location = new System.Drawing.Point(6, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 167);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الأنشطة";
            // 
            // Hardware
            // 
            this.Hardware.AutoSize = true;
            this.Hardware.Location = new System.Drawing.Point(171, 122);
            this.Hardware.Name = "Hardware";
            this.Hardware.Size = new System.Drawing.Size(172, 23);
            this.Hardware.TabIndex = 2;
            this.Hardware.Text = "قطع الحاسوب ولوازمه";
            this.Hardware.UseVisualStyleBackColor = true;
            // 
            // Printers
            // 
            this.Printers.AutoSize = true;
            this.Printers.Location = new System.Drawing.Point(171, 77);
            this.Printers.Name = "Printers";
            this.Printers.Size = new System.Drawing.Size(172, 23);
            this.Printers.TabIndex = 1;
            this.Printers.Text = "الطابعات وآلات التصوير";
            this.Printers.UseVisualStyleBackColor = true;
            // 
            // Inks
            // 
            this.Inks.AutoSize = true;
            this.Inks.Location = new System.Drawing.Point(273, 37);
            this.Inks.Name = "Inks";
            this.Inks.Size = new System.Drawing.Size(70, 23);
            this.Inks.TabIndex = 0;
            this.Inks.Text = "الأحبار";
            this.Inks.UseVisualStyleBackColor = true;
            // 
            // Location
            // 
            this.Location.Location = new System.Drawing.Point(70, 129);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(197, 27);
            this.Location.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "العنوان";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(70, 80);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(197, 27);
            this.Phone.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "الهاتف";
            // 
            // Company_name
            // 
            this.Company_name.FormattingEnabled = true;
            this.Company_name.Location = new System.Drawing.Point(11, 33);
            this.Company_name.Name = "Company_name";
            this.Company_name.Size = new System.Drawing.Size(256, 27);
            this.Company_name.TabIndex = 1;
            this.Company_name.SelectedIndexChanged += new System.EventHandler(this.Company_name_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "أسم الشركة";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.Image = global::Inks.Properties.Resources.Cancel_B2;
            this.button4.Location = new System.Drawing.Point(291, 381);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 57);
            this.button4.TabIndex = 2;
            this.button4.Text = "الغاء";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Green;
            this.button3.Image = global::Inks.Properties.Resources.Save;
            this.button3.Location = new System.Drawing.Point(4, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 57);
            this.button3.TabIndex = 1;
            this.button3.Text = "حفظ";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Image = global::Inks.Properties.Resources.Recycle_B;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(136, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 57);
            this.button1.TabIndex = 18;
            this.button1.Text = "تفريغ الحقول";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 456);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Company";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الشركات";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Location;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Company_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox Hardware;
        private System.Windows.Forms.CheckBox Printers;
        private System.Windows.Forms.CheckBox Inks;
        private System.Windows.Forms.Button button1;
    }
}