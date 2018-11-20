using System;
using System.Globalization;

namespace MergTestUebungen
{
    public static class ExtensionMethods
    {
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
            var x = Int32.TryParse(value,out i);
            return i;
        }

        


    }
}
