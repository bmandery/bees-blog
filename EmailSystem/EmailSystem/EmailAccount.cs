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
        string strEmailAddress = string.Empty;
        string strPassword = string.Empty;


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
                }
            }
            return false;
        }
    }
}
