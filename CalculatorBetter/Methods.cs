using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorBetter
{
    class Methods
    {
        public String Sum(String equation)
        {
            equation = CleanUpBrackets(equation);
            char[] equationArr = equation.ToCharArray();
            String noBracketEquation;
            String noDivisionEquation;
            String noMultiplicationEquation;
            String noAdditionEquation;
            String noSubtractionEquation;
            
            for (int i = 0; i < equationArr.Length; i++)
            {
                if (equationArr[i].ToString().Equals("("))
                {
                    int j = equationArr.Length - 1;
                    try
                    {
                        while (!(equationArr[j].ToString().Equals(")")))
                        {
                            j--;
                        }
                        int len = j - (i+1);
                        String bracketedEquation = equation.Substring(i+1, len);
                        String bracketedResult = Sum(bracketedEquation);
                        String temp1 = equation.Substring(0, i);
                        int lenSecondPart = equation.Length - j;
                        String temp2 = equation.Substring(j, lenSecondPart);
                        noBracketEquation = temp1 + bracketedResult + temp2;
                        equationArr = noBracketEquation.ToCharArray();
                        equation = new string(equationArr);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return equation;
                    }
                }
            }
            for (int i = 0; i < equationArr.Length; i++)
            {
                try
                {
                    String temp = equationArr[i].ToString();
                    int x = int.Parse(temp);
                }
                catch (Exception e)
                {
                    String symbol = equationArr[i].ToString();
                    if (symbol.Equals("/"))
                    {
                        string dividedResult = Divide(i, equation, equationArr);
                        int k = GetFirstIndex(i, equation, equationArr);
                        int j = GetSecondIndex(i, equation, equationArr);
                        String temp1 = "";
                        String temp2 = "";
                        if (!(k == 0))
                        {
                            temp1 = equation.Substring(0, k);
                        }

                        if (!(j == equation.Length - 1))
                        {
                            int len = equation.Length - (j + 1);
                            temp2 = equation.Substring(j, len);
                        }
                        noDivisionEquation = temp1 + dividedResult + temp2;
                        equationArr = noDivisionEquation.ToCharArray();
                        equation = new string(equationArr);
                    }
                }
            }
            for (int i = 0; i < equationArr.Length; i++)
            {
                try
                {
                    String temp = equationArr[i].ToString();
                    int x = int.Parse(temp);
                }
                catch (Exception e)
                {
                    String symbol = equationArr[i].ToString();
                    if (symbol.Equals("x"))
                    {
                        string multipliedResult = Multiply(i, equation, equationArr);
                        int k = GetFirstIndex(i, equation, equationArr);
                        int j = GetSecondIndex(i, equation, equationArr);
                        String temp1 = "";
                        String temp2 = "";
                        if (!(k == 0))
                        {
                            temp1 = equation.Substring(0, k);
                        }

                        if (!(j == equation.Length - 1))
                        {
                            int len = equation.Length - (j + 1);
                            temp2 = equation.Substring(j, len);
                        }
                        noMultiplicationEquation = temp1 + multipliedResult + temp2;
                        equationArr = noMultiplicationEquation.ToCharArray();
                        equation = new string(equationArr);
                    }
                }
            }
            for (int i = 0; i < equationArr.Length; i++)
            {
                try
                {
                    String temp = equationArr[i].ToString();
                    int x = int.Parse(temp);
                }
                catch (Exception e)
                {
                    String symbol = equationArr[i].ToString();
                    if (symbol.Equals("+"))
                    {
                        string addedResult = Add(i, equation, equationArr);
                        int k = GetFirstIndex(i, equation, equationArr);
                        int j = GetSecondIndex(i, equation, equationArr);
                        String temp1 = "";
                        String temp2 = "";
                        if (!(k == 0))
                        {
                            temp1 = equation.Substring(0, k);
                        }
                        
                        if(!(j == equation.Length - 1))
                        {
                            int len = equation.Length - (j + 1);
                            temp2 = equation.Substring(j, len);
                        }
                        
                        noAdditionEquation = temp1 + addedResult + temp2;
                        equationArr = noAdditionEquation.ToCharArray();
                        equation = new string(equationArr);
                    }
                }
            }
            for (int i = 0; i < equationArr.Length; i++)
            {
                try
                {
                    String temp = equationArr[i].ToString();
                    int x = int.Parse(temp);
                }
                catch (Exception e)
                {
                    String symbol = equationArr[i].ToString();
                    if (symbol.Equals("-"))
                    {
                        string subtractedResult = Subtract(i, equation, equationArr);
                        int k = GetFirstIndex(i, equation, equationArr);
                        int j = GetSecondIndex(i, equation, equationArr);
                        String temp1 = "";
                        String temp2 = "";
                        if (!(k == 0))
                        {
                            temp1 = equation.Substring(0, k);
                        }

                        if (!(j == equation.Length - 1))
                        {
                            int len = equation.Length - (j + 1);
                            temp2 = equation.Substring(j, len);
                        }
                        noSubtractionEquation = temp1 + subtractedResult + temp2;
                        equationArr = noSubtractionEquation.ToCharArray();
                        equation = new string(equationArr);
                    }
                }
            }
            return equation;

        }

        private String CleanUpBrackets(String equation)
        {
            char[] equationArr = equation.ToCharArray();
            for(int i = 0; i < equationArr.Length; i++)
            {
                String temp = equationArr[i].ToString();
                if (temp.Equals("(")){
                    
                    try
                    {
                        String prev = equationArr[i - 1].ToString();
                        double x = double.Parse(prev);
                        String temp1 = equation.Substring(0, i);
                        String temp2 = null;
                        if(i == equation.Length - 1)
                        {
                            temp2 = equationArr[i].ToString();
                        }
                        else
                        {
                            int len = equation.Length - i;
                            temp2 = equation.Substring(i, len);
                        }
                        String cleanEquation = temp1 + "x" + temp2;
                        equation = cleanEquation;
                        i = i + 2;
                    }catch(Exception e)
                    {

                    }
                }
                if (temp.Equals(")")){
                    
                    try 
                    {
                        String next = equationArr[i + 1].ToString();
                        double x = double.Parse(next);
                        String temp1 = equation.Substring(0, i+1);
                        String temp2 = null;
                        if (i + 1 == equation.Length - 1)
                        {
                            temp2 = equationArr[i + 1].ToString();
                        }
                        else
                        {
                            int len = equation.Length - (i+1);
                            temp2 = equation.Substring(i + 1, len);
                        }
                        String cleanEquation = temp1 + "x" + temp2;
                        equation = cleanEquation;
                        i++;
                    }catch(Exception e)
                    {

                    }
                    
                }
            }
            return equation;
        }

        private String reverse(String s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private String Divide(int i, String equation, char[] equationArr)
        {
            String firstNumberString = GetFirstNumber(i, equation, equationArr);
            String secondNumberString = GetSecondNumber(i, equation, equationArr);
            double firstNumber = double.Parse(firstNumberString);
            double secondNumber = double.Parse(secondNumberString);
            double result = firstNumber / secondNumber;
            String resultString = result.ToString();
            return resultString;
        }

        private String Multiply(int i, String equation, char[] equationArr)
        {
            String firstNumberString = GetFirstNumber(i, equation, equationArr);
            String secondNumberString = GetSecondNumber(i, equation, equationArr);
            double firstNumber = double.Parse(firstNumberString);
            double secondNumber = double.Parse(secondNumberString);
            double result = firstNumber * secondNumber;
            String resultString = result.ToString();
            return resultString;
        }

        private String Add(int i, String equation, char[] equationArr)
        {
            String firstNumberString = GetFirstNumber(i, equation, equationArr);
            String secondNumberString = GetSecondNumber(i, equation, equationArr);
            double firstNumber = double.Parse(firstNumberString);
            double secondNumber = double.Parse(secondNumberString);
            double result = firstNumber + secondNumber;
            String resultString = result.ToString();
            return resultString;
        }

        private String Subtract(int i, String equation, char[] equationArr)
        {
            String firstNumberString = GetFirstNumber(i, equation, equationArr);
            String secondNumberString = GetSecondNumber(i, equation, equationArr);
            if (firstNumberString.Equals(""))
            {
                firstNumberString = "0";
            }
            double firstNumber = double.Parse(firstNumberString);
            double secondNumber = double.Parse(secondNumberString);
            double result = firstNumber - secondNumber;
            String resultString = result.ToString();
            return resultString;
        }

        private String GetFirstNumber(int i, String equation, char[] equationArr)
        {
            String firstNumberString = "";
            int x = i - 1;
            Boolean isNumber = true;
            while (isNumber)
            {
                isNumber = false;
                try
                {
                    String temp = equationArr[x].ToString();
                    int k = int.Parse(temp);
                    firstNumberString = firstNumberString + temp;
                    if (!(x == 0)) { isNumber = true; }
                    
                    x--;
                }
                catch (Exception ex)
                {
                    String temp = equationArr[x].ToString();
                    if (temp.Equals("."))
                    {
                        firstNumberString = firstNumberString + temp;
                        if (!(x == 0)) { isNumber = true; }
                        x--;
                    }
                }
            }
            firstNumberString = reverse(firstNumberString);
            return firstNumberString;
        }
        private String GetSecondNumber(int i, String equation, char[] equationArr)
        {
            int x = i + 1;
            Boolean isNumber = true;
            String secondNumberString = "";
            while (isNumber)
            {
                isNumber = false;
                try
                {
                    String temp = equationArr[x].ToString();
                    int k = int.Parse(temp);
                    secondNumberString = secondNumberString + temp;
                    if(!(x == equation.Length - 1)) { isNumber = true; }
                    
                    x++;
                }
                catch (Exception ex)
                {
                    String temp = equationArr[x].ToString();
                    if (temp.Equals("."))
                    {
                        secondNumberString = secondNumberString + temp;
                        isNumber = true;
                        x++;
                    }
                }
            }
            return secondNumberString;
        }

        private int GetFirstIndex(int i, String equation, char[] equationArr)
        {
            String firstNumberString = "";
            int x = i;
            Boolean isNumber = true;
            while (isNumber && x > 0)
            {
                x--;
                isNumber = false;
                try
                {
                    String temp = equationArr[x].ToString();
                    int k = int.Parse(temp);
                    firstNumberString = firstNumberString + temp;
                    isNumber = true;
                    
                }
                catch (Exception ex)
                {
                    String temp = equationArr[x].ToString();
                    if (temp.Equals("."))
                    {
                        firstNumberString = firstNumberString + temp;
                        isNumber = true;
                        
                    }
                }
            }
            firstNumberString = reverse(firstNumberString);
            return x;
        }
        private int GetSecondIndex(int i, String equation, char[] equationArr)
        {
            int x = i + 1;
            Boolean isNumber = true;
            String secondNumberString = "";
            while (isNumber && x < equationArr.Length-1) 
            {
                x++;
                isNumber = false;
                try
                {
                    String temp = equationArr[x].ToString();
                    int k = int.Parse(temp);
                    secondNumberString = secondNumberString + temp;
                    isNumber = true;
                    
                }
                catch (Exception ex)
                {
                    String temp = equationArr[x].ToString();
                    if (temp.Equals("."))
                    {
                        secondNumberString = secondNumberString + temp;
                        isNumber = true;
                        
                    }
                }
            }
            return x;
        }
    }
}
