using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/stud.mdb";
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connectString);
        OleDbCommand cmd = new OleDbCommand();


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studDataSet.students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.studDataSet.students);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdText = "INSERT INTO students(sname, sgroup, sgrade) Values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "')";
                cmd = new OleDbCommand(cmdText, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentsTableAdapter.Update(studDataSet);
        }
    }
}
