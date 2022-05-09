using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciUygulamasi
{
     public static class Utils
    {

        public static int MenuSelection()
        {
            int sel;
            do
            {
                Console.WriteLine();
                Console.Write("Selection: ");
                sel = GetNumber();
            }
            while (sel < 1 || sel > 24);
            return sel;
        }


        public static int GetNumber()
        {
            int num;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out num))
                {
                    return num;
                }
                Console.WriteLine();
                Console.Write("Please enter a valid number: ".PadLeft(15));
            }
        }


        static public DateTime GetDate()
        {
            DateTime date;

            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out date))
                {
                    return date;
                }
                Console.WriteLine();
                Console.Write("Please enter a valid date: ");
            }
        }


    







        public static string TextToArray(string text, char split, char joinChar)
        {
            
            string[] arrText = text.Split(split);

            for (int i = 0; i < arrText.Length; i++)
            {
                arrText[i] = arrText[i].Trim();
                arrText[i] = UpperCase(arrText[i]);

            }
            text = string.Join(joinChar, text);

            return text;
        }
        public static string UpperCase(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {

                string firstLetter = text.Substring(0, 1).ToUpper();
                string rest = text.Substring(1).ToLower();
                return (firstLetter + rest);
            }
            else
            {
                return text;
            }
        }

    }

}

