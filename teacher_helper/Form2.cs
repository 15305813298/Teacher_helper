using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teacher_helper
{
    public partial class Form2 : Form
    {
        private string user = "";
        public Form2(String usr)
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.Red;
            this.label1.Text = "欢迎" + this.user + "老师";
            this.CenterToScreen();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 9)
                return;
            int rowIndex = e.RowIndex;
            try
            {
                if (this.check_null(this.dataGridView1.Rows[rowIndex].Cells[1].Value) == "null" || this.check_null(this.dataGridView1.Rows[rowIndex].Cells[2].Value) == "null" || this.check_null(this.dataGridView1.Rows[rowIndex].Cells[7].Value) == "null")
                {
                    int num1 = (int)MessageBox.Show("请补充完整！");
                }
                else
                {
                    Clipboard.SetText(this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString() + "同学，" + this.dataGridView1.Columns[2].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString() + "," + this.dataGridView1.Columns[3].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString() + "," + this.dataGridView1.Columns[4].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString() + "," + this.dataGridView1.Columns[5].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString() + "," + this.dataGridView1.Columns[6].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString() + "," + this.dataGridView1.Columns[7].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString() + "," + this.dataGridView1.Columns[8].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString() + "!");
                    int num2 = (int)MessageBox.Show("复制成功");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
            }
        }

        private string check_null(object view)
        {
            return view == null ? "null" : view.ToString();
        }
    }
}
