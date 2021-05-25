using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConvetor
{
    public static class DecimalToWordHelper
    {
		public static string ToWords(this double value)
		{
			string decimals = "";
            string minus = "";
			string input = Math.Round(value, 2).ToString();

            if (value < -1000 || value > 1000)
                return "Error: Rand out of range";

			if (input.Contains(","))
			{
				decimals = input.Substring(input.IndexOf(",") + 1);
				
				input = input.Remove(input.IndexOf(","));
			}

            if (input.Contains("-"))
            {
                minus = "Minus";
            }

            string strWords = minus + GetWords(input) + " Rand";

			if (decimals.Length > 0)
			{
                strWords += " and " + GetWords(decimals) + " Cents";
			}

			return strWords;
		}

		private static string GetWords(string input)
        {

            if (input.Equals("0")) return "Zero";
		
			string[] seperators = { "", " Thousand "};

			int i = 0;

			string strWords = "";

			while (input.Length > 0)
			{
				// get the 3 last numbers from input and store it. if there is not 3 numbers just use take it.
				string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
				// remove the 3 last digits from input. if there is not 3 numbers just remove it.
				input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

				int no = int.Parse(_3digits);
				
				_3digits = GetWord(no);

				_3digits += seperators[i];
				// since we are getting numbers from right to left then we must append resault to strWords like this.
				strWords = _3digits + strWords;

				// 3 digits converted. count and go for next 3 digits
				i++;
			}
			return strWords;
		}
        private static string GetWord(int no)
		{
			string[] Ones =
			{
			"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
			"Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
		};

			string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };

			string word = "";

			if (no > 99 && no < 1000)
			{
				int i = no / 100;
				word = word + Ones[i - 1] + " Hundred ";
				no = no % 100;
			}

			if (no > 19 && no < 100)
			{
				int i = no / 10;
				word = word + Tens[i - 1] + " ";
				no = no % 10;
			}

			if (no > 0 && no < 20)
			{
				word = word + Ones[no - 1];
			}

			return word;
		}
	}
}
