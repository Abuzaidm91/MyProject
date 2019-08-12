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
    public partial class Add_printer_S : Form
    {
        Connection con;
        SqlCommand command;
        SqlDataAdapter sqladapter = new SqlDataAdapter();
        SqlDataReader Read;
        MsgBox_Exc Msg_Ex;
        
        MsgBox_Error Msg_Er;
        MsgBox_Info  Msg_Info;
        string SqlStatement;
        bool Exist;



        //
        string Printer_Type;
        string Printer_Name;
        string Company_Name;
        string Usages;
        string Note;
        int Colored;
        int Scan;
        int Ethernet;
        int Copy;
        int print;



        public Add_printer_S()
        {
           
            Msg_Ex = new MsgBox_Exc();
         
            InitializeComponent();

        }

        private void Add_printer_S_Load(object sender, EventArgs e)
        {

            comboBox4.Text = "اسود";
    
            MessageBox.Show(this.Height.ToString());  

        }




        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                Print_Check.Checked = true;
                Print_Check.Enabled = false;
            }
            else
            {
                Print_Check.Enabled = true;
                Print_Check.Checked = false;
            }

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if ( Colored_Check.Checked  )
            {
                comboBox4.Enabled  = true; 
            }
            else
            {
                comboBox4.Text = "اسود";
                comboBox4.Enabled  = false;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

           


       }

       

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            MsgBox_Exc Form1 = new MsgBox_Exc();
            string x = Form1.ShowMsg("هل ترغب  بإنهاء هذه العملية؟", "أغلاق النافذة");
            if (x == "Ok")
            {
                this.Close();
            }


        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

            // DialogResult result =  MessageBox.Show("هل ترغب في تقريغ الحقول؟","", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            // if (result == DialogResult.Yes)

            MsgBox_Exc MSG = new MsgBox_Exc();
            string res = MSG.ShowMsg("هل ترغب بتفريغ الحقول؟", "تفريغ الحقول");  
            if (res == "Ok")
            {
                Printer_Name = "";
                textBox5.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                dataGridView1.Rows.Clear();
                Colored_Check.Checked = false;
                Scan_Check.Checked = false;
                Ethernet_Check.Checked = false;
                Copy_Check.Checked = false;
                Print_Check.Checked = false;

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                Form1 Msg_E = new Form1();
                Msg_E.Show("أدحل نوع الحبر وأختر اللون");              
                return;
            }

            this.dataGridView1.Rows.Add(textBox4.Text, comboBox4.Text);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form1 Msg;
             try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox5.Text == "" || comboBox3.Text == "")
                {
                    //  MessageBox.Show(Cursor.Position.X.ToString());
                    //Msg_Info.ShowMsg("هنالك حقول قارغة ,يجب تعبئة كافة الحقول", "حقول فارغة");
                    Msg = new Form1();
                    Msg.Show("هنالك حقول قارغة ,يجب تعبئة كافة الحقول"); 
                    return;
                }


                con = new Connection();
                con.open();
                Exist = false;
                // TO Check If Value exists
                SqlStatement = "select [Print_Name] from Printers";
                command = new SqlCommand(SqlStatement, con.conn);
                Read = command.ExecuteReader();
                while (Read.Read())
                {

                    if (Read[0].ToString().Trim().ToLower() == textBox1.Text.Trim().ToLower())
                    {

                        Exist = true;
                        Msg_Info = new MsgBox_Info();
                        Msg_Info.ShowMsg("....أسم الجهاز موجود بالفعل ", "أسم الجهاز مدخل سابقاً");
                        command.Dispose();
                        con.close();
                        return;
                    }
                }




                Printer_Type = comboBox1.Text;
                Printer_Name = textBox1.Text;
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

                SqlStatement = "insert into printers([Print_Type],[Print_Name],[Company_name],[Usages],[Scan],[Colored],[Ethernet],[Copy],[Print],[Note]) values (N'" + Printer_Type + "','" + Printer_Name + "','" + Company_Name + "','" + Usages + "','" + Scan + "','" + Colored + "','" + Ethernet + "','" + Copy + "','" + print + "',N'" + Note + "')";

                command = new SqlCommand(SqlStatement, con.conn);
                sqladapter.InsertCommand = command;
                sqladapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();




            foreach (DataGridViewRow g1 in dataGridView1.Rows)
                
            {
               
                if (!string.IsNullOrEmpty(g1.Cells[0].Value as string ) ) 
                {
                    command = new SqlCommand("insert into Inks_Store([Printer_Name],[Ink_Number],[Color]) values ('" + textBox1.Text + "','" + g1.Cells[0].Value + "',N'" + g1.Cells[1].Value + "')", con.conn);
                    command.ExecuteNonQuery();
                }
             }

                con.close();
                Msg_Info = new MsgBox_Info();
                Msg_Info.ShowMsg("تمت عملية الحفظ بنجاح", "تم");
            }
            catch
            {
                Msg_Er = new MsgBox_Error();
                Msg_Er.ShowMsg("حدث خطأ أثناء تنقيذ عملية الادخال", "خطأ");
                con.close();
            }


        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
