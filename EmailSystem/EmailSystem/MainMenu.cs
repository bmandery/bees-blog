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
            Console.WriteLine("*************************************************************");
            Console.WriteLine("********************** Welcome ******************************");
            Console.WriteLine("******** To our email system, log in below ******************");
            Console.WriteLine("******* to register, enter in a valid email address *********");
            Console.WriteLine("*************************************************************");
            Console.Write("=>>");
            return Console.ReadLine();
        }


        public static string DisplayMainMenu()
        {
            Console.WriteLine("1.View Inbox");
            Console.WriteLine("2.Create New Email");
            Console.WriteLine("3.View Sent Items");
            Console.WriteLine("4.View Trash");
            Console.WriteLine("5.Logout");
            Console.Write("=>>");
            return Console.ReadLine();
        }
    }
}
