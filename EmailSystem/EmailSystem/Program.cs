using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    class Program
    {
        static EmailAccount _account;
        static Person p;
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

            DPLogonMenu();
            Console.ReadKey();
        }

        static void DPLogonMenu()
        {
            while (true)
            {
                string userEmail = string.Empty;
                userEmail = MainMenu.DisplayLogOn();
                while (true)
                {

                    //Check for a valid email
                    if (userEmail.Contains("@") && (userEmail.Contains(".com") || userEmail.Contains(".net")))
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
                while (true)
                {

                    Console.Write("Password=>>");
                    userPassword = Console.ReadLine();
                    if (userPassword.Trim().Length != 0)
                        break;
                }

                if (EmailAccount.AccountValid(userEmail, userPassword))
                {
                    //Create our Email account which in turn will create our person
                    _account = new EmailAccount(userEmail, userPassword);
                    p = new Person(_account);
                    DPMainMenu();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Login information");
                    Console.Write("Press anykey to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }

        static void DPMainMenu()
        {
            Console.Clear();
            
            while(true)
            {
                string menuChoice = MainMenu.DisplayMainMenu();
                switch (menuChoice)
                {
                    case "1":
                        DPInbox();
                        break;

                    case "2":
                        DPCreateNewEmail();
                        break;

                    case "5":
                        //Clear all variables and redisplay Logon menu
                        Console.Clear();
                        DPLogonMenu();
                        break;
                    default:
                        continue;
                }
            }
        }

        static void DPInbox()
        {
            string[] myMessages = _account.GetMessages();
            while (true)
            {
                //Get all the messages for this account
                
                for(int x = 0; x<=myMessages.Length-1; x++)
                {
                    string[] myMessageRecords = myMessages[x].Split(',');
                    string[] myMessageID = myMessageRecords[0].Split(':');
                    string[] myMessageAccountID = myMessageRecords[1].Split(':');
                    string[] myMessageSubject = myMessageRecords[2].Split(':');
                    string[] myMessageBody = myMessageRecords[3].Split(':');

                    Console.WriteLine("MessageID: " + myMessageID[1].ToString() + "                            Subject: " + myMessageSubject[1].ToString());
                }


                if (myMessages.Length > 0)
                {
                    while (true)
                    {
                        Console.Write("Enter ID to read or type \"exit\" to return to previous menu=>>");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "exit")
                        {
                            Console.Clear();
                            return;
                        }

                        int intUserInput = Int32.Parse(input.ToString());
                        if (intUserInput <= myMessages.Length)
                        {
                            Console.Clear();
                            string[] myMessageRecord = myMessages[intUserInput - 1].Split(',');
                            string[] myMessageBody = myMessageRecord[3].Split(':');
                            Console.WriteLine(myMessageBody[1].ToString());
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }
                Console.Clear();
                return;
            }
        }

        static void DPCreateNewEmail()
        {
            Console.Clear();
            
            string strTo = string.Empty;
            //Get To address
            while (strTo.Trim().Length == 0)
            {
                Console.Write("To: ");
                strTo = Console.ReadLine();

                //Make sure it's a valid email address in our system
                foreach(string s in EmailAccount.GetEmailAddress())
                {
                    if(s == strTo)
                    {
                        //Valid Email
                        break;
                    }
                }
            }

            Console.WriteLine();
            //Get Subject
            string strSubject = string.Empty;
            while(strSubject.Trim().Length == 0)
            {
                Console.Write("Subject: ");
                strSubject = Console.ReadLine();
            }

            Console.WriteLine();
            string strMessageBody = string.Empty;
            while(strMessageBody.Trim().Length == 0)
            {
                Console.Write("Message: ");
                strMessageBody = Console.ReadLine();
            }

            Console.WriteLine(strTo);
            Console.WriteLine(strSubject);
            Console.WriteLine(strMessageBody);

            Console.ReadKey();
        }
    }
}
