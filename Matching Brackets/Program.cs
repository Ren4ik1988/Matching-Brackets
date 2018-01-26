using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    class DoWork
    {
        private const string Brackets = "(){}[]<>";
        ptivate const string BracketsBegan = "({[<";
        private int plus;
        private int countOfTests;
        private string input;
        private List<char> testList;
        private List<char> tempTestList;
        ptivate int status, indexEnd;

        public void StartProgram()
        {
            int.TryParse(Console.ReadLine(), out countOfTests);

            for (int i = 0; i < countOfTests; i++)
            {
                input = Console.ReadLine();
                deleteOrAddToList();
                status = (testList % 2 == 0) ? checkTestList() : 0;
                Console.Write("{0} ", status);
            }
        }

        void deleteOrAddToList()
        {
        	testList = new List<char>();
        	tempTestList = new List<char>();
            foreach (var c in input)
            {
                if (Brackets.Contains(c.ToString()))
                    testList.Add(c);
            }
        }

        int checkTestList()
        {
        	for(int i = 0; i < testList.Count; i++)
        	{
        		if( !BracketsBegan.Contains( testList[i].ToString() ) )
        		   continue;
        		plus = testList[i].Equals('(') ? 1 : 2;
        		char temp = Convert.ToChar(Convert.ToUInt32(testList[0]) + plus);
        		indexEnd = testList.IndexOf(temp, i);
        		if (indexEnd == -1) && ( (indexEnd - i + 1) % 2 != 0) )
        		{
        			return 0;
        		}
        	}
            
            return 1;
        }
    }
}