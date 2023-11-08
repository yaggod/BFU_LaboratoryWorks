using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public static class IntegerTreeParser
    {
        public static BinaryTreeNode<int> GetTreeFromString(string expression)
        {
            expression = expression.Replace(" ", "");
            if (expression.Length == 0)
                return null;

            int rootElement = 0;
            int substringStartIndex = 0;
            foreach(char c in expression)
            {
                substringStartIndex++;
                if( c >= '0' && c <= '9')
                {
                    rootElement *= 10;
                    rootElement += c % '0';
                }
                else
                {
                    break;
                }
            }
            BinaryTreeNode<int> treeRoot = new BinaryTreeNode<int>(rootElement);

            if (substringStartIndex < expression.Length)
            {
                int separatorIndex = GetSeparatorIndex(expression);

                string leftSubstring = expression.Substring(substringStartIndex, separatorIndex - substringStartIndex);
                string rightSubstring = expression.Substring(separatorIndex + 1, expression.Length - 2 - separatorIndex);

                treeRoot.Left = GetTreeFromString(leftSubstring);
                treeRoot.Right = GetTreeFromString(rightSubstring);
            }

            return treeRoot;
        }


        private static int GetSeparatorIndex(string expression)
        {
            int openedBracketsCount = 0;
            for(int i  = 0; i < expression.Length;i++)
            {
                char currentCharacter = expression[i];

                if (currentCharacter == '(')
                    openedBracketsCount++;
                else if (currentCharacter == ')')
                {
                    openedBracketsCount--;
                    if (openedBracketsCount < 0)
                        throw new FormatException(nameof(expression) + "was not in a correct format");
                }
                else if (currentCharacter == ',' && openedBracketsCount == 1)
                    return i;
            }

            throw new FormatException(nameof(expression) + "was not in a correct format");
        }
    }
}
