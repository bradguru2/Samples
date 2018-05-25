using System;
using System.Collections.Generic;

namespace SearchBinaryTree
{
    /* Let's assume that items are inserted in a straight-forward order.  
       Otherwise, what's the benefit of the search tree?  We are finding a 
       search pattern that works for a particular type of tree described below.
                                root
                         left < / \ > right
        Items that are less than root go left.
        Items that are greater than root go right.
     */

     class Node 
     {
        internal Node(int val){
            value = val;
        }

        internal int value;
        internal Node left;
        internal Node right;
     }

    class Program
    {
        //Gets the right-most element. Pretty straight-forward
        static int FindMaxValue(Node head)
        {
            int answer = int.MinValue;

            while (head != null)
            {
                answer = head.value;
                head = head.right;
            }

            return answer;
        }

        //Much different problem than above using DFS
        //However, solvable because we know the order
        static int FindKthFromMax(Node head, int k)
        {   
            int answer = int.MinValue;
            Stack<Node> nodes = new Stack<Node>();

            if(head!=null && k >= 0){
                //First DFS tree
                while(head!=null){
                    nodes.Push(head);
                    head = head.right;
                }

                bool isRight = false;

                while(k >= 0 && nodes.Count > 0){
                    head = nodes.Pop(); 

                    if(--k >= 0){
                        if(isRight && head.left != null){
                            nodes.Push(head.left);
                        }
                        else if(!isRight && head.right!=null){
                            nodes.Push(head.right);
                        }
                        
                        isRight = !isRight;
                    }
                }

                answer = head.value;
            }
            
            return answer;

        }

        static void Main(string[] args)
        {
            Node head = new Node(4);
            head.left = new Node(2);
            head.left.right = new Node(3);
            head.left.left = new Node(1);

            head.right = new Node(6);
            head.right.left = new Node(5);
            head.right.right = new Node(7);

            Console.WriteLine("MaxValue is {0}", FindMaxValue(head));

            Console.WriteLine("{0} from MaxValue is {1}",0, FindKthFromMax(head, 0));
            Console.WriteLine("{0} from MaxValue is {1}",1, FindKthFromMax(head, 1));
            Console.WriteLine("{0} from MaxValue is {1}",2, FindKthFromMax(head, 2));
            Console.WriteLine("{0} from MaxValue is {1}",3, FindKthFromMax(head, 3));
            Console.WriteLine("{0} from MaxValue is {1}",4, FindKthFromMax(head, 4));
            Console.WriteLine("{0} from MaxValue is {1}",5, FindKthFromMax(head, 5));
            Console.WriteLine("{0} from MaxValue is {1}",6, FindKthFromMax(head, 6));
        }
    }
}
