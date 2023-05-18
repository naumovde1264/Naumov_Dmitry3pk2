using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pz_4
{
      public class DTreeNode
      {
        public char Info { get; set; } 
            public int Key { get; set; }
            public DTreeNode Left { get; set; }
            public DTreeNode Right { get; set; }
            public DTreeNode() { }
            public DTreeNode(char info, int key)
            {
                Info = info; Key = key;
            }
            public DTreeNode(char info, int key, DTreeNode left, DTreeNode right)
            {
                Info = info; Key = key; Left = left; Right = right;
            }

      }
        class Program
        {
        private static void Main(string[] args)
        {
            Random random = new Random();
            DTreeNode root = null;
            
            for (int i = 0; i < 5; i++)//сумма значений информационных полей дерева
            {
                int key = random.Next(10, 1000);
                root = SearchTree.Insert_DNode(root, (char)('A' + i), key);
            }

            Console.WriteLine("сумма: " + SearchTree.Sum(root)); 

            Console.WriteLine("количество внутренних узлов дерева: " + SearchTree.CountInternalNodes(root));//количество внутренних узлов
 
            List<int> negativeValues = SearchTree.GetNegativeValues(root);//отрицательные значения информационных полей дерева
            Console.WriteLine("отрицательные значения информационных полей дерева:" + negativeValues.Count);
            foreach (var value in negativeValues)
            {
                Console.Write($"{value} ");
            }
        }
        internal class SearchTree
        {
            public static DTreeNode Insert_DNode(DTreeNode node, char info, int key)
            {
                if (node == null)
                    return new DTreeNode(info, key);
                else if (key < node.Key)
                    node.Left = Insert_DNode(node.Left, info, key);
                else
                    node.Right = Insert_DNode(node.Right, info, key);
                return node;
            }

            public static int Sum(DTreeNode node)
            {
                if (node == null)
                    return 0;
                return node.Key + Sum(node.Left) + Sum(node.Right);//сумма ключа текущего узла
            }
            public static int CountInternalNodes(DTreeNode node)
            {
                if (node == null)
                    return 0;
                else if (node.Left == null && node.Right == null)
                    return 0;
                else
                    return 1 + CountInternalNodes(node.Left) + CountInternalNodes(node.Right);
            }
            public static List<int> GetNegativeValues(DTreeNode node)
            {

                List<int> result = new List<int>(); 

                if (node == null)
                    return result;

                result.AddRange(GetNegativeValues(node.Left));
                result.AddRange(GetNegativeValues(node.Right));

                return result;
            }

        }
    }

}
    