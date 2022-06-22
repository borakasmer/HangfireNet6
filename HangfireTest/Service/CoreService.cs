namespace HangfireTest.Service
{
    public class CoreService : ICoreService
    {
        public bool ToolConvertNumberToText(int num, out string text)
        {
            string[] ones = {
            "Bir", "Iki", "Uc", "Dort", "Bes", "Alti", "Yedi", "Sekiz",
            "Dokuz", "On", "Onbir", "Oniki", "Onuc", "Ondort",
            "Onbes", "Onaltı", "Onyedi", "Onsekiz", "Ondokuz",
          };

            string[] tens = {
              "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmis",
              "Yetmis", "Seksen", "Doksan", "Yuz"
          };

            string result = "";
            text = "";
            int single, tenss, hundreds;

            if (num > 1000)
                return false;

            hundreds = num / 100;
            num = num - hundreds * 100;
            if (num < 20)
            {
                tenss = 0;
                single = num;
            }
            else
            {
                tenss = num / 10;
                num = num - tenss * 10;
                single = num;
            }

            result = "";
            if (hundreds > 0)
            {
                result += ones[hundreds - 1];
                //result += " Yuz ";
                result += "Yuz";
            }

            if (tenss > 0)
            {
                result += tens[tenss - 1];
                //result += " ";
            }
            if (single > 0)
            {
                result += ones[single - 1];
                //result += " ";
            }
            text = result;
            return true;
        }



        public bool ConvertNumberToText(int num, out string result)
        {
            string tempString = "";
            int thousands;
            int temp;
            result = "";
            if (num > 100000)
            {
                return false;
            }
            if (num < 0)
            {
                ToolConvertNumberToText(num * -1, out tempString);
                result += "-" + tempString;
            }
            if (num == 0)
            {
                //System.Console.WriteLine(num + " \tZero");
                //return false;
                result += "Sıfır";
            }

            if (num < 1000 && num > 0)
            {
                ToolConvertNumberToText(num, out tempString);
                result += tempString;
            }
            else if (num > 0)
            {
                thousands = num / 1000;
                temp = num - thousands * 1000;
                ToolConvertNumberToText(thousands, out tempString);
                result += tempString;
                //result += "Yuz ";
                result += "Yuz";

                ToolConvertNumberToText(temp, out tempString);
                result += tempString;
            }            
            return true;
        }
    }
}
