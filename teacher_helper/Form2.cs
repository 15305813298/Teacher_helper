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
        private DataTable dataTable;
        private string user = "";
        private int init_count = 0;
        public Form2(String usr)
        {
            user = usr;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.Red;
            this.label1.Text = "欢迎" + this.user + "老师";
            this.CenterToScreen();
            BindData();
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
                    Clipboard.SetText(this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString() + "家长您好，孩子" + 
                        this.dataGridView1.Columns[2].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString() + "," + 
                        this.dataGridView1.Columns[3].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString() + "," + 
                        this.dataGridView1.Columns[4].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString() + "," + 
                        this.dataGridView1.Columns[5].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString() + "," + 
                        this.dataGridView1.Columns[6].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString() + "," + 
                        this.dataGridView1.Columns[7].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString() + "," + 
                        this.dataGridView1.Columns[8].HeaderText.ToString() + this.dataGridView1.Rows[rowIndex].Cells[8].Value.ToString() + "!");
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

        private void BindData()
        {
            DBManager dBManager = new DBManager();
            dataTable = dBManager.Query();
            init_count = dataTable.Rows.Count;//保存数据数量
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = dataTable;
            this.dataGridView1.VirtualMode = true;
            for(int i = 0; i < 9; i++)
            {
                this.dataGridView1.Columns[i].DataPropertyName = dataTable.Columns[i].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int columns = Int32.Parse(this.textBox1.Text.ToString());
                String content = this.textBox2.Text.ToString();
                this.dataGridView1.Columns[columns].HeaderText = content;
            }
            catch
            {
                MessageBox.Show("请输入数字！");
            }
        }


        private void button1_Click(object sender, EventArgs e)//数据保存
        {
            
        }
    }
}
