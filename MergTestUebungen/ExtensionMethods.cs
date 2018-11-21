using System;
using System.Globalization;

namespace MergTestUebungen
{
    public static class ExtensionMethods
    {
        //Mit dem schlüssel Wort this wird der Parameter definiert der zuerweitern ist. Dieser Parameter wird nicht mit übergeben. 

        public static string UppercaseFirstLetter(this string value)
        {
            if (value.Length>0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        } 

        public static int WordCount(this string value)
        {
            //return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
           return value.Split(new char[]{ ',', '.', '?', '!','#',' ', }, StringSplitOptions.RemoveEmptyEntries).Length;

        }

        public static int TryToIntager(this string value)
        {
            int i = 0;            
            bool x = Int32.TryParse(value,out i);
            return i;
        }

        public static double TryToDouble(this string value)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netframework-4.7.2
            //http://www.csharp-examples.net/culture-names/
            //https://stackoverflow.com/questions/23131414/culture-invariant-decimal-tryparse
            double i = 0.0;
            bool x = Double.TryParse(value,NumberStyles.Any,new CultureInfo("de-AT"), out i);
            return i;
        }


        public static bool IsACreditcard(this string value)
        {
            int sum = 0;
            int len = value.Length;
            for (int i = 0; i < len; i++)
            {
                int add = (value[i] - '0') * (2 - (i + len) % 2);
                add -= add > 9 ? 9 : 0;
                sum += add;
            }
            return sum % 10 == 0;       
    }


    }
}
