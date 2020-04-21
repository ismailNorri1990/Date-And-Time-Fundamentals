using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_And_Time_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //My Current Time in Morocco
            DateTime dateTime = DateTime.UtcNow;

            //Convert to a time zone

            TimeZoneInfo systemTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime TokyoTime = TimeZoneInfo.ConvertTime(dateTime, systemTimeZone);
            
            //Rendering the times to Console 
            Console.WriteLine(dateTime);
            Console.WriteLine(systemTimeZone);
            Console.WriteLine(TokyoTime);
        }
    }
}
