using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordGame
{
    class Node
    {

        public string info;
        public Node link;
        public static string[] lst;
        public Node(string i)
        {

            info = i;
            link = null;
        }

    }

    class LinkedList
    {
        private Node start;

        public LinkedList()
        {
            start = null;
        }

        public void displayList()
        {
            countNodes();
            Node p;
            int i = 0;
            if (start == null)
            {
                Console.WriteLine("List Is Empty");
                return;
            }

            p = start;
            while (p != null)
            {
                Node.lst[i] = p.info;
                i++;
                p = p.link;

            }
            Console.WriteLine();

        }

        public int countNodes()
        {
            int n = 0;
            Node p = start;
            while (p != null)
            {
                n++;
                p = p.link;
            }

            Node.lst = new string[n];
            return n;
            
        }

        public bool search(string x)
        {
            int position = 1;
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                {
                    break;
                }
                position++;
                p = p.link;
            }

            if (p == null)
            {
                Console.WriteLine(x + "  not Found In the list");
                return false;
            }
            else
            {
                Console.WriteLine(x + "  Found Successfully");
                return true;
            }

        }

        public void insertInBiggning(string data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;

        }

        public void insertAtEnd(string data)
        {
            Node p;
            Node temp = new Node(data);
            if (start == null)
            {
                start = temp;
                return;
            }

            p = start;
            while (p.link != null)
            {

                p = p.link;
            }
            p.link = temp;

        }


        public void createList()
        {
            int i, n;
            string data;

            Console.WriteLine("Enter Number of Nodes : ");
            n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                return;
            }

            for (i = 0; i <= n; i++)
            {
                Console.WriteLine("Enter Element To be inserted");
                data = Console.ReadLine();
                insertAtEnd(data);
            }


        }
    }

}
