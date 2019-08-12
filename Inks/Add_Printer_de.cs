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
    public partial class Add_Printer_de : Form
    {
        SqlCommand command;
        SqlCommand command_Printers_details;
        Connection con = new Connection();
        SqlDataReader reader;
        string SqlStatement;
        MsgBox_Error Msg_E = new MsgBox_Error();
        MsgBox_Info Msg_Info = new MsgBox_Info();




        SqlDataAdapter sqladapter = new SqlDataAdapter();
        SqlDataReader Read;
        public Add_Printer_de()
        {
            InitializeComponent();
        }

        private void Add_Printer_de_Load(object sender, EventArgs e)
        {
            
            try
            {
                con.open();
                command_Printers_details = new SqlCommand("Select * from Printers", con.conn);
                // command.Parameters.AddWithValue("@zip", "india");
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command_Printers_details.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader[0].ToString().Trim() != "")
                        {
                            comboBox1.Items.Add(reader[1].ToString());
                        }
                    }

                }
                con.close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Msg_E.ShowMsg("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" + error.Substring(0, 20), "خطأ");

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
            string x = Form1.ShowMsg("هل ترغب  بإنهاء هذه العملية؟", "أغلاق النافذة");
            if (x == "Ok")
            {
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
