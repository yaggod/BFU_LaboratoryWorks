using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LaboratoryWork_1
{
    internal class ExpressionValidator
    {
        private static List<(char, char)> _bracketsPairs =>
            new List<(char, char)>
            {
                ('(', ')'),
                ('{', '}'),
                ('[', ']'),
            };


        public static bool IsValidExpression(string expression)
        {
            Stack<char> brackets = new Stack<char>();
            foreach(char character in expression) 
            {
                if(isBracket(character))
                {
                    if(isOpeningBracket(character))
                        brackets.Push(character);
                    if(isClosingBracket(character))
                    {
                        if (brackets.Count == 0 || !isBracketsPair(brackets.Pop(), character))
                            return false;
                    }
                }
            }
            return brackets.Count == 0;
        }


        private static bool isBracket(char character)
        {
            return isOpeningBracket(character) || isClosingBracket(character);
        }

        private static bool isOpeningBracket(char character)
        {
            return _bracketsPairs.Select(bracketPair => bracketPair.Item1).Contains(character);
        }

        private static bool isClosingBracket(char character)
        {
            return _bracketsPairs.Select(bracketPair => bracketPair.Item2).Contains(character);

        }

        private  static bool isBracketsPair(char firstChar, char secondChar)
        {
            try
            {
                return getOppositeBracket(firstChar) == secondChar;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private static char getOppositeBracket(char character)
        {
            foreach (var bracketsPaIr in _bracketsPairs)
            {
                if (bracketsPaIr.Item1 == character)
                    return bracketsPaIr.Item2;
                else if (bracketsPaIr.Item2 == character)
                    return bracketsPaIr.Item1;
            }
            throw new ArgumentException($"{nameof(character)} was not a bracket");
        }

    }
}
