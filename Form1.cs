using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace حديث
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] b = ms.ToArray();


            string insert = "insert into Table_1 (name, phone, ident, gender, address, img) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "','" + b + "')";
            SqlConnection con = new SqlConnection(@"server=DESKTOP-M6C24F7; database=data; integrated security=true");
            SqlCommand cmd = new SqlCommand(insert, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت اضافة البيانات بنجاح");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)

            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }
    }
}
