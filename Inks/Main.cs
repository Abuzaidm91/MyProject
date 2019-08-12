using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Inks
{
    public partial class Main : Form
    {
        // Forms delecrations
        Inks iink_form;
        withdraw withdraw_form;
        Add_printer_S Add_P;
        Views_Printers View_P;
        Add_Printer_de Add_P_de;
        Add_Toners Inks_add;
        MsgBox_Exc frm; 

        // Sql delecrations
        Connection con = new Connection();
        SqlCommand command;
        SqlDataAdapter sqladapter = new SqlDataAdapter(); 


       // To Check If From Is Open
        public bool IsformOpen(Form frmOpen)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == frmOpen.Name)
                {
                    return true;
                }
            }

            return false;
        }

     
       
        public Main()
        {
          
            InitializeComponent();



            Inks_add = new Add_Toners(); 
            iink_form = new Inks(this);
            withdraw_form = new withdraw();
            Add_P = new Add_printer_S();
            View_P = new Views_Printers();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

       
       

        public void Inks_Click(object sender, EventArgs e)
        {
            
            if (IsformOpen(iink_form) == false)
            {
                iink_form = new Inks(this);
                iink_form.MdiParent = this;
                iink_form.Show();
                iink_form.BringToFront(); 
            }
            else
            {
                iink_form.BringToFront(); 
            }

        }

       
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" للمساعدة قم بوضع المؤشر على الحقل المراد أو الاتصال مع مدير نظام"); 
        }

      

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public void Withdraw_window(object sender, EventArgs e)
        {
            if (IsformOpen(withdraw_form) == false)
            {
                withdraw_form = new withdraw();
               // withdraw_form.MdiParent = this;  
                withdraw_form.ShowDialog(); 
            }
            else
            {
                withdraw_form.BringToFront();
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
      
            con.open();
            con.close();

        }

      

       

        private void RibbonPanel1_Click(object sender, EventArgs e)
        {
            this.Inks_Click(sender, e);
        }

       

        private void RibbonButton2_Click(object sender, EventArgs e)
        {
            this.Withdraw_window(sender, e);
        }


        private void RibbonButton10_Click(object sender, EventArgs e)
        {
            if (IsformOpen(Add_P) == false)
            {
                Add_P = new Add_printer_S();
                Add_P.MdiParent = this;
                Add_P.Show();
                Add_P.BringToFront();

            }
            else
            {

                Add_P.BringToFront();
            }
        }

        private void RibbonButton11_Click(object sender, EventArgs e)
        {
            if (IsformOpen(View_P) == false)
            {
                View_P = new Views_Printers();
                View_P.MdiParent = this;
                View_P.Show();
                View_P.BringToFront();

            }
            else
            {
                View_P.BringToFront();
            }
        }

        private void RibbonButton1_Click(object sender, EventArgs e)
        {
            if (IsformOpen(Inks_add) == false)
            {
                Inks_add = new Add_Toners();
                Inks_add.ShowDialog();
            }

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.RibbonButton8_Click(sender,e );
        }

        private void RibbonButton9_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Note.Text  = "كل ما يتعلق بعمليات الاستعلام والبحث عن جميع الاحبار والاجهزة";   
        }

        private void RibbonButton9_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Note.Text = "";

        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {  
            this.button1.BackColor = System.Drawing.Color.Red;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = System.Drawing.Color.Transparent  ;
        }

        private void RibbonButton8_Click(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
           string x = Form1.ShowMsg("هل ترغب  بإنهاء البرنامج؟", "أغلاق البرنامج");
            if (x == "Ok")
            {
                this.Close();
            }
            //DialogResult result = MessageBox.Show("هل ترغب في بإنهاء البرنامج؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //if (result == DialogResult.Yes) { this.Close(); }
        }

        private void RibbonButton4_Click(object sender, EventArgs e)
        {
            Add_P_de = new Add_Printer_de();
            Add_P_de.ShowDialog(); 
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.Blue;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.Transparent;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    
        }

        private void RibbonButton17_Click(object sender, EventArgs e)
        {
            Company add = new Company();
            add.ShowDialog(); 


        }
    }
}
