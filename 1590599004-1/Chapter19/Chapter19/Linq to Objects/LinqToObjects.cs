using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Chapter19
{
    class LinqToObjects
    {
        static void Main(string[] args)
        {
            //define string array 
            string[] names = { "James Huddleston", "Pearly", "Ami Knox", "Rupali Agarwal","Beth Christmas", "Fabio Claudio", "Vamika Agarwal", "Vidya Vrat Agarwal" };
            
            //linq query
            IEnumerable<string> namesOfPeople = from name in names
                                                where name.Length <= 16
                                                select name;
                    foreach (var name in namesOfPeople)
                    Console.WriteLine(name);
             
        }

    }
}
