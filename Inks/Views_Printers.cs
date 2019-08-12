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
    public partial class Views_Printers : Form
    {
        SqlCommand command; 
        SqlCommand command_Printers;
        SqlCommand command_Inks;
        Connection con = new Connection();
        SqlDataReader reader;
        string SqlStatement;
        MsgBox_Error Msg_E = new MsgBox_Error();
        MsgBox_Info Msg_Info = new MsgBox_Info();
        Form1 Msg_El;




        SqlDataAdapter sqladapter = new SqlDataAdapter();
        SqlDataReader Read;
      



        //
        string Printer_Type;
        string Print_Name;
        string Company_Name;
        string Usages;
        string Note;
        int Colored;
        int Scan;
        int Ethernet;
        int Copy;
        int print;


        public Views_Printers()
        {
            InitializeComponent();
        }

        private void Views_Preinters_Load(object sender, EventArgs e)
        {

            try
            {
                con.open();
                command_Printers = new SqlCommand("Select [Print_Name] from Printers", con.conn);
                // command.Parameters.AddWithValue("@zip", "india");
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command_Printers.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader[0].ToString().Trim() != "")
                        {
                            comboBox2.Items.Add(reader[0].ToString());
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

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.open();
            command_Printers = new SqlCommand("Select * from Printers where [Print_Name] = @Value", con.conn);
            command_Inks = new SqlCommand("Select * from Inks_Store where [Printer_Name] = @Value", con.conn);
            command_Inks.Parameters.AddWithValue("@Value", comboBox2.Text);
            command_Printers.Parameters.AddWithValue("@Value", comboBox2.Text);
            // command.Parameters.AddWithValue("@zip", "india");
            // int result = command.ExecuteNonQuery();
            using (reader = command_Printers.ExecuteReader())
            {

 
                    if (reader.Read())
                    { 
                    comboBox1.Text = reader["Print_Type"].ToString().Trim();
                    textBox5.Text = reader["Company_name"].ToString().Trim();
                    comboBox3.Text = reader["Usages"].ToString().Trim();
                    textBox2.Text = reader["Note"].ToString().Trim();

                    if (reader["Colored"].ToString() == "True")
                    {
                        Colored_Check.Checked = true;
                    }
                    else
                    {
                        Colored_Check.Checked = false;
                    }

                    if (reader["Scan"].ToString()  == "True")
                    {
                        Scan_Check.Checked = true;
                    }
                    else
                    {
                        Scan_Check.Checked = false;
                    }

                    if (reader["Ethernet"].ToString() == "True")
                    {
                        Ethernet_Check.Checked = true;
                    }
                    else
                    {
                        Ethernet_Check.Checked = false;
                    }

                    if (reader["Copy"].ToString() == "True")
                    {
                        Copy_Check.Checked = true;
                    }
                    else
                    {
                        Copy_Check.Checked = false;
                    }

                    if (reader["Print"].ToString() == "True")
                    {
                        Print_Check.Checked = true;
                    }
                    else
                    {
                        Print_Check.Checked = false;
                    }
                   

                }



               

                }


            reader = command_Inks.ExecuteReader();
            dataGridView1.Rows.Clear(); 
            {


                while (reader.Read())
                {
                    if (reader[1].ToString() != "" && reader[2].ToString() != "")
                    {
                        dataGridView1.Rows.Add(reader[1].ToString().Trim(), reader[2].ToString().Trim());
                    }
                }   


            }

            Check_Uses();
            con.close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
       




        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || comboBox4.Text == ""  )
            {
                Msg_El = new Form1();
                Msg_El.Show("أدحل نوع الحبر وأختر اللون");  
                return;
            }

            this.dataGridView1.Rows.Add(textBox4.Text, comboBox4.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
            string x = Form1.ShowMsg("هل ترغب بالاستمرار؟" + "/n" + "اذا قمت بالضغط على زر تحديث فلن يمكنك التراجع فيما بعد وستفقد كافة المعلومات حول هذه الاحبار" + "/n" + "أن عملية حذف الحبر من هذه النافذه يعني حذفها بشكل كامل من المستودع", "تحذيرة");
            if (x == "Ok")
            {
                this.Close();
            }

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {

           

           try
            {
                con.open();
                if (comboBox1.Text == "" || textBox5.Text == "" || comboBox3.Text == "")
                {
                    //  MessageBox.Show("هنالك حقول قارغة", "....", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);                    
                    Msg_El = new Form1();
                    Msg_El.Show("هنالك حقول فارغة يجب تعبئة جميع الحقول");
                    con.close(); 
                    return;
                }


               
               




                Printer_Type = comboBox1.Text;
                Print_Name = comboBox2.Text;
                Company_Name = textBox5.Text;
                Usages = comboBox3.Text;
                Note = textBox2.Text;
                Colored = 0;
                Scan = 0;
                Ethernet = 0;
                Copy = 0;
                print = 0;
                if (Colored_Check.Checked == true) { Colored = 1; }
                if (Scan_Check.Checked == true) { Scan = 1; }
                if (Ethernet_Check.Checked == true) { Ethernet = 1; }
                if (Copy_Check.Checked == true) { Copy = 1; }
                if (Print_Check.Checked == true) { print = 1; }



                //Update Printer table
                SqlStatement = "update printers set [Print_Type] = @Print_Type, [Company_name] = @Company_name, [Usages] = @Usages,[Note] = @Note ,[Scan] = @Scan, [Colored] = @Colored, [Ethernet] = @Ethernet, [Copy]= @Copy, [Print] = @Print where [Print_Name] = @Printer_Name";
                command = new SqlCommand(SqlStatement, con.conn);
                command.Parameters.AddWithValue("@Printer_Name", Print_Name);
                command.Parameters.AddWithValue("@Print_Type", Printer_Type);
                command.Parameters.AddWithValue("@Company_name", Company_Name);
                command.Parameters.AddWithValue("@Usages", Usages);
                command.Parameters.AddWithValue("@Note", Note);
                command.Parameters.AddWithValue("@Scan", Scan);
                command.Parameters.AddWithValue("@Colored", Colored);
                command.Parameters.AddWithValue("@Ethernet", Ethernet);
                command.Parameters.AddWithValue("@Copy", Copy);
                command.Parameters.AddWithValue("@Print", print);
                sqladapter.InsertCommand = command;
                sqladapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();


                //Delete Old Items from Inks_Store tables
                SqlStatement = "Delete from Inks_Store where [Printer_Name]='" + Print_Name + "'";
                command = new SqlCommand(SqlStatement, con.conn);
                sqladapter.InsertCommand = command;
                sqladapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();


                //Add New Items to inks table
                foreach (DataGridViewRow g1 in dataGridView1.Rows)
                {
                    if (!string.IsNullOrEmpty(g1.Cells[0].Value as string))
                    {
                        command = new SqlCommand("insert into Inks_Store([Printer_Name],[Ink_Number],[Color]) values ('" + comboBox2.Text + "','" + g1.Cells[0].Value + "',N'" + g1.Cells[1].Value + "')", con.conn);
                        command.ExecuteNonQuery();
                    }
                }




                con.close();
                Msg_Info = new MsgBox_Info(); 
                Msg_Info.ShowMsg("تمت عملية الحفظ بنجاح", "تم");
            }
           catch
            {
                Msg_E = new MsgBox_Error(); 
                Msg_E.ShowMsg("حدث خطأ أثناء عملية التحديث للبيانات","خطأ");
                con.close(); 

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
            string x = Form1.ShowMsg("هل ترغب  بإنهاء هذه العملية؟", "أغلاق النافذة");
            if (x == "Ok")
            {
                this.Close();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MsgBox_Exc MSG = new MsgBox_Exc();
            string res = MSG.ShowMsg("هل ترغب بتفريغ الحقول؟", "تفريغ الحقول");
            if (res == "Ok")
            {
                
                textBox5.Text = "";
                textBox4.Text = "";          
                dataGridView1.Rows.Clear();
                Colored_Check.Checked = false;
                Scan_Check.Checked = false;
                Ethernet_Check.Checked = false;
                Copy_Check.Checked = false;
                Print_Check.Checked = false;

            }
        }

        private void Check_Uses()
        {
            if (comboBox1.Text == "فاكس")
            {
                comboBox3.Text = "A4";
                comboBox3.Enabled = false;
            }
            else
            {
                comboBox3.Enabled = true;
            }

            if (comboBox1.Text == "طابعة")
            {
                Copy_Check.Checked = true;
                Copy_Check.Enabled = false;
            }
            else
            {
                Copy_Check.Enabled = true;
                Copy_Check.Checked = false;
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_Uses();
        }
    }
}
