using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportReport.Model
{
    public class SportDTO
    {
        String title; 
        String savedate;
        int distance;
        int calories;

        public string Title { get => title; set => title = value; }
        public string Savedate { get => savedate; set => savedate = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Calories { get => calories; set => calories = value; }

        public SportDTO()
        {

        }

        public SportDTO(String title, string savedate, int distance, int calories)
        {
            Title = title; 
            Savedate = savedate;
            Distance = distance;
            Calories = calories;
        }
    }
}
