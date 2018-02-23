using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    /*
     * Our main menu class will be resonsible for all the menus that are displayed
     */
    class MainMenu
    {

        public static string DisplayLogOn()
        {
            //60 stars
            Console.WriteLine("************************************************************");
            Console.WriteLine("***********************Welcome******************************");
            Console.WriteLine("*********To our email system, log in below******************");
            Console.WriteLine("********to register, enter in a valid email address*********");
            Console.WriteLine("************************************************************");
            Console.Write("=>>");
            return Console.ReadLine();
        }
    }
}
