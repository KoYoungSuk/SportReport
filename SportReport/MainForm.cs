using Oracle.ManagedDataAccess.Client;
using SportReport.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportReport
{
    public partial class MainForm : Form
    {
        OracleConnection conn = null;
        Global g = new Global(); 
        public MainForm(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            label4.Text = g.checkOS();  //OS정보 체크 
            getInfo();
            this.KeyPreview = true; 
        }

        #region["테이블로부터 정보 가져오기"] 
        private void getInfo()
        {
            try
            {
                SportDAO sportdao = new SportDAO(conn);
                DataTable dt = sportdao.getSportTotalList();
                dataGridView1.DataSource = dt; 
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(conn != null)
            {
                conn.Close();
                conn = null; 
            }
            Application.Exit(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
            Application.Exit();
        }

        private void closeXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
            Application.Exit();
        }

        #region["정보 삭제"] 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBox1.Text);

                SportDAO sportdao = new SportDAO(conn);

                int result = sportdao.deleteSportinfo(num);

                if(result != 0)
                {
                    g.informationmessage("성공적으로 삭제되었습니다.");
                    getInfo(); 
                }
                else
                {
                    g.errormessage("Unknown Error Message"); 
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            WriteForm wf = new WriteForm(conn, "write", 0);
            wf.Show(); 
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                getInfo(); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            WriteForm wf = new WriteForm(conn, "modify", Convert.ToInt32(textBox1.Text));
            wf.Show(); 
        }

        private void aboutSportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show(); 
        }

        private void jSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://home.yspersonal.com"); 
        }

        private void naverBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://blog.naver.com/vheh5678"); 
        }
    }
}
