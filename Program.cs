using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singly_linked_list
{
    //each node consist of the information part and lik to the next mode

    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class list
    {
        Node START;

        public list()
        {
            START = null;
        }
        public void addNote() //add a node in the list
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            nim= Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of student : ");
            nm= Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;

            //if the note to be inserted is the first node
            if((START == null ) && (nim == START.rollNumber))
            {
                if ((START != null) && (nim== START.rollNumber))
                {    
                        Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                        return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //locate the position of the new node in the list
            Node previous, current = START;
            previous= START;
            current = START;

            while ((current!= null)&&(nim>=current.rollNumber))
            {
                if(nim==current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll Numbers not Allowed \n");
                    return;
                }
                previous=current;
                current = current.next;
            }
            /*once the above for loop is executed,prev and current are positoned in such a manner that the position for the new node*/
            newnode.next = current;
            previous.next = newnode;
        }

        public void traverse()
        {
            if(listEmpty())
                Console.WriteLine("\nList is empty.\n");
            else
            {
                Console.WriteLine("\n The record in the list area : ");
                Node currentNode;
                for(currentNode= START; currentNode!=null; currentNode=currentNode.next)

                Console.Write(currentNode.rollNumber + " " + currentNode.name+"\n");

                Console.WriteLine();
            }
        }
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check if the spesified node is present in the list or not
            if
                (Search (nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = current.next;
            return true;
        }

        public bool Search (int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while((current != null) && (nim != current.rollNumber))
            {
              previous= current;
              current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;   
        }
    }
    class program
    {
        //check wheter the specified node is present int the list or not

        static void Main(string[]args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. add a record to the list");
                    Console.WriteLine("2. delete a record from the list");
                    Console.WriteLine("3. view all the records in the list");
                    Console.WriteLine("4. Search the records in the list");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\n Enter your choice (1-5)");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch(ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n List is Empty");
                                    break;
                                }
                                Console.WriteLine("\n List is Empty");
                                break ;
                            }
                            Console.Write("\nEnter the roll number of"+
                                "the students whose record is to be deleted :");
                            int nim=Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            if(obj.delNode(nim)== false)
                                Console.WriteLine("\n Record not found");
                            else
                                Console.WriteLine("Record with roll number"+ nim+"deleted");    
                    }
                    break;
                 case '3':
                    {
                        obj.traverse();
                    }
                    break;
                case '4':
                    {
                        if(obj.listEmpty()== true)
                        {
                            Console.WriteLine("\n list is empty");
                            break;
                        }
                        Node previous, current;
                        previous = current = null;
                        Console.Write("\nEnter the roll number of the+" +
                            "students whose records is to be searched");
                        int num =Convert.ToInt32(Console.ReadLine());
                        if (obj.Search(num,ref previous,ref current)== false)
                            Console.WriteLine('\nrecord not found');
                        else
                        {
                            Console.WriteLine("\n Record not found");
                            Console.WriteLine('\n Roll number'+ current.rollNumber);
                            Console.WriteLine('\n Name' + current.name);
                        }
                    }
                    break ;
                case '5':
                        return;
                    default:
                        {
                        Console.WriteLine()
                    }
                }
            }
        }
    }

}
