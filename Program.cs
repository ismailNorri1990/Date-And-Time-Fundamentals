using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            DateTime dateTime = DateTime.Now;

            //Convert to a time zone

            TimeZoneInfo systemTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime TokyoTime = TimeZoneInfo.ConvertTime(dateTime, systemTimeZone);

            //Using DateTimeOffset (Observing difference with DateTime)
            DateTimeOffset dateTimeOffset = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(-1));

            Console.WriteLine("************************");

            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.GetUtcOffset(dateTimeOffset) == dateTimeOffset.Offset) {
                    Console.WriteLine(timeZone);
                }
            }


            Console.WriteLine("************************");
            //Parsing date 

            var dateTimeToString = dateTime.ToShortDateString() + " " + dateTime.ToLongTimeString();
            Console.WriteLine(dateTimeToString);

            //Using  DateTime.ParseExact with format specification
            var dateTimeParse1 = DateTime.ParseExact(dateTimeToString ,"dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            
            
            //Using  DateTime.Parse
            var dateTimeString = "9/10/2019 10:00:00 PM +02:00";
            var dateTimeParse2 = DateTime.Parse(dateTimeString,CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal );

            
            //Return the date in the specified format
            Console.WriteLine(dateTimeParse1);
            Console.WriteLine(dateTimeParse2);

            //Return le type d'instance Utc, Local ou aucune des deux
            Console.WriteLine(dateTimeParse1.Kind);
            Console.WriteLine(dateTimeParse2.Kind);

            Console.WriteLine("************************");

            //Rendering the times to Console 
            Console.WriteLine(dateTime.Kind);
            Console.WriteLine(systemTimeZone);
            Console.WriteLine(TokyoTime);
            Console.WriteLine(TokyoTime.Kind);
            Console.WriteLine(dateTimeOffset);
        }
    }
}
