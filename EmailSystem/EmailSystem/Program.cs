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
            //Kick things off by displaying the logon screen
            DPLogonMenu();
            Console.ReadKey();
        }

        //Our log on screen
        static void DPLogonMenu()
        {
            while (true)
            {
                string userEmail = string.Empty;
                while (true)
                {
                    userEmail = MainMenu.DisplayLogOn();
                    //Check for a valid email
                    if (userEmail.Contains("@") && (userEmail.Contains(".com") || userEmail.Contains(".net")))
                    {
                        //Console.Write("valid email");
                        break;
                    }
                    else
                    { userEmail = ""; }
                    
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
                //Call our static method to make sure the email account is valid
                if (EmailAccount.AccountValid(userEmail, userPassword))
                {
                    //Create our Email account instance which in turn will create our person
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

                    case "6":
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
                Console.Clear();
                Console.WriteLine("Enter the ID of the message you would like to read");
                //Get all the messages for this account

                
                for (int x = 0; x<=myMessages.Length-1; x++)
                {
                    string[] myMessageRecords = myMessages[x].Split(',');
                    string[] myMessageID = myMessageRecords[0].Split(':');
                    string[] myMessageAccountID = myMessageRecords[1].Split(':');
                    string[] myMessageSubject = myMessageRecords[2].Split(':');
                    string[] myMessageBody = myMessageRecords[3].Split(':');

                    Console.WriteLine("MessageID: " + (x+1).ToString() + "                            Subject: " + myMessageSubject[1].ToString());
                }


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
                        string[] myMessageRecord = myMessages[intUserInput-1].Split(',');
                        string[] myMessageBody = myMessageRecord[3].Split(':');
                        Console.WriteLine(myMessageBody[1].ToString());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        static void DPCreateNewEmail()
        {
            //Clear the console
            Console.Clear();

            //Couple local variables that we'll use when creating the email object
            int intToAccountID = 0;
            string strTo = string.Empty;

            //Get To address from the user
            while (strTo.Trim().Length == 0)
            {
                Console.Write("To: ");
                strTo = Console.ReadLine();

                //Make sure it's a valid email address in our system
                foreach (string s in EmailAccount.GetEmailAddress())
                {
                    string[] emailAddress = s.Split(':');
                    if (emailAddress[1].ToLower() == strTo)
                    {
                        //Valid Email, sent the account id of who it is going to
                        intToAccountID = Int32.Parse(emailAddress[0].ToString());
                        break;
                    }
                }
            }

            Console.WriteLine();
            //Get Subject
            string strSubject = string.Empty;
            while (strSubject.Trim().Length == 0)
            {
                Console.Write("Subject: ");
                strSubject = Console.ReadLine();
            }

            Console.WriteLine();
            string strMessageBody = string.Empty;
            while (strMessageBody.Trim().Length == 0)
            {
                Console.Write("Message: ");
                strMessageBody = Console.ReadLine();
            }

            //Create our email message.
            EmailMessage message = new EmailMessage(intToAccountID, strSubject, strMessageBody, DateTime.Now);
            //Send off the message
            if (message.Send())
            {
                Console.Clear();
                Console.WriteLine("Your message have been sent, press anykey to return to main menu");
            }

            Console.ReadKey();
        }
    }
}
