using Oracle.ManagedDataAccess.Client;
using SportReport.DAO;
using SportReport.Model;
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
            textBox1.Text = DateTime.Now.ToShortDateString(); 
            this.KeyPreview = true;
            getInfo(textBox1.Text); 
        }

        private void getInfo(String title)
        {
            try
            {
                SportDAO sportdao = new SportDAO(conn);

                Dictionary<string, object> sportlist = sportdao.getSportListByTitle(title);

                if(sportlist != null)
                {
                    textBox1.Text = title;
                    radioButton2.Enabled = true; 
                    radioButton2.Checked = true; //기본: 수정 기능 
                    radioButton1.Enabled = false; //작성 기능 사용불가
                    radioButton3.Enabled = true; //읽기 기능 사용가능 
                    if (sportlist["distance"] != null)
                    {
                        textBox2.Text = sportlist["distance"].ToString();
                    }
                    if (sportlist["calories"] != null)
                    {
                        textBox3.Text = sportlist["calories"].ToString();
                    }
                    if (sportlist["savedate"] != null)
                    {
                        label7.Text = "SAVE DATE: " + sportlist["savedate"].ToString();
                    }
                }
                else
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label7.Text = "SAVE DATE: ";
                    radioButton1.Enabled = true; 
                    radioButton1.Checked = true; //아무것도 없으면 작성 기능만 사용가능 
                    radioButton2.Enabled = false; //수정 기능 사용불가 
                    radioButton3.Enabled = false; //작성 기능 사용불가 
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
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

        private void label2_Click(object sender, EventArgs e){}

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

        #region["키보드 이벤트"] 

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.W && radioButton1.Enabled) //작성 
            {
                radioButton1.Checked = true; 
                Write_radioBtn(sender, e); 
            }
            if (e.KeyCode == Keys.M && radioButton2.Enabled) //수정 
            {
                radioButton2.Checked = true; 
                Modify_radioBtn(sender, e); 
            }
            if(e.KeyCode == Keys.R && radioButton3.Enabled) //읽기 
            {
                radioButton3.Checked = true; 
                Read_WriteBtn(sender, e); 
            }
        }
        #endregion


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

        #region["작성 및 수정"] 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String title = textBox1.Text;
                int distance = Convert.ToInt32(textBox2.Text);
                int calories = Convert.ToInt32(textBox3.Text);
                SportDTO sportdto = new SportDTO(title, DateTime.Now.ToString(), distance, calories);
                SportDAO sportdao = new SportDAO(conn);
                int result = 0;
                if (radioButton1.Checked) //작성 모드 
                {
                    result = sportdao.insertSportInfo(sportdto); 
                }
                else if (radioButton2.Checked) //수정 모드 
                {
                    result = sportdao.updateSportInfo(sportdto); 
                }

                if(result != 0)
                {
                    g.informationmessage("Successfully Saved.");
                    getInfo(title); 
                }
                else
                {
                    g.errormessage("Unknown Error Message"); 
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }
        #endregion

        #region["삭제"] 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String title = textBox1.Text;
                SportDAO sportdao = new SportDAO(conn);
                int result = sportdao.deleteSportinfo(title);
                if(result != 0)
                {
                    g.informationmessage("Successfully Deleted.");
                    getInfo(DateTime.Now.ToString()); 
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }


        private void monthCalendar1_DockChanged(object sender, EventArgs e) { }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            getInfo(textBox1.Text); 
        }

        #region["작성 모드"] 
        private void Write_radioBtn(object sender, EventArgs e)
        {
            button2.Enabled = false; //삭제 기능 사용불가 
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button1.Enabled = true; //작성&수정 기능 사용가능 
        }
        #endregion

        #region["수정 모드"] 
        private void Modify_radioBtn(object sender, EventArgs e)
        {
            button2.Enabled = false; //삭제 기능 사용불가 
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button1.Enabled = true; //작성&수정 기능 사용가능 
        }
        #endregion

        #region["읽기 모드"] 
        private void Read_WriteBtn(object sender, EventArgs e)
        {
            button2.Enabled = true; //삭제 기능 사용가능
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            button1.Enabled = false; //작성&수정 기능 사용불가 

        }
        #endregion

        private void calculateCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CalculateForm cf = new CalculateForm(DateTime.Now.ToString("yyyy-MM"), conn); 
            cf.Show(); 
        }
    }
}
