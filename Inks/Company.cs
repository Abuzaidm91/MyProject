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
    public partial class Company : Form
    {
        Boolean Selected_value = false;
        string ID;
        Connection con = new Connection(); 
        SqlCommand command;
        SqlDataAdapter sqladapter;
        Form1 Msg_El;
        MsgBox_Info Msg_Info;
        MsgBox_Error Msg_E;
          string SqlStatement;

        public Company()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            items_load();
        }


        private void items_load()
        {

            Company_name.Items.Clear();  

            try
            {
                con.open();
                command = new SqlCommand("Select [Company_Name] from Company", con.conn);
                // command.Parameters.AddWithValue("@zip", "india");
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader[0].ToString().Trim() != "")
                        {
                            Company_name.Items.Add(reader[0].ToString());
                        }
                    }

                }
                con.close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Msg_E = new MsgBox_Error();
                Msg_E.ShowMsg("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" + error.Substring(0, 30), "خطأ");
                con.close();
            }



        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
             try
             {
           
          
                if (this.Company_name.Text == "" || this.Phone.Text == "" || this.Location.Text == "")
                {
                //  MessageBox.Show("هنالك حقول قارغة", "....", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);                    
                Msg_El = new Form1();
                Msg_El.Show("هنالك حقول قارغة يجب تعبئة كافة الحقول");
                return;
                }


         

            con.open();

                if (Selected_value == true)
                {
                    Update_Values();
                }
                else
                {

                    int Inks_value = 0;
                    int Printers_value = 0;
                    int Hardware_value = 0;

                    if (Inks.Checked == true) { Inks_value = 1; }
                    if (Printers.Checked == true) { Printers_value = 1; }
                    if (Hardware.Checked == true) { Hardware_value = 1; }



                    //Insert new Items to Companies tables

                    SqlStatement = "insert into Company([Company_Name],[Phone],[Location],[Ink_Deal],[Printer_Deal],[Hardware_Deal]) values (N'" + this.Company_name.Text + "','" + this.Phone.Text + "',N'" + this.Location.Text + "','" + Inks_value + "','" + Printers_value + "','" + Hardware_value + "')";
                    command = new SqlCommand(SqlStatement, con.conn);
                    sqladapter = new SqlDataAdapter();
                    sqladapter.InsertCommand = command;
                    sqladapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();


                  
                    Msg_Info = new MsgBox_Info();
                    Msg_Info.ShowMsg("تمت عملية الحفظ بنجاح", "تم");
                    
                }

                con.close();
                items_load();
            }
            catch
            {
              Msg_E = new MsgBox_Error();
              Msg_E.ShowMsg("حدث خطأ أثناء عملية التحديث للبيانات", "خطأ");
              con.close();

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
            string x = Form1.ShowMsg("هل ترغب  بإنهاء هذه العملية؟", "أغلاق البرنامج");
            if (x == "Ok")
            {
                this.Close();
            }
        }

        private void Company_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.open();
            command = new SqlCommand("Select * from Company where [Company_Name] = @Value", con.conn);
            command.Parameters.AddWithValue("@Value", Company_name.Text);
            // command.Parameters.AddWithValue("@zip", "india");
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {


                if (reader.Read())
                {
                    Phone.Text = reader["Phone"].ToString().Trim();
                    Location.Text = reader["Location"].ToString().Trim();


                    if (reader["Ink_Deal"].ToString() == "1")
                    {
                        Inks.Checked = true;
                    }
                    else
                    {
                        Inks.Checked = false;
                    }

                    if (reader["Printer_Deal"].ToString() == "1")
                    {
                        Printers.Checked = true;
                    }
                    else
                    {
                        Printers.Checked = false;
                    }

                    if (reader["Hardware_Deal"].ToString() == "1")
                    {
                        Hardware.Checked = true;
                    }
                    else
                    {
                        Hardware.Checked = false;
                    }



                    ID = reader["ID"].ToString();
                }

                con.close();
                Selected_value = true;
                button3.Text = "تحديث";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MsgBox_Exc MSG = new MsgBox_Exc();
            string res = MSG.ShowMsg("هل ترغب بتفريغ الحقول؟", "تفريغ الحقول");
            if (res == "Ok")
            {

                Selected_value = false;
                Inks.Checked = false;
                Printers.Checked = false;
                Hardware.Checked = false;
                this.Company_name.Text = "";
                this.Phone.Text = "";
                this.Location.Text = "";
                button3.Text = "حفظ";

            }
        }

        private void Update_Values()
        {
            int Inks_V = 0;
            int IPrinters_V = 0;
            int Hardware_V = 0;
            if (Inks.Checked == true) { Inks_V = 1; }
            if (Printers.Checked == true) { IPrinters_V = 1; }
            if (Hardware.Checked == true) { Hardware_V = 1; }

            SqlStatement = "update Company set [Company_name] = @Company_name, [Phone] = @Phone, [Location] = @Location,[Ink_Deal] = @Ink_Deal ,[Printer_Deal] = @Printer_Deal, [Hardware_Deal] = @Hardware_Deal where [ID] = @ID";
            command = new SqlCommand(SqlStatement, con.conn);
            command.Parameters.AddWithValue("@Company_name", Company_name.Text );
            command.Parameters.AddWithValue("@Phone", Phone.Text );
            command.Parameters.AddWithValue("@Location", Location.Text );
            command.Parameters.AddWithValue("@Ink_Deal", Inks_V);
            command.Parameters.AddWithValue("@Printer_Deal", IPrinters_V);
            command.Parameters.AddWithValue("@Hardware_Deal", Hardware_V);
            command.Parameters.AddWithValue("@ID", ID);
            sqladapter = new SqlDataAdapter();
            sqladapter.InsertCommand = command;
            sqladapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            Msg_Info = new MsgBox_Info();
            Msg_Info.ShowMsg("تمت عملية الحفظ بنجاح", "تم");
            


        }

    }
}
