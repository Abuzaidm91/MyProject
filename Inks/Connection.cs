using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inks
{
    class Connection
    {
        MsgBox_Error Msg;
        string stringcon;
        public SqlConnection conn;

        public Connection()
        {
            
            stringcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\smt\Desktop\My Project\My DataBase\DataInks.mdf;Integrated Security=True;Connect Timeout=30;" + "MultipleActiveResultSets=True";

            conn = new SqlConnection(stringcon);
          
        }


    





      
        //Open connection
        public void open()
        {
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                string error = ex.ToString();
                Msg = new MsgBox_Error();
                Msg.ShowMsg("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" + error.Substring(0, 30),"خطأ"); 
               
                //MessageBox.Show("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" +  error.Substring(0,20),"فشل الاتصال", MessageBoxButtons.OK ,MessageBoxIcon.Error ,MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading );
            }
        }

        //close connection
        public void close()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Msg = new MsgBox_Error();
                Msg.ShowMsg("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" + error.Substring(0, 30), "خطأ");

               // MessageBox.Show("هنالك مشكلة بالاتصال مع الخادم الرئيسي للمديرية" + "\n" + "نوع الخطأ" + "\n" + error.Substring(0, 20), "فشل الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    


    }
}
