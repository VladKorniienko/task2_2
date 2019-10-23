using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korniienko_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var list=new CustomList<int>(5,25);
            list.Add(5);
            list.Add(23343);
            list.Add(2);
            list.Add(43);
            list.Add(1848);
            list.Add(99999);
            list.Add(1111);
            list.Add(567);
            list.Add(565);
            list.PrintContents();
            list.PrintContents();
           // list.Remove(1111);
            //list.Clear();
           // list.PrintContents();
            
            Console.ReadKey();
        }
    }
}
