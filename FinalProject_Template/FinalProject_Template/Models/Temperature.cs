using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Template.Models
{
    public class Temperature
    {
        public Temperature(int readingID, float humidity, float celsius, float fahrenheit, DateTime time)
        {
            ReadingID = readingID;
            Humidity = humidity;
            Celsius = celsius;
            Fahrenheit = fahrenheit;
            Time = time;
        }

        public int ReadingID { get; set; }
        public float Humidity { get; set; }
        public float Celsius { get; set; }
        public float Fahrenheit { get; set; }
        public DateTime Time { get; set; }
    }
}
