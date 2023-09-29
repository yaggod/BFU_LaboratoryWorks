using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_2
{
    internal class ExpressionEvaluator
    {
        private const char PlusOperator = '+';
        private static readonly (char, char) _brackets = ('(', ')');
        private static readonly Dictionary<char, int> _operationsPriorities = new()
        {
            ['*'] = 2,
            ['/'] = 2,
            ['+'] = 1,
            ['-'] = 1,
        };


        private Stack<char> _operators = new();
        private Stack<float> _numbers = new();
        public float Result
        {
            get
            {
                if (_numbers.Count > 1)
                    throw new InvalidOperationException("Input string was not correct");
                return _numbers.First();
            }
            
        }

        public ExpressionEvaluator(string expression)
        {
            HandleStringExpression(expression);

        }

        private void HandleStringExpression(string expression)
        {
            bool isStartOfSubexpression = true;
            string parsedNumberString = "";
            
            foreach(char character in expression)
            {
                if(char.IsDigit(character) || (isStartOfSubexpression && character == '-'))
                {
                    parsedNumberString += character;
                    isStartOfSubexpression = false;
                    continue;
                }
                else if(parsedNumberString.Length > 0)
                {
                    _numbers.Push(float.Parse(parsedNumberString));
                    parsedNumberString = string.Empty;
                }
                if(IsOperatorOrBracket(character)) 
                {
                    _operators.Push(character);
                    if (IsOpeningBracket(character))
                        isStartOfSubexpression = true;
                    if (IsClosingBracket(character))
                        HandleSubexpression();
                }             
                

            }
            if (expression.Last() == '=')
                HandleSubexpression();
            else
                throw new FormatException();

        }
        private void HandleSubexpression()
        {
            Stack<char> localOperators = new();
            Stack<float> localNumbers = new();
            if(_operators.Count > 0 && IsClosingBracket(_operators.Peek()))
            {
                char operatorToAdd = _operators.Pop();
                

                while(!IsOpeningBracket(operatorToAdd = _operators.Pop()))
                {
                    localOperators.Push(operatorToAdd);
                    localNumbers.Push(_numbers.Pop());
                }
                localNumbers.Push(_numbers.Pop());

            }
            else
            {
                localNumbers = new(_numbers);
                localOperators = new(_operators);

                _numbers = new();
                _operators = new();
            }

            float subExpressionValue = HandleSubexpression(localOperators, localNumbers);
            _numbers.Push(subExpressionValue);

        }

        private static float HandleSubexpression(Stack<char> localOperators, Stack<float> localNumbers)
        {
            Stack<char> popedOperators = new();
            Stack<float> popedNumbers = new();

            int lastOperatorPriority = 0;

            while (popedOperators.Count + localOperators.Count > 0 )
            {
                while(localOperators.Count > 0)
                {
                    char newOperator = localOperators.Pop();
                    int newOperatorPriority = GetOperationPriority(newOperator);
                    if (lastOperatorPriority >= newOperatorPriority)
                    {
                        float newNumberValue = GetSimpleOperationResult(popedOperators.Pop(), popedNumbers.Pop(), localNumbers.Pop());
                        localNumbers.Push(newNumberValue);
                    }

                    popedOperators.Push(newOperator);
                    popedNumbers.Push(localNumbers.Pop());
                    if (localOperators.Count == 0 && newOperatorPriority > lastOperatorPriority)
                    {
                        float newNumberValue = GetSimpleOperationResult(popedOperators.Pop(), popedNumbers.Pop(), localNumbers.Pop());
                        localNumbers.Push(newNumberValue);
                    }

                    lastOperatorPriority = newOperatorPriority;

                }
                
                while (popedOperators.Count > 0)
                {
                    localOperators.Push(popedOperators.Pop());
                    localNumbers.Push(popedNumbers.Pop());
                    lastOperatorPriority = 0;
                }

            }

            return localNumbers.First();
        }

        private static float GetSimpleOperationResult(char operation, float leftNumber, float rightNumber)
        {
            switch (operation)
            {
                case '+':
                    return leftNumber + rightNumber;
                case '-':
                    return leftNumber - rightNumber;
                case '*':
                    return leftNumber * rightNumber;
                case '/':
                    if (rightNumber == 0)
                        throw new DivideByZeroException();
                    return leftNumber / rightNumber;

                default:
                    throw new InvalidOperationException($"{nameof(operation)} was not correct operation");
            }
        }
        private static bool IsOperatorOrBracket(char character)
        {
            return IsOperator(character) || IsBracket(character);
        }

        private static bool IsBracket(char character)
        {
            return IsOpeningBracket(character) || IsClosingBracket(character);  
        }

        private static bool IsOpeningBracket(char character)
        {
            return _brackets.Item1 == character;
        }

        private static bool IsClosingBracket(char character)
        {
            return _brackets.Item2 == character;
        }

        private static bool IsOperator(char character)
        {
            return _operationsPriorities.Keys.Contains(character);
        }

        private static int GetOperationPriority(char character)
        {
            if (IsOperator(character))
                return _operationsPriorities[character];

            return -1;
        }
    }
}
