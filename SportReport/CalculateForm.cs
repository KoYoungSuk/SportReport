using Oracle.ManagedDataAccess.Client;
using SportReport.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace SportReport
{
    public partial class CalculateForm : Form
    {
        String daymonth;
        OracleConnection conn; 
        Global g = new Global(); 
        public CalculateForm(String daymonth, OracleConnection conn)
        {
            InitializeComponent();
            this.daymonth = daymonth;
            this.conn = conn; 
            textBox1.Text =  daymonth;
            label9.Text = daymonth; 
            calculateAverageSport();
            calculateMaxMinSport(); 
        }

        private void calculateMaxMinSport()
        {
            String title = label9.Text;
            try
            {
                SportDAO sportdao = new SportDAO(conn);
                Dictionary<string, object> mindistance = sportdao.getMinDistanceandDate(title);
                Dictionary<string, object> maxdistance = sportdao.getMaxDistanceandDate(title);
                Dictionary<string, object> mincalories = sportdao.getMinCaloriesandDate(title);
                Dictionary<string, object> maxcalories = sportdao.getMaxCaloriesandDate(title);

                MinDistance.Text = "최소 이동거리/날짜: " + mindistance["title"] + "/" + mindistance["distance"] + "걸음";
                MaxDistance.Text = "최대 이동거리/날짜: " + maxdistance["title"] + "/" + maxdistance["distance"] + "걸음";
                MinCalories.Text = "최소 소모 칼로리/날짜: " +  mincalories["title"] + "/" + mincalories["calories"] + "Kcal";
                MaxCalories.Text = "최대 소모 칼로리/날짜: " + maxcalories["title"] + "/" + maxcalories["calories"] + "Kcal"; 
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }

        private void calculateAverageSport()
        {
            String title = label9.Text;
            try{
                SportDAO sportdao = new SportDAO(conn);
                int avgdistance = sportdao.getAvgDistance(title);
                int avgcalories = sportdao.getAvgCalories(title);

                AvgDistance.Text = "평균 이동거리: " + avgdistance + "걸음";
                AvgCalories.Text = "평균 소모 칼로리: " + avgcalories + "Kcal";
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }

        private void CalculateForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            label9.Text = textBox1.Text; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculateAverageSport(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculateMaxMinSport(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.Title = "Save as Text Document";
                saveFileDialog1.FileName = label9.Text + ".txt"; 
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("Current Date: " + DateTime.Now.ToString() + "\r\n"); 
                    sw.WriteLine(AvgDistance.Text + "\r\n");
                    sw.WriteLine(AvgCalories.Text + "\r\n"); 
                    sw.WriteLine(MinDistance.Text + "\r\n");
                    sw.WriteLine(MaxDistance.Text + "\r\n");
                    sw.WriteLine(MinCalories.Text + "\r\n");
                    sw.WriteLine(MaxCalories.Text + "\r\n");
                    sw.Flush();
                    sw.Close();
                    g.informationmessage("성공적으로 저장되었습니다."); 
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
    }
}
