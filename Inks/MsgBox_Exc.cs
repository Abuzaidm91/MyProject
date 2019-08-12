using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inks
{
    public partial class MsgBox_Exc : Form
    {
        string Exit;
        public string Result;
        public MsgBox_Exc()
        {
            Exit = "No";
            InitializeComponent();
           // MessageBox.Show(this.Width.ToString());
            this.Height = 0;       
            this.Top  =  (Screen.PrimaryScreen.WorkingArea.Height / 2) - (181 / 2);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (399 / 2);
        }


        public string ShowMsg(string Note, string Caption)
        {
            
            this.Note.Text = Note;
            this.Title.Text = Caption;
            this.ShowDialog();
            return Result;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            this.Result = "Ok";
            Exit = "Ok";
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Result = "No";
            Exit = "Ok";
            timer1.Start(); 

        }

        private void MsgBox_Exc_Load(object sender, EventArgs e)
        {
            timer1.Start();  

        }

        private void MsgBox_Exc_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void MsgBox_Exc_Leave(object sender, EventArgs e)
        {
            
        }

        private void MsgBox_Exc_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Exit == "Ok")
            {

                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.04;
                }
                else
                {
                    this.Close();
                }
            }




            if (Exit == "No")
            {
                if (this.Opacity < 1 || this.Height <181 )
                {
                    if (this.Opacity < 1) { this.Opacity += 0.02; }
                    if (this.Height < 181) { this.Height += 4; }
                }               
                else
                {
                    timer1.Stop();
                }
            }
        }
    }
}
