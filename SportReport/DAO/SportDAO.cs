using Oracle.ManagedDataAccess.Client;
using SportReport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportReport.DAO
{
    public class SportDAO
    {
        OracleConnection conn = null;
        Global g = new Global();

        #region["생성자"] 
        public SportDAO(OracleConnection conn)
        {
            this.conn = conn;
        }
        #endregion

        #region["운동 기록 정보 입력"] 
        public int insertSportInfo(SportDTO sportdto)
        {
            String sql = "insert into sport (num, savedate, distance, calories) values (:num, :savedate, :distance, :calories)";
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("num", sportdto.Num));
            icmd.Parameters.Add(new OracleParameter("savedate", sportdto.Savedate));
            icmd.Parameters.Add(new OracleParameter("distance", sportdto.Distance));
            icmd.Parameters.Add(new OracleParameter("calories", sportdto.Calories));

            int result = icmd.ExecuteNonQuery();
            icmd.Dispose();
            return result;
        }
        #endregion

        #region["운동 기록 정보 업데이트"] 
        public int updateSportInfo(SportDTO sportdto)
        {
            String sql = "update sport set distance=:distance, calories=:calories where num = :num";
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("distance", sportdto.Distance));
            ucmd.Parameters.Add(new OracleParameter("calories", sportdto.Calories));
            ucmd.Parameters.Add(new OracleParameter("num", sportdto.Num));

            int result = ucmd.ExecuteNonQuery();
            ucmd.Dispose();
            return result;

        }
        #endregion

        #region["운동 기록 정보 삭제"]
        public int deleteSportinfo(int num)
        {
            String sql = "delete from sport where num = :num";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("num", num));
            int result = dcmd.ExecuteNonQuery();
            dcmd.Dispose();
            return result;
        }
        #endregion


        #region["운동 기록 불러오기"]
        public DataTable getSportTotalList()
        {
            DataTable dt = new DataTable();
            String sql = "select * from sport order by num";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter(scmd);
            oda.Fill(dt);
            scmd.Dispose();
            return dt; 
        }
        #endregion

        #region["운동 기록 일부만 불러오기 -> 번호에 맞춰서"]
        public Dictionary<string, object> getSportListByNum(int num)
        {
            Dictionary<string, object> sportlist = new Dictionary<string, object>();
            String sql = "select * from sport where num = :num";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("num", num));
            OracleDataReader odr = scmd.ExecuteReader();
            if(odr.Read())
            {
                sportlist.Add("num", odr["num"]);
                sportlist.Add("savedate", odr["savedate"]);
                sportlist.Add("distance", odr["distance"]);
                sportlist.Add("calories", odr["calories"]); 
            }
            scmd.Dispose();
            return sportlist; 
        }
        #endregion

        #region["최대 번호 불러오기"] 
        public int getMaxNum()
        {
            int maxnum = 0;
            String sql = "select max(num) as maxnum from sport";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader odr = scmd.ExecuteReader();
            if(odr.Read())
            {
                if (odr["maxnum"] != System.DBNull.Value) //DBNull Check 
                {
                    maxnum = Convert.ToInt32(odr["maxnum"]);
                }
            }
            scmd.Dispose();
            return maxnum; 
        }
        #endregion


    }
}
