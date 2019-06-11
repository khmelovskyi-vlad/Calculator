using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int opperand1 = 0;
            int opperandX = 0;
            char opperation = default(char);
            while (true)
            {
                var isp = ReadOperation();
                int curentOpperand;
                try
                {
                    curentOpperand = Convert.ToInt32(isp.Substring(0, isp.Length - 1));
                }
                catch
                {
                    curentOpperand = opperand1;
                }
                var curentOperation = isp[isp.Length - 1];
                if (curentOperation == 'X')
                {
                    opperandX = opperand1;
                }
                else if (curentOperation == 'C')
                {
                    opperand1 = opperand1+opperandX;
                    Console.Write($"={opperand1}");
                }
                else if (curentOperation == '=')
                {
                    switch (opperation)
                    {
                        case default(char):
                            opperand1 = curentOpperand;
                            break;
                        case '+':
                            opperand1 = opperand1 + curentOpperand;
                            break;
                        case '-':
                            opperand1 = opperand1 - curentOpperand;
                            break;
                        case '*':
                            opperand1 = opperand1 * curentOpperand;
                            break;
                        case '/':
                            opperand1 = opperand1 / curentOpperand;
                            break;
                    }
                    Console.Write(opperand1);
                }
                else
                {
                    opperand1 = curentOpperand;
                    opperation = curentOperation;
                }
            }
        }
        static string ReadOperation()
        {
            string result = "";
            while (true)
            {
                var k = Console.ReadKey(true);
                if (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.X && k.Key != ConsoleKey.C)
                {
                    Console.Write(k.KeyChar);
                }
                if(k.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }
                result += k.KeyChar;
                if (k.KeyChar == '=' || k.KeyChar == '+' || k.KeyChar == '-' || k.KeyChar == '/' || k.KeyChar == '*' || k.KeyChar == 'X' || k.KeyChar == 'C')
                {
                    return result;
                }
            }
        }
    }
}
