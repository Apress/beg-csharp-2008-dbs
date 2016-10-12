﻿using System;
using System.Linq;
using System.Xml.Linq;


namespace Chapter19
{
    class LinqToXml
    {
        static void Main(string[] args)
        {
            //load the productstable.xml in memory
            XElement doc = XElement.Load(@"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\Chapter19\productstable.xml");

            //query xml doc
             var products = from prodname in doc.Descendants("products")
             select prodname.Value;

            //display details
            foreach (var prodname in products)
            Console.WriteLine("Product's Detail = {0}\t", prodname);
        }
    }
}
