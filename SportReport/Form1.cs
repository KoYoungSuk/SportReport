using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportReport
{
    public partial class Form1 : Form
    {
        Global g = new Global();
        OracleConnection conn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }


        #region["로그인"] 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String fulladdress = textBox1.Text; //koyoungsuk2.dyndns.org:1521/xe 
                String id = textBox2.Text;
                String password = textBox3.Text;

                String address = fulladdress.Split(':')[0];
                String sidandport = fulladdress.Split(':')[1];
                String port = sidandport.Split('/')[0];
                String sid = sidandport.Split('/')[1];

                String connstr = g.connectionString(address, port, sid, id, password);

                conn = new OracleConnection(connstr);

                conn.Open();

                MainForm mf = new MainForm(conn);
                mf.Show();
                this.Hide(); 
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
        #endregion

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();  //엔터키 눌렀을때 로그인 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //닫기 
        }
    }
}
