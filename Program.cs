using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;

namespace trees
{
  class Program
  {
    static void Main(string[] args)
    {
      
    }
  }

  public class LruCache
  {
    public Dictionary<string, string> items = new Dictionary<string, string>();

    public LruCache()
    {
        
        dfsfsfsfsf 
    }
  }

  public class TwoSum
  {
    public static void Run()
    {
      int[] result = TwoSum.UsingHash(new int[] { 2, 7, 11, 15 }, 9);
      Console.WriteLine(TwoSum.Print(result));
    }

    public static string Print(int[] array)
    {
      return array.Select(i => $"{i}").Aggregate((s1, s2) => $"{s1}, {s2}");
    }

    public static int[] UsingHash(int[] nums, int target)
    {
      Dictionary<int, int> complements = new Dictionary<int, int>();

      for (int i = 0; i < nums.Length; i++)
      {
        int value = nums[i];
        int complement = target - value;

        if (complements.ContainsKey(complement))
          return new int[] { complements[complement], i };
        else
          complements[value] = i;
      }

      return null;
    }

    public static int[] BruteForce(int[] nums, int target)
    {
      for (int i = 0; i < nums.Length; i++)
        for (int j = 1; j < nums.Length; j++)
        {
          if (i == j) continue;
          if (nums[i] + nums[j] == target)
            return new int[] { i, j };
        }
        
      return null;
    }

  }

  public class ProductOfEveryOtherNumber
  {
    public static void Test()
    {
      int[] input1 = new int[] { 2, 4, 6 };
      int[] input2 = new int[] { 2, 4, 3, 0 };
      int[] input3 = new int[] { 2, 4, 0, 0 };

      Console.WriteLine(ProductOfEveryOtherNumber.CalculateAndPrint(input1));
      Console.WriteLine(ProductOfEveryOtherNumber.CalculateAndPrint(input2));
      Console.WriteLine(ProductOfEveryOtherNumber.CalculateAndPrint(input3));
    }

    public static string CalculateAndPrint(int[] input)
    {
      int[] result = Calculate(input);

      string resultStr = "[";

      foreach (int number in result)
        resultStr += $"{number}, ";

      return resultStr.Substring(0, resultStr.Length - 2) + "]";
    }

    public static int[] Calculate(int[] input)
    {
      bool hasZero = false;
      int productOfAll = 1;

      foreach (int number in input)
      {
        if (hasZero && number == 0) return new int[input.Length];
        else if (number == 0) hasZero = true;
        else productOfAll *= number;
      }

      int[] productOfEveryOther = new int[input.Length];

      for (int i = 0; i < input.Length; i++)
      {
        if (hasZero)
          productOfEveryOther[i] = input[i] == 0 ? productOfAll : 0;
        else
          productOfEveryOther[i] = productOfAll / input[i];
      }

      return productOfEveryOther;
    }
  }

  public class Matcher
  {
    public static bool Match(string pattern)
    {
      Stack<char> stack = new Stack<char>();

      foreach (char c in pattern)
      {
        if (c == '(') stack.Push(c);
        else // c == ')'
        {
          if (stack.Count == 0) return false;
          stack.Pop();
        }
      }

      return stack.Count == 0;
    }
  }

  public class CartesianProduct
  {
      public IList<string> LetterCombinations(string digits) {
        if (digits == string.Empty) return new List<string>();
        else if (digits.Length == 1) return translateDigitToLetters(digits[0]);
        
        List<string[]> allLetters = getAllLetters(digits);
        
        return Cartesian(allLetters);
    }
    
    public static List<string> Cartesian(List<string[]> sets)
    {
      var product = CartesianPair(sets[0], sets[1]);
      if (sets.Count == 2) return product;
      else
      {
        List<string[]> arraysExceptOneAndTwo = sets.Skip(2).Prepend(product.ToArray()).ToList();
        return Cartesian(arraysExceptOneAndTwo);
      }
    }
    
    public static List<string> CartesianPair(IEnumerable<string> array1, IEnumerable<string> array2)
    {
      List<string> product = new List<string>();

      foreach (string s1 in array1)
        foreach (string s2 in array2)
          product.Add($"{s1}{s2}");

      return product;
    }
    
    public List<string[]> getAllLetters(string digits)
    {
        return digits.Select(d => translateDigitToLetters(d)).ToList();
    }
    
    public string[] translateDigitToLetters(char digit)
    {
        switch(digit)
        {
            case '2': return new string[] { "a", "b", "c" };
            case '3': return new string[] { "d", "e", "f" };
            case '4': return new string[] { "g", "h", "i" };
            case '5': return new string[] { "j", "k", "l" };
            case '6': return new string[] { "m", "n", "o" };
            case '7': return new string[] { "p", "q", "r", "s" };
            case '8': return new string[] { "t", "u", "v" };
            case '9': return new string[] { "w", "x", "y", "z" };
            default: return null;
        }
    }

    public static void Print(List<string> array)
    {
      foreach(string s in array)
      {
        Console.Write($"{s} - ");
      }
      Console.WriteLine();
    }
  }

  public class ListNode
    {
      public static void RunMerge()
      {
        ListNode list1 = new ListNode { Value = 1, Next = new ListNode { Value = 3, Next = new ListNode { Value = 5, Next = new ListNode { Value = 10 } } } };
        ListNode list2 = new ListNode { Value = 2, Next = new ListNode { Value = 4, Next = new ListNode { Value = 6, Next = new ListNode { Value = 11, Next = new ListNode { Value = 6 } } } } };
        ListNode list3 = new ListNode { Value = 1, Next = new ListNode { Value = 2, Next = new ListNode { Value = 7, Next = new ListNode { Value = 8, Next = new ListNode { Value = 4 } } } } };

        ListNode mergedList = Merge(list1, list2, list3 );

        mergedList.Print();

        Console.WriteLine("Press any key to finish...");
        Console.ReadKey();
      }

      public static ListNode Merge(params ListNode[] lists)
      {
        SimplePriorityQueue<ListNode, int> priorityQueue = new SimplePriorityQueue<ListNode, int>();

        foreach (ListNode list in lists)
        {
          ListNode current = list;

          while (current != null)
          {
            priorityQueue.Enqueue(current, current.Value);
            current = current.Next;
          }
        }

        ListNode mergedListHead = priorityQueue.Dequeue();
        ListNode mergedListTail = mergedListHead;
        
        while(priorityQueue.Count > 0)
        {
          mergedListTail.Next = priorityQueue.Dequeue();
          mergedListTail = mergedListTail.Next;
        }
        mergedListTail.Next = null;

        return mergedListHead;
      }

      public int Value { get; set; }
      public ListNode Next { get; set; }

      public void Print()
      {
        ListNode current = this;

        while (current != null)
        {
          Console.Write($"{current.Value} - ");
          current = current.Next;
        }
        Console.WriteLine();
      }
    }

  public class BinaryTree
  {
    public Tree Root { get; set; }

    public static void RunAddAndDelete()
    {
      BinaryTree b = new BinaryTree();

      b.Add(10);
      b.Add(5);
      b.Add(3);
      b.Add(7);
      b.Add(15);
      b.Add(12);
      b.Add(18);
      b.Add(8);
      b.Add(16);
      Console.WriteLine($"By Level: {b.Root.PrintByLevel()}");
      
      b.Delete(16);
      Console.WriteLine($"By Level: {b.Root.PrintByLevel()}");

      b.Delete(7);
      Console.WriteLine($"By Level: {b.Root.PrintByLevel()}");

      b.Delete(10);
      Console.WriteLine($"By Level: {b.Root.PrintByLevel()}");
    }

    public void Delete(int value)
    {
      this.Root = DeleteRecursive(value, this.Root);
    }

    private Tree DeleteRecursive(int value, Tree node)
    {
      if (value > node.Value) node.Right = DeleteRecursive(value, node.Right);
      else if (value < node.Value) node.Left = DeleteRecursive(value, node.Left);
      else // value == node.Value
      {
        if (node.Left == null && node.Right == null) return null;
        else if (node.Left == null && node.Right != null) return node.Right;
        else if (node.Left != null && node.Right == null) return node.Left;
        else
        {
          int smallestSucessorValue = FindMinNodeValue(node.Right);
          node.Value = smallestSucessorValue;
          node.Right = DeleteRecursive(node.Value, node.Right);
        }
      }

      return node;
    }

    private int FindMinNodeValue(Tree node)
    {
        if (node.Left == null) return node.Value;
        else return FindMinNodeValue(node.Left);
    }

        public void Add(int value)
    {
      if (this.Root == null)
        this.Root = new Tree { Value = value };
      else
        AddRecursive(value, this.Root);
    }

    private void AddRecursive(int value, Tree node)
    {
      if (value >= node.Value)
      {
        if (node.Right == null)
          node.Right = new Tree { Value = value };
        else
          AddRecursive(value, node.Right);
      }
      else
      {
        if (node.Left == null)
          node.Left = new Tree { Value = value };
        else
          AddRecursive(value, node.Left);
      }
    }
  }

  public class DuplicatesFinder
  {
    public static void Print()
    {
      int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      int[] array2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 };
      int[] array3 = new int[] { 1, 2, 3, 4, 5, 1, 7, 8, 8 };
      int[] array4 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };

      Console.WriteLine($"array1: {HasDuplicatesWithHash(array1)}");
      Console.WriteLine($"array2: {HasDuplicatesWithHash(array2)}");
      Console.WriteLine($"array2: {HasDuplicatesWithHash(array3)}");
      Console.WriteLine($"array2: {HasDuplicatesWithHash(array4)}");
    }

    static bool HasDuplicatesWithBoolArray(int[] array)
    {
      bool[] duplicates = new bool[array.Length + 1];

      for (int i = 0; i < array.Length; i++)
      {
        int currentElement = array[i];

        if (duplicates[currentElement])
          return true;
        else
          duplicates[currentElement] = true;
      }

      return false;
    }

    static bool HasDuplicatesWithHash(int[] array)
    {
      Dictionary<int, bool> duplicates = new Dictionary<int, bool>();

      for (int i = 0; i < array.Length; i++)
      {
        int currentElement = array[i];

        if (duplicates.ContainsKey(currentElement))
          return true;
        else
          duplicates[currentElement] = true;
      }

      return false;
    }
  }

  public class Tree
  {
    public int Value { get; set; }
    public Tree Left { get; set; }
    public Tree Right { get; set; }

    public static void Print()
    {
      Tree root = Tree.BuildSampleTree();
      Console.WriteLine($"In order: {root.PrintInOrder()}");
      Console.WriteLine($"In reverse: {root.PrintInReverseOrder()}");
      Console.WriteLine($"By level: {root.PrintByLevel()}");
    }

    public string PrintInOrder()
    {
      string print = PrintInOrderRecursive(this);
      return CleanLastDash(print);
    }

    public string PrintByLevel()
    {
      string print = "\n";

      Queue<Tree> queue = new Queue<Tree>();
      queue.Enqueue(this);

      while(queue.Count > 0)
      {
        int nodeCountInLevel = queue.Count;

        while(nodeCountInLevel > 0)
        {
          Tree leaf = queue.Dequeue();
          print += leaf.Value + " - ";

          if (leaf.Left != null) queue.Enqueue(leaf.Left);
          if (leaf.Right != null) queue.Enqueue(leaf.Right);
          nodeCountInLevel--;
        }
        print = CleanLastDash(print) + "\n";
      }

      return print.Substring(0, print.Length - 1);
    }

    public string PrintInReverseOrder()
    {
      string print = PrintInReverseOrderRecursive(this);
      return CleanLastDash(print);
    }

    private string CleanLastDash(string s)
    {
      return s.Substring(0, s.Length - 3);
    }

    private static string PrintInReverseOrderRecursive(Tree tree)
    {
      if (tree == null) return string.Empty;

      string treePrint = string.Empty;

      if (tree.Right != null) treePrint += PrintInReverseOrderRecursive(tree.Right);
      treePrint += tree.Value.ToString() + " - ";
      if (tree.Left != null) treePrint += PrintInReverseOrderRecursive(tree.Left);
      
      return treePrint;
    }

    private static string PrintInOrderRecursive(Tree tree)
    {
      if (tree == null) return string.Empty;

      string treePrint = string.Empty;

      if (tree.Left != null) treePrint += PrintInOrderRecursive(tree.Left);
      treePrint += tree.Value.ToString() + " - ";
      if (tree.Right != null) treePrint += PrintInOrderRecursive(tree.Right);
      
      return treePrint;
    }

    public static Tree BuildSampleTree()
    {
      Tree root = new Tree
      {
        Value = 5,
        Left = new Tree
        {
          Value = 3,
          Left = new Tree
          {
            Value = 2
          },
          Right = new Tree
          {
            Value = 4
          }
        },
        Right = new Tree
        {
          Value = 8,
          Left = new Tree
          {
            Value = 6,
            Right = new Tree
            {
              Value = 7
            }
          },
          Right = new Tree
          {
            Value = 13,
            Left = new Tree
            {
              Value = 10,
              Right = new Tree
              {
                Value = 12,
                Left = new Tree
                {
                  Value = 11
                }
              }
            }
          }
        }
      };

      return root;
    }
  }
}