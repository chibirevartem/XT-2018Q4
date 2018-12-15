using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._5.Tointornottoint
{
    static class StringExtensions
    {
        private static bool IsValidate(this string input)
        {
            bool result = true;
            int length = input.Length;
            bool validation = false;
            bool static_validation = true;

            static_validation |= input.IndexOf('E') > input.IndexOf('.');
            static_validation &= char.IsDigit(input[0]) || input[0] == '+';
            static_validation &= char.IsDigit(input[length - 1]);

            if (static_validation)
            {
                int commas = 0;
                int exponents = 0;

                for (int i = 1; i < length; i++)
                {
                    validation |= char.IsDigit(input[i]);
                    validation |= (input[i]) == '.';
                    validation |= (input[i]) == 'E';
                    validation |= (input[i]) == '+'|| (input[i]) == '-'& input[i - 1] == 'E';
                    validation &= (commas < 2 & exponents < 2);

                    if (validation)
                    {
                        if ((input[i]) == 'E' || (input[i]) == 'e') { exponents++; }
                        if ((input[i]) == '.') { commas++; }
                        if ((input[i]) == 'E' & !char.IsDigit(input[i - 1])) { result = false; break; }

                        validation = false;
                    }
                    else { result = false; break; }
                }
            }
            else { result = false; }
            
            return result;
        }

        private static string[] Recognition(this string input)
        {
            
            int length = input.Length;
            string whole="0";
            string fraction= null;
            string exponent=null;
            string signOfExponent = "+";

            bool IsEnableExponent=false;
            bool IsEnableSeparator = false;

            char separator = '.';
            char exhibitor = 'E';
            

            int indexOfSeparator = -1 ;
            int indexOfExponent = -1 ;

            if (IsValidate(input))
            {
                for (int i = 0; i < length; i++)
                {
                    if (input[i] == separator)
                    {
                        IsEnableSeparator = true;
                        indexOfSeparator = i;
                    }

                    if (input[i] == exhibitor)
                    {
                        IsEnableExponent = true;
                        indexOfExponent=i;
                    }
                }

                if (!IsEnableSeparator & !IsEnableExponent)
                {
                    input += ".0";
                    input += "E0";
                    length = input.Length;
                }
                else if (!IsEnableSeparator & IsEnableExponent)
                {
                    if (indexOfExponent!=-1)
                    {
                        input = input.Insert(indexOfExponent, ".0");
                        length = input.Length;
                    }
                }

                else if(IsEnableSeparator& !IsEnableExponent)
                {
                    input += "E0";
                    length = input.Length;
                }

                for (int i = 0; i < input.IndexOf(separator); i++)
                {
                    
                        whole += input[i];
                    
                }
                for (int i = 0; i < whole.Length; i++)
                {
                    if (whole[i] != '0' & char.IsDigit(whole[i]))
                    {
                        whole = whole.Remove(0, i);
                        break;
                    }
                }

                for (int i = input.IndexOf(separator) + 1; i < input.IndexOf(exhibitor); i++)
                {
                    fraction += input[i];
                }

                for (int i = input.IndexOf(exhibitor); i > (input.IndexOf(separator)); i--)
                {
                    if (input[i] == '0')
                    {
                        fraction = fraction.Remove(fraction.Length - 1);
                    }
                    else if (input[i] != '0' & char.IsDigit(input[i]))
                    {
                        break;
                    }
                }

                for (int i = input.IndexOf(exhibitor) + 1; i < length; i++)
                {
                    exponent += input[i];

                    if (input[i] == '-') { signOfExponent = "-"; }
                   
                }

                for (int i = 0; i < exponent.Length; i++)
                {
                    
                    if (exponent[i] != '0' & char.IsDigit(exponent[i]))
                    {
                        exponent = exponent.Remove(0, i);
                        break;
                    }
                }

            }
            else { throw new Exception("Has not validated"); }

            if (fraction == "") { fraction = "0"; }
          
            string[] output= new string[] { whole,fraction,exponent,signOfExponent};

            return output;
            
        }

        public static bool IsPositiveInt(this string input)
        {
            bool result = false;
            string whole, fraction, signOfExponent;
            int exponent;

            if (IsValidate(input))
            {
                string[] data = Recognition(input);
                
                whole = data[0];
                fraction = data[1];
                
                signOfExponent = data[3];

                if (signOfExponent=="+")
                {
                    exponent = Convert.ToInt32(data[2]);
                    if (whole[whole.Length - 1] == '0'& fraction=="0")
                    {
                        for (int i = whole.Length - 1; i > 0; i--)
                        {
                            if (whole[i] == '0')
                            {
                                whole = whole.Remove(whole.Length - 1);
                                exponent++;
                            }
                        }
                    }
                    result |= exponent >= fraction.Length;
                    result |= fraction == "0" & exponent == 0 & whole != "0";
                }
                else if (signOfExponent == "-")
                {
                    exponent = (-1)*Convert.ToInt32(data[2]);
                    if (whole[whole.Length-1]=='0' & fraction == "0")
                    {
                        for (int i = whole.Length - 1; i > 0; i--)
                        {
                            if (whole[i] == '0')
                            {
                                whole = whole.Remove(whole.Length-1);
                                exponent++;
                            }
                        }
                    }

                    result |= fraction == "0" & whole.Length + exponent>0;
                }
            }
            return result;
        }
    }

        
    
    class Program
    {
        
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Please, type in a number:");
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.Replace('e', 'E');
                    Console.WriteLine(input.IsPositiveInt());
                }
            }

        }
    }
}
