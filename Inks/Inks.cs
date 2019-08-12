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
    public partial class Inks : Form
    {
        Main main1;

        public Inks(Main perent)
        {
            main1 = perent;
            InitializeComponent();

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            main1.Withdraw_window(sender, e);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Inks_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            // dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 13);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14F, FontStyle.Bold);
       

            Connection con = new Connection();
            // to retrive all printers from database
            SqlCommand cmd = new SqlCommand("Select * from Printers", con.conn);

            dataGridView1.AutoGenerateColumns = false;





 


                /*Connection con = new Connection();
                SqlCommand cmd = new SqlCommand("Select * from Printers", con.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;*/
                

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add("one", "six", "seven", "1");
            this.dataGridView1.Rows.Add("five", "six", "seven", "eight");
            this.dataGridView1.Rows.Add("five", "six", "seven", "eight");
            this.dataGridView1.Rows.Add("one", "six", "seven", "2");
            this.dataGridView1.Rows.Add("one", "six", "seven", "3");
            this.dataGridView1.Rows.Add("five", "six", "seven", "eight");

            this.dataGridView1.Sort(this.dataGridView1.Columns["Printer"], ListSortDirection.Ascending);
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView1[column, row];
            DataGridViewCell cell2 = dataGridView1[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Merge the third column
            //if (e.ColumnIndex == 2 && e.RowIndex != -1)
            //Merge all the columns
            if (e.RowIndex != -1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                if (e.RowIndex < 1 || e.ColumnIndex < 0)
                    return;
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
                }
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
    }
    
    


}
