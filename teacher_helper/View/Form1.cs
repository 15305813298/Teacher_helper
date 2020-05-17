using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teacher_helper
{
    public partial class Form1 : Form 
    {
        private string usr;
        public DBManager dbManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = this.textBox1.Text.ToString();
            String pwd = this.textBox2.Text.ToString();
            dbManager = new DBManager(user, pwd);
            if(dbManager.LoginQuery() == true)
            {
                usr = user;
                this.Hide();
                new Form2(usr).Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
