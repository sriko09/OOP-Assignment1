using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOPassignment
{
    public class Element
    {

        public int Elem;
        public int Frequency;

        public Element() { }
        public Element(int elem)
        {
            Elem = elem;
            Frequency = 1;
        }

        public override string ToString()
        {
            return "(" + Elem + "," + Frequency + ")";
        }

        public void input()
        {
            Console.Write("Element: ");
            Elem = int.Parse(Console.ReadLine());
            Frequency = 1;
        }

        public bool Equals(int num)
        {
              return this.Elem == num;
        }
    }

    public class Bag
    {
        public class NoElementInBag : Exception { };
        public class NotPresentInBag : Exception { };
        public class NoSingleElementInBag : Exception { };

        #region Attributes
        private readonly List<Element> x = new();
        #endregion

        public int length
        {
            get { return x.Count; }
        }


        public bool ContainsElement(int num)
        {
            for (int i = 0; i < length; i++)
            {
                if (x[i].Elem.Equals(num))
                {
                    return true;
                }
            }
            return false;
        }

        public void insertElem(Element e)
        {
            if (!ContainsElement(e.Elem))
            {
                x.Add(e);
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (e.Elem.Equals(x[i].Elem))
                    {
                        x[i].Frequency += 1;
                    }
                }
            }
        }

        public void removeElem(int num)
        {
            if (length == 0) 
            { 
                throw new NoElementInBag(); 
            }

            for (int i = 0; i < length; i++)
            {
                if (x[i].Elem.Equals(num))
                {
                    if (x[i].Frequency > 1)
                    {
                        x[i].Frequency -= 1;
                        return;
                    }
                    else
                    {
                        x.Remove(x[i]);
                        return;
                    }

                }
            }

            if (!ContainsElement(num))
            {
                throw new NotPresentInBag();
            }

        }

        public int FrequencyOfElem(int num)
        {

            if (length == 0)
            {
                throw new NoElementInBag();
            }

            for (int i = 0; i < length; i++)
            {
                if (x[i].Elem.Equals(num))
                {
                    return x[i].Frequency;
                }
            }

            if (!ContainsElement(num))
            {
                throw new NotPresentInBag();
            }
            return 0;
        }

        public void print()
        {

            if (length == 0)
            {
                throw new NoElementInBag();
            }

            for (int i = 0; i < x.Count; i++)
            {
                Console.WriteLine(x[i].ToString());
            }
        }

        public int onlyOneOccurence()
        {
            if (length == 0)
            {
                throw new NoElementInBag();
            }

           int count = 0;

            for (int i = 0; i < length; i++)
            {
                if (x[i].Frequency == 1)
                {
                    count++;
                    
                }
            }

            if (count == 0)
            {
                throw new NoSingleElementInBag();
            }

            return count;
        }

    }
}
