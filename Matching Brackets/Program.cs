﻿using System;
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
        private int countOfTests;
        private string input;
        private List <char> testList;

        public void StartProgram()
        {
            int.TryParse(Console.ReadLine(), out countOfTests);

            for (int i = 0; i < countOfTests; i++)
            {
                input = Console.ReadLine();
                deleteOrAddToList();
                Console.Write("{0} ",checkTestList());
            }
        }

        void deleteOrAddToList()
        {
            foreach (var c in input)
            {
                if(Brackets.Contains(c.ToString()))
                    testList.Add(c);
            }
        }

        int checkTestList()
        {
            return 0;
        }
}