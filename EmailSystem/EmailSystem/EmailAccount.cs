using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    /*Our Email account will have
     our email address which will double as our logon
     and our password in the form of plain clear text

        Our email account will also carry around an email message class that
        holds the email messages
     */
    class EmailAccount
    {
        string mstrEmailAddress = string.Empty;
        string mstrPassword = string.Empty;
        int mintEmailAccountID = -1;

        public EmailAccount(string pstrEmailAddress, string pstrPassword)
        {
            EmailAddress = pstrEmailAddress;
            Password = pstrPassword;
            //Go read email account file
            System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/EmailAccountIDS.txt");
            while (sr.Peek() > 0)
            {
                string line = sr.ReadToEnd();
                string[] fileLines = line.Split('|');

                for (int x = 0; x <= fileLines.Length - 1; x++)
                {
                    string _line = fileLines[x].ToString();
                    _line = _line.Replace("\"", "");
                    _line = _line.Replace("{", "");
                    _line = _line.Replace("}", "");
                    string[] _line2 = _line.Split(',');
                    string[] _ID = _line2[0].Split(':');
                    string[] _userName = _line2[1].Split(':');
                    _userName[1]=_userName[1].Replace("\r\n", "");

                    //Check to see if this is the email address we are looking for
                    if(_userName[1].ToString() == pstrEmailAddress)
                    {
                        //This is our account
                        //set Account ID
                        AccountID = Int32.Parse(_ID[1].ToString());
                        break;
                    }
                }
            }

            sr.Close();
            sr.Dispose();
            //AccountID = pintEmailAccountID;
        }

        public string[] GetMessages()
        {
            
            //Read message file
            System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/Messages.txt");
            string file = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();

            //clean the string
            file = file.Replace("\"", "");
            file = file.Replace("{", "");
            file = file.Replace("}", "");
            file = file.Replace("\r\n", "");

            //Split messages out
            string[] messages = file.Split('|');
            string[] returnMessages = new string[] { };
            Array.Resize(ref returnMessages, messages.Length);
            int messageRecordIndex = 0;
            int messageRecordToNegate = 0;
            Boolean blnMessageSet = false;
            //Find messages for the given account
            for(int x = 0; x<=messages.Length-1; x++)
            {
                string[] _singleMessage = messages[x].Split(',');
                string[] _singleMessageID = _singleMessage[1].Split(':');
                if(Int32.Parse(_singleMessageID[1].ToString())==AccountID)
                {
                    returnMessages.SetValue(messages[x], messageRecordIndex);
                    messageRecordIndex++;
                    blnMessageSet = true;
                }
<<<<<<< HEAD
                else
                {
                    ///Array.Resize(ref returnMessages, messages.Length - 1);
                    messageRecordToNegate++;
                }               
            }

            if(!blnMessageSet)
            {
                Array.Resize(ref returnMessages, messageRecordToNegate=messageRecordIndex);
=======
                
>>>>>>> 7cbdec7dd95f145c1f5e5be9fcc4cdfdb7c368a5
            }

            Array.Resize(ref returnMessages, messageRecordIndex);

            //return a string array of messages
            return returnMessages;
        }

        public int AccountID
        {
            get => mintEmailAccountID;
            private set => mintEmailAccountID = value;
        }
        public string EmailAddress
        {
            get => mstrEmailAddress;
            private set => mstrEmailAddress = value;
        }
        public string Password
        {
            get => mstrPassword;
            private set => mstrPassword = value;
        }


        #region Static Methods
        public static Boolean AccountValid(string emailAddress, string Password)
        {
            //read account file
            System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/EmailAccounts.txt");
            while(sr.Peek()>0)
            {
                string line = sr.ReadToEnd();
                string[] fileLines = line.Split('|');

                for(int x=0; x<=fileLines.Length-1; x++)
                {
                    string[] parseLine = fileLines[x].Split(',');
                    string[] emailLine = parseLine[0].Split(':');
                    string[] passLine = parseLine[1].Split(':');

                    string _email = emailLine[1].ToString();
                    _email = _email.Replace("\"", "");
                    string _pwd = passLine[1].ToString();
                    _pwd = _pwd.Replace("}", "");
                    _pwd = _pwd.Replace("\"", "");
                    _pwd = _pwd.Replace("\r\n", "");
                    
                    if (_email == emailAddress && _pwd == Password)
                        return true;
                }
            }

            sr.Close();
            sr.Dispose();
            return false;
        }

        public static string[] GetEmailAddress()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/EmailAccountIDS.txt");
            string file = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();

            //clean file up
            file = file.Replace("\"", "");
            file = file.Replace("{", "");
            file = file.Replace("}", "");
            file = file.Replace("\r\n", "");

            //break into accounts
            string[] emailAccounts = file.Split('|');
            int intEmailAccounts = emailAccounts.Length;
            string[] returnEmailAddresses = new string[] { };
            Array.Resize(ref returnEmailAddresses, intEmailAccounts);
            
            for(int x = 0; x<=emailAccounts.Length-1; x++)
            {
                //Account Records
                string[] accountRecords = emailAccounts[x].Split(',');
                string[] userID = accountRecords[0].Split(':');
                string[] emailAddress = accountRecords[1].Split(':');
                returnEmailAddresses.SetValue(userID[1].ToString() +":"+emailAddress[1].ToString(), x);
            }

            return returnEmailAddresses;
        }
        #endregion
    }
}
