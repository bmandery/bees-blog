using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    class Program
    {
        //What do we need for the program to function
        /*
         Classes:
            Email Message
                Sender
                Subject
                Body
                To
                Time Stamp
                Delivery Receipt
                    
            Email Message List

            Person/User
                First Name
                Last Name
                email address
                user anme
                password
               
            
            We will have a simple menu that will allow a user to register for an email account
            Log into their account
                Inbox
                Trash
                Sent

            Send a message to another user
            Delete Messages
            Recover From Trash
            Delete permently from trash
            List Other users/Global Address List

            Reset password           


        */
        static void Main(string[] args)
        {

            string userEmail = string.Empty;
            userEmail = MainMenu.DisplayLogOn();
            while(true)
            {
                
                //Check for a valid email
                if(userEmail.Contains("@") && (userEmail.Contains(".com")|| userEmail.Contains(".net")))
                {
                    //Console.Write("valid email");
                    break;
                }
                else
                { userEmail = ""; }
                userEmail = MainMenu.DisplayLogOn();
            }

            //We have our version of a valid email address entered
            //Read for password
            string userPassword = string.Empty;
            while(true)
            {
                
                Console.Write("Password=>>");
                userPassword = Console.ReadLine();
                if (userPassword.Trim().Length != 0)
                    break;
            }

            EmailAccount.AccountValid(userEmail, userPassword);
            Console.Clear();
            Console.WriteLine(userEmail + "    " + userPassword);
            Console.ReadKey();

            //byte[] _fileStuff = new byte[4096];
            //System.IO.FileStream fs = System.IO.File.Open(@"../../emailAccountfiles/EmailAccounts.txt",System.IO.FileMode.Open);

            //string str = "brad";
            //byte[] myBytes = Encoding.ASCII.GetBytes(str);
            
            //System.IO.StreamReader sr = new System.IO.StreamReader(fs);
            //string myline = sr.ReadToEnd();

            //string[] fileParse = myline.Split('|');
            //fs.Close();
            //fs.Dispose();
        }
    }
}
