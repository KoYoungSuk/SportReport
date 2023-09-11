using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportReport.Model
{
    public class SportDTO
    {
        int num;
        String savedate;
        int distance;
        int calories;

        public int Num { get => num; set => num = value; }
        public string Savedate { get => savedate; set => savedate = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Calories { get => calories; set => calories = value; }

        public SportDTO()
        {

        }

        public SportDTO(int num, string savedate, int distance, int calories)
        {
            Num = num;
            Savedate = savedate;
            Distance = distance;
            Calories = calories;
        }
    }
}
