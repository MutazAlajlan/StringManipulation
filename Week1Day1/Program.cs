using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace Week1Day1
{
    class Program
    {
        static bool match(string source)
        {
            int countOpen = 0;
            int countClosed = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == '{')
                {
                    countOpen++;

                }
                else if (source[i] == '}' && countOpen < countClosed)
                {
                    return false;
                }
                else if (source[i] == '}' && countOpen > countClosed)
                {
                    countClosed++;
                }
                else
                {
                    return false;
                }

            }
            if (countOpen == countClosed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static bool match2(string input, char start = '{', char end = '}')
        {
            int stack = 0;
            foreach (var ch in input)
            {
                if (ch == '{')
                {
                    stack++;
                }
                else if (ch == '}')
                {
                    stack--;
                }
                if (stack < 0)
                {
                    return false;
                }
            }
            return stack == 0;
        }

        class MatchOutput
        {
            string input = null;
            char start = ' ';
            char end = ' ';
            public int LastPos = 0;
            public bool isFound = false;

            public MatchOutput(string inp, char star, char endOfStart)
            {
                input = inp;
                start = star;
                end = endOfStart;
            }
        }
        static MatchOutput MatchObject(string input, char start, char end)
        {
            MatchOutput matchObj = new MatchOutput(input, start, end);

            int stack = 0;
            int count = 0;
            foreach (var ch in input)
            {
                if (ch == start)
                {
                    stack++;
                    count++;
                }
                else if (ch == end)
                {
                    stack--;
                }
                if (stack < 0)
                {
                    matchObj.isFound = false;
                    return matchObj;
                }
            }

            matchObj.LastPos = count;
            matchObj.isFound = true;
            return matchObj;
        }

        class Searchable
        {
            string value;
            public Searchable(string val)
            {
                this.value = val;
            }

            public int numOfwords()
            {
                string[] wordsArray = value.Split(' ');
                //int wordsCount = wordsArray.Length + 1;
                return wordsArray.Length + 1;
            }
            public int numOfChars()
            {
                return value.Length;
            }
            public int numOfXWord(string word)
            {
                int count = 0;
                Regex regEx = new Regex(word);
                foreach (Match matches in regEx.Matches(value))
                {
                    count++;
                }
                return count;
            }
            public int numOfXChar(char c)
            {
                int count = value.Split(c).Length - 1;
                return count;

            }
            public string mostFrequentWord() { return null; } //TODO
            public int lasIndexOf(char c)
            {

                int count = value.LastIndexOf(c);

                return count;
            }
            public static void SwapWords(string input) //interchange the even words.
            {

                
                string word = "";
                int i = 0;
                ArrayList wordsList = new ArrayList();
                while (input[i] == ' ' && i < input.Length)
                i++;
                
                while (i < input.Length)
                {
                    if (Char.IsLetterOrDigit(input[i]))
                    {
                        word += input[i];
                        ++i;
                        while (i < input.Length && Char.IsLetterOrDigit(input[i]))
                        {
                            word += input[i];
                            ++i;
                        }

                        if (word.Length > 1) wordsList.Add(word);

                        word = "";
                    }
                    ++i;
                }

                int swapIndex = 0, swapIndex2 = 1;


                while (swapIndex < wordsList.Count && swapIndex2 < wordsList.Count)
                {
                    string tempWord = (string)wordsList[swapIndex];
                    wordsList[swapIndex] = wordsList[swapIndex2];
                    wordsList[swapIndex2] = tempWord;

                    swapIndex += 2;
                    swapIndex2 += 2;

                }

                foreach (string wrd in wordsList)
                {

                    Console.Write(wrd + " ");
                }

                Console.WriteLine();

            }



            static void Main(string[] args)
            {
                string value = "{{}{{{iwufwieuhg}}}{";
                string valueMatch = "{{}{}}";
                string vv = "{}}{";
                string v = "}{{}";
                string tre = "{}{}";
                Console.WriteLine(match(value));
                Console.WriteLine(match(valueMatch));
                Console.WriteLine(match(vv));
                Console.WriteLine(match(v));
                Console.WriteLine(match(tre));

                MatchOutput m = new MatchOutput(value, '{', '}');
                SwapWords("Hello and welcome here");

            }
        }
    }
}
