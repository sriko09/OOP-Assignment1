using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOPassignment
{
    public class Menu
    {
        private Bag x = new Bag();

        public Menu() { }
        
        public void Run()
        {
            int n;
            do {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                { 
                    n = -1; 
                }
                switch(n)
                {
                    case 1:
                        insertElem();
                        break;
                    case 2:
                        removeElem();
                        break;
                    case 3:
                        print();
                        break;
                    case 4:
                        FrequencyOfElem();
                        break;
                    case 5:
                        onlyOneOccurence();
                        break;  
                }
            } while (n != 0);
        }

        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Insert an element into the bag");
            Console.WriteLine(" 2. - Remove an element");
            Console.WriteLine(" 3. - Print the bag");
            Console.WriteLine(" 4. - Get Frequency of one element of the bag");
            Console.WriteLine(" 5. - Count of elements which occur only once");
            Console.WriteLine();
            Console.Write("Choose: ");
        }

        private void insertElem()
        {
            try
            {
                Element e = new();
                Console.WriteLine("\nEnter a number to insert into the bag");
                e.input();
                
                x.insertElem(e);
                Console.WriteLine();
                Console.WriteLine(e.Elem + " was inserted into the bag");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\nNumbers inserted into the bag must be integers!");
            }
        }

        private void removeElem()
        {
            try
            {
                Console.Write("Enter an element to remove from the bag: ");
                int n = int.Parse(Console.ReadLine());
                x.removeElem(n);
                Console.WriteLine();
                Console.WriteLine(n + " was removed from the bag");
            }
            catch (Bag.NoElementInBag)
            {
                Console.WriteLine("\nThe bag does not contain any elements");
            }
            catch (Bag.NotPresentInBag)
            {
                Console.WriteLine("\nThe given number is not an element of the bag hence it cannot be removed");
            }
        }

        private void print()
        {
            try
            {
                Console.WriteLine();
                x.print();
            }
            catch (Bag.NoElementInBag)
            {
                Console.WriteLine("\nThere are no elements present in the bag");
            }
            
        }

        
        private void FrequencyOfElem()
        {
            try
            {
                Console.Write("Enter an element to get the frequency of its occurence from the bag: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("The frequency of " + n + " is " + x.FrequencyOfElem(n));
            }
            catch (Bag.NotPresentInBag)
            {
                Console.WriteLine("\nThe element is not present in the bag");
            }
            catch (Bag.NoElementInBag)
            {
                Console.WriteLine("\nThere are no elements in the bag");
            }
            
        }

        private void onlyOneOccurence()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("The number of elements that occur only once in the bag are " + x.onlyOneOccurence()); 
            }
            catch (Bag.NoElementInBag)
            {
                Console.WriteLine("\nThere are no elements present in the bag");
            }
            catch (Bag.NoSingleElementInBag)
            {
                Console.WriteLine("\nThere are no elements in the bag that occur only once");
            }
            
        }
        
    }

}
