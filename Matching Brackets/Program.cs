using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DoWork d = new DoWork();
            d.StartProgram();
        }
    }

    class DoWork
    {
        private const string Brackets = "(){}[]<>";
        private const string BracketsBegan = "({[<";
        private int plus;
        private int countOfTests;
        private string input;
        private List<char> testList;
        private int status, indexEnd;

        public void StartProgram()
        {
            int.TryParse(Console.ReadLine(), out countOfTests);

            for (int i = 0; i < countOfTests; i++)
            {
                input = Console.ReadLine();
                deleteOrAddToList();
                status = (testList.Count % 2 == 0) ? checkTestList() : 0;
                Console.Write("{0} ", status);
            }
        }

        void deleteOrAddToList()
        {
        	testList = new List<char>();
            foreach (var c in input)
            {
                if (Brackets.Contains(c.ToString()))
                    testList.Add(c);
            }
        }

        int checkTestList()
        {
            int testingNum = 0;

        	for(int i = 0; i < testList.Count; i++)
        	{
        		if( !BracketsBegan.Contains( testList[i].ToString() ) )
        		   continue;
        		plus = testList[i].Equals('(') ? 1 : 2;
        		char temp = Convert.ToChar(Convert.ToUInt32(testList[i]) + plus);
        		indexEnd = testList.IndexOf(temp, i);
                testingNum = i + 1;
                while ( isThereBracketInBracket(ref testingNum, testList[i]) )
                {
                    indexEnd = testList.IndexOf(temp, indexEnd+1);
                    testingNum++;
                }
        		if ( (indexEnd == -1) || (indexEnd - i + 1) % 2 != 0) 
        		{
        			return 0;
        		}
        	}
            
            return 1;
        }

        private bool isThereBracketInBracket(ref int testingNum, char temp)
        {
            for (; testingNum < indexEnd; testingNum++)
            {
                if (testList[testingNum].Equals(temp))
                {
                    return true;
                }
            }

            return false;
        }
    }
}