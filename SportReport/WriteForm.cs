using Oracle.ManagedDataAccess.Client;
using SportReport.DAO;
using SportReport.Model;
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
    public partial class WriteForm : Form
    {
        OracleConnection conn = null;
        Global g = new Global();
        String mode = string.Empty; 
        public WriteForm(OracleConnection conn, String mode, int num)
        {
            InitializeComponent();
            this.conn = conn;
            this.mode = mode;
            if(mode.Equals("write")) //작성 모드 
            {
                textBox1.Text = "";
                textBox2.Text = ""; 
            }
            else //수정 모드 
            {
                this.Text = num + "";
                getSportInfoByNum(num); 
            }
        }

        private void getSportInfoByNum(int num)
        {
            try
            {
                SportDAO sportdao = new SportDAO(conn);
                Dictionary<string, object> sportlist = sportdao.getSportListByNum(num); 
                if(sportlist != null)
                {
                    textBox1.Text = sportlist["distance"].ToString();
                    textBox2.Text = sportlist["calories"].ToString(); 
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String distance = textBox1.Text;
                String calories = textBox2.Text;

                SportDAO sportdao = new SportDAO(conn);


                int num = 0;

                if (mode.Equals("write"))
                {
                    num = sportdao.getMaxNum();
                    num = num + 1; 
                }
                else
                {
                    num = Convert.ToInt32(this.Text); 
                }

                SportDTO sportdto = new SportDTO(num, DateTime.Now.ToString(), Convert.ToInt32(distance), Convert.ToInt32(calories));

                int result = 0; 
                if(mode.Equals("write")) //작성 모드 
                {
                    result = sportdao.insertSportInfo(sportdto);
                }
                else
                {
                    result = sportdao.updateSportInfo(sportdto); 
                }

                if (result != 0)
                {
                    g.informationmessage("성공적으로 저장되었습니다.");
                    this.Hide(); 
                }
                else
                {
                    g.errormessage("Unknown Error Message."); 
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); 
            }
        }
    }
}
