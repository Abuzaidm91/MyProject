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

namespace Inks
{
    public partial class Add_Toners : Form
    {
        SqlCommand command;
        SqlCommand command_Printers;
        SqlCommand command_Inks;
        Connection con = new Connection();
        SqlDataReader reader;
        string SqlStatement;
        MsgBox_Error Msg_E = new MsgBox_Error();
        MsgBox_Info Msg_Info = new MsgBox_Info();
        public Add_Toners()
        {
            InitializeComponent();
        }

        static void NumOnly()
        {
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Toners_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox4.SelectedIndex = 0;

        }

        private void P_s_TextChanged(object sender, EventArgs e)
        {
            if (this.P_s.Text != "" && this.Q.Text != "")
            {
                this.P_t.Text = (Convert.ToInt32(this.Q.Text) * Convert.ToInt32(this.P_s.Text)).ToString();
            }
        }

        private void Q_TextChanged(object sender, EventArgs e)
        {
            if (this.P_s.Text != "" && this.Q.Text != "")
            {
                this.P_t.Text = (Convert.ToInt32(this.Q.Text) * Convert.ToInt32(this.P_s.Text)).ToString();
            }
        }

        private void P_t_TextChanged(object sender, EventArgs e)
        {
            if (this.P_t.Text != "" && this.Q.Text != "")
            {
                this.P_s.Text = (Convert.ToInt32(this.P_t.Text) / Convert.ToInt32(this.Q.Text)).ToString();
            }

            if (this.P_t.Text != "" &&   this.P_s.Text != "")
            {
                this.Q.Text = (Convert.ToInt32(this.P_t.Text) / Convert.ToInt32(this.P_s.Text)).ToString();
            }

        }

        private void P_s_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Q_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void P_t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //  try
            //  {
            if (comboBox4.Text == "أختر رقم الحبر....." || comboBox1.Text == "أختر نوع الجهاز...." || comboBox2.Text == "أختر أسم الجهاز....")
            {
                //  MessageBox.Show("هنالك حقول قارغة", "....", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                Msg_Info.ShowMsg("هنالك حقول قارغة يجب تعبئة جميع الحقول", "حقول فارغة");
                return;
            }

           


        }

      

    }
}
