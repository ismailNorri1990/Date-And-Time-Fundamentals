﻿using System;
using System.Collections.Concurrent;
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

            //Formating date and time for serializing it and store in document or database

            var dateTimeToParse = "9/10/2019 10:00:00 PM";
            

            var ParsedDate = DateTimeOffset.ParseExact(dateTimeToParse, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            ParsedDate = ParsedDate.ToOffset(TimeSpan.FromHours(10));

            // "o" , "s" ,"yyyy-MMM-dd"
            var formatedDate = ParsedDate.ToString("o");


            // Returning Iso 8601
            Console.WriteLine(formatedDate);

            //Working with UTC

            var dateUtc = DateTimeOffset.UtcNow;
            var LocalTime = dateUtc.ToLocalTime();

            Console.WriteLine("\t"+LocalTime);
             
            

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

            Console.WriteLine("***********************\n\n");
            Console.WriteLine("Date And Time Arithmetic");
            Console.WriteLine("***********************\n\n");


            //Working with timeSpan

            Console.WriteLine("***********************\n\n");
            Console.WriteLine("\tTimeSpan");
            Console.WriteLine("***********************\n\n");

            var timeSpan = new TimeSpan(60, 72, 100);
            Console.WriteLine(timeSpan.Days);
            Console.WriteLine(timeSpan.Hours);
            Console.WriteLine(timeSpan.Minutes);
            Console.WriteLine(timeSpan.Seconds);

            Console.WriteLine("***********************\n\n");
            Console.WriteLine("Difference with Time Span");
            Console.WriteLine("***********************\n\n");

            var start = DateTimeOffset.UtcNow;
            var end = start.AddSeconds(45);

            TimeSpan diff = end - start ;

            diff = diff.Subtract(TimeSpan.FromSeconds(10));

            Console.WriteLine(diff);



        }
    }
}
