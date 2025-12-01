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

namespace qldt
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            getData();
        }
        void getData()
        {
            SqlConnection sql = new SqlConnection(connect);
            sql.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM diem", sql);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int masv = int.Parse(dr[0].ToString());
                string ten = dr[1].ToString();
                string mamh = dr[2].ToString();
                string tenmh = dr[3].ToString();
                int lanthi = int.Parse(dr[4].ToString());
                int diem = int.Parse(dr[5].ToString());
                dataGridView1.Rows.Add( masv,ten,mamh,tenmh,lanthi,diem);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox5.Text, out int diem))
            {
                errorProvider1.SetError(textBox5, "Vui long nhap so!");
            }
            else if (diem < 0 || diem > 10)
            {
                errorProvider1.SetError(textBox5, "Vui long nhap diem tu 0 den 10 !");
            }
            else
              {
                errorProvider1.SetError(textBox5, "");
            }
            
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox4.Text, out int diem))
            {
                errorProvider1.SetError(textBox4, "Vui long nhap so!");
            }
            else if (diem < 0 || diem > 10)
            {
                errorProvider1.SetError(textBox4, "Vui long nhap diem tu 0 den 10 !");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "T")
            {
                textBox3.Text = "Toan";
            }
            else if (comboBox1.Text == "V")
            {
                textBox3.Text = "Van";
            }
            else if (comboBox1.Text == "A")
            {
                textBox3.Text = "Anh";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, "1", textBox4.Text);
            }
            if (radioButton2.Checked)
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, "2", textBox5.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                


             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = textBox1.Text;
                dataGridView1.SelectedRows[0].Cells[1].Value = textBox2.Text;
                dataGridView1.SelectedRows[0].Cells[2].Value = comboBox1.Text;
                dataGridView1.SelectedRows[0].Cells[3].Value = textBox3.Text;
                if (radioButton1.Checked)
                {
                    dataGridView1.SelectedRows[0].Cells[5].Value = textBox4.Text;
                }
                if (radioButton2.Checked)
                {
                    dataGridView1.SelectedRows[0].Cells[5].Value = textBox5.Text;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private string connect = @"Data Source=QUAN\SQLEXPRESS;Initial Catalog=qldt;Integrated Security=True";
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(connect);
            sql.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO diem VALUES(@masv,@tensv,@mamh,@tenmh,@lanthi,@diem)", sql);
            cmd.Parameters.AddWithValue("@masv", textBox1.Text);
            cmd.Parameters.AddWithValue("@tensv", textBox2.Text);
            cmd.Parameters.AddWithValue("@mamh", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tenmh", textBox3.Text);
            if (radioButton1.Checked)
            {
                cmd.Parameters.AddWithValue("@lanthi", "1");
                cmd.Parameters.AddWithValue("@diem", textBox4.Text);
            }
            if (radioButton2.Checked)
            {
                cmd.Parameters.AddWithValue("@lanthi", "2");
                cmd.Parameters.AddWithValue("@diem", textBox5.Text);
            }
            cmd.ExecuteNonQuery();
            sql.Close();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
