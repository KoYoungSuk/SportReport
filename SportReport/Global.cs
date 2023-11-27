using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportReport
{
    public class Global
    {
        #region["데이터베이스 연결 정보 스트링(파라미터로 받아와서 리턴)"]
        public String connectionString(String address, String port, String sid, String id, String pw)
        {
            String connstr = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4}", address, port, sid, id, pw);
            return connstr;
        }
        #endregion

        #region["OS 버전 확인"]
        public String checkOS()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string osBuild = Registry.GetValue(HKLMWinNTCurrent, "CurrentBuildNumber", "").ToString();
            String label;
            String[] osName_arr = osName.Split(' ');
            if (osName_arr[1].Equals("10"))
            {
                if (Int32.Parse(osBuild) > 22000) //Windows 11 및 Windows 10/Server 2016~2022 구분 
                {
                    label = "Your OS : Windows 11 " + osName_arr[2] + " Build: " + osBuild;
                }
                else
                {
                    label = "Your OS : " + osName + " Build: " + osBuild;
                }
            }
            else
            {
                label = "Your OS : " + osName + " Build: " + osBuild;
            }
            return label;
        }
        #endregion

        #region["오류 메시지"] 
        public DialogResult errormessage(String errormsg)
        {
            return MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region["정보 메시지"] 
        public DialogResult informationmessage(String msg)
        {
            return MessageBox.Show(msg, "SportReport", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        #endregion

    }
}
