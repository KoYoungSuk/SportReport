using Oracle.ManagedDataAccess.Client;
using SportReport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
            String sql = "insert into sport (title, calories, distance, savedate) values (:title, :calories, :distance, :savedate)";
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("title", sportdto.Title));
            icmd.Parameters.Add(new OracleParameter("calories", sportdto.Calories));
            icmd.Parameters.Add(new OracleParameter("distance", sportdto.Distance));
            icmd.Parameters.Add(new OracleParameter("savedate", sportdto.Savedate));

            int result = icmd.ExecuteNonQuery();
            icmd.Dispose();
            return result;
        }
        #endregion

        #region["운동 기록 정보 업데이트"] 
        public int updateSportInfo(SportDTO sportdto)
        {
            String sql = "update sport set distance=:distance, calories=:calories where title = :title";
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("distance", sportdto.Distance));
            ucmd.Parameters.Add(new OracleParameter("calories", sportdto.Calories));
            ucmd.Parameters.Add(new OracleParameter("title", sportdto.Title));

            int result = ucmd.ExecuteNonQuery();
            ucmd.Dispose();
            return result;

        }
        #endregion

        #region["운동 기록 정보 삭제"]
        public int deleteSportinfo(String title)
        {
            String sql = "delete from sport where title = :title";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("title", title));
            int result = dcmd.ExecuteNonQuery();
            dcmd.Dispose();
            return result;
        }
        #endregion




        #region["운동 기록 일부만 불러오기 -> 날짜에 맞춰서"]
        public Dictionary<string, object> getSportListByTitle(String title)
        {
            Dictionary<string, object> sportlist = null;
            String sql = "select * from sport where title = :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", title));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                sportlist = new Dictionary<string, object>(); //NULL 검사를 위해서... 
                sportlist.Add("title", odr["title"]);
                sportlist.Add("distance", odr["distance"]);
                sportlist.Add("calories", odr["calories"]);
                sportlist.Add("savedate", odr["savedate"]);
            }
            scmd.Dispose();
            return sportlist;
        }
        #endregion


        #region["달에 따라 평균 칼로리 계산하기"] 
        public int getAvgCalories(String daymonth)
        {
            int calories = 0;
            String sql = "select avg(calories) as avgcalories from sport where title like :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                calories = Convert.ToInt32(odr["avgcalories"]);
            }
            scmd.Dispose();
            return calories;
        }
        #endregion

        #region["달에 따라 평균 이동거리 계산하기"] 
        public int getAvgDistance(String daymonth)
        {
            int distance = 0;
            String sql = "select avg(distance) as avgdistance from sport where title like :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                distance = Convert.ToInt32(odr["avgdistance"]); 
            }
            scmd.Dispose();
            return distance; 
        }
        #endregion

        #region["달에 따라 최대 칼로리 계산하기")
        public Dictionary<string, object> getMaxCaloriesandDate(String daymonth)
        {
            Dictionary<string, object> caloriesanddate = null;
            String title = null; 
            int calories = 0; 
            String sql = "select max(calories) as maxcalories from sport where title like :title"; 
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                calories = Convert.ToInt32(odr["maxcalories"]); 
            }
            scmd.Dispose();
            odr.Dispose(); 
            sql = "select title from sport where calories = :calories";
            OracleCommand scmd2 = new OracleCommand(sql, conn);
            scmd2.BindByName = true;
            scmd2.Parameters.Add(new OracleParameter("calories", calories));
            OracleDataReader odr2 = scmd2.ExecuteReader(); 
            if (odr2.Read())
            {
                title = odr2["title"].ToString(); 
            }
            caloriesanddate = new Dictionary<string, object>();
            caloriesanddate.Add("title", title);
            caloriesanddate.Add("calories", calories);
            scmd2.Dispose();
            odr2.Dispose(); 
            return caloriesanddate; 
        }
        #endregion

        #region["달에 따라 최대 이동거리 계산하기"] 
        public Dictionary<string, object>  getMaxDistanceandDate(String daymonth)
        {
            Dictionary<string, object> distanceanddate = null;
            String title = null;
            int distance = 0; 
            String sql = "select max(distance) as maxdistance from sport where title like :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                distance = Convert.ToInt32(odr["maxdistance"]); 
            }
            scmd.Dispose();
            odr.Dispose();
            sql = "select title from sport where distance = :distance";
            OracleCommand scmd2 = new OracleCommand(sql, conn);
            scmd2.BindByName = true;
            scmd2.Parameters.Add(new OracleParameter("distance", distance));
            OracleDataReader odr2 = scmd2.ExecuteReader();
            if (odr2.Read())
            {
                title = odr2["title"].ToString(); 
            }
            distanceanddate = new Dictionary<string, object>();
            distanceanddate.Add("title", title);
            distanceanddate.Add("distance", distance);
            scmd2.Dispose();
            odr2.Dispose(); 
            return distanceanddate; 
        }
        #endregion

        #region["달에 따라 최소 칼로리 계산하기"]
        public Dictionary<string, object> getMinCaloriesandDate(String daymonth)
        {
            Dictionary<string, object> caloriesanddate = null;
            String title = null;
            int calories = 0;
            String sql = "select min(calories) as mincalories from sport where title like :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                calories = Convert.ToInt32(odr["mincalories"]);
            }
            scmd.Dispose();
            odr.Dispose();
            sql = "select title from sport where calories = :calories";
            OracleCommand scmd2 = new OracleCommand(sql, conn);
            scmd2.BindByName = true;
            scmd2.Parameters.Add(new OracleParameter("calories", calories));
            OracleDataReader odr2 = scmd2.ExecuteReader();
            if (odr2.Read())
            {
                title = odr2["title"].ToString();
            }
            caloriesanddate = new Dictionary<string, object>();
            caloriesanddate.Add("title", title);
            caloriesanddate.Add("calories", calories);
            scmd2.Dispose();
            odr2.Dispose();
            return caloriesanddate;
        }
        #endregion

        #region["달에 따라 최소 이동거리 계산하기"]
        public Dictionary<string, object> getMinDistanceandDate(String daymonth)
        {
            Dictionary<string, object> distanceanddate = null;
            String title = null;
            int distance = 0;
            String sql = "select min(distance) as mindistance from sport where title like :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", daymonth + "%"));
            OracleDataReader odr = scmd.ExecuteReader();
            if (odr.Read())
            {
                distance = Convert.ToInt32(odr["mindistance"]);
            }
            scmd.Dispose();
            odr.Dispose();
            sql = "select title from sport where distance = :distance";
            OracleCommand scmd2 = new OracleCommand(sql, conn);
            scmd2.BindByName = true;
            scmd2.Parameters.Add(new OracleParameter("distance", distance));
            OracleDataReader odr2 = scmd2.ExecuteReader();
            if (odr2.Read())
            {
                title = odr2["title"].ToString();
            }
            distanceanddate = new Dictionary<string, object>();
            distanceanddate.Add("title", title);
            distanceanddate.Add("distance", distance);
            scmd2.Dispose();
            odr2.Dispose();
            return distanceanddate;
        }
        #endregion

    }
}
