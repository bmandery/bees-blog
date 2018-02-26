using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    /*Our person class will be just that, a person
     Our person class with have an account. Meaning person
     will carry around an instance of the account*/
    class Person
    {
        string mstrFirstName = string.Empty;
        string mstrLastName = string.Empty;
        string mstrDateOfBirth = string.Empty;
        int mintAccountID = -1;
        EmailAccount mobjEmailAccount;

        //Full Constructor
        public Person(int pintAccountID, string pstrFirstName, string pstrLastName, string pstrDateOfBirth)
        {

        }

        //Create a new person and save to disk
        public Person(string pstrFirstName, string pstrLastName, string pstrDateOfBirth)
        {
            FirstName = pstrFirstName;
            LastName = pstrLastName;
            DateOfBirth = pstrDateOfBirth;
        }

        //Go get a person from disk
        public Person(EmailAccount _emailAccount)
        {
            Account = _emailAccount;
            
            //Lets go load up our person now
            LoadPerson();
        }

        private void LoadPerson()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/PersonDB.txt");

            string _file = sr.ReadToEnd();
            //Clean file
            _file = _file.Replace("\"", "");
            _file = _file.Replace("{", "");
            _file = _file.Replace("}", "");
            _file = _file.Replace("\r\n", "");
            string[] accounts = _file.Split('|');

            for(int x = 0; x<=accounts.Length-1; x++)
            {
                string[] _temp = accounts[x].Split(',');
                //ID
                string[] _id = _temp[0].Split(':');
                //First
                string[] _fName = _temp[1].Split(':');
                //Last
                string[] _lName = _temp[2].Split(':');
                //DOB
                string[] _dob = _temp[3].Split(':');

                if(Account.AccountID == Int32.Parse(_id[1].ToString()))
                {
                    //Valid Person
                    FirstName = _fName[1].ToString();
                    LastName = _lName[1].ToString();
                    DateOfBirth = _dob[1].ToString();
                    break;
                }
            }



            sr.Close();
            sr.Dispose();
        }


        /*Properties*/
        public EmailAccount Account
        {
            get => mobjEmailAccount;
            private set => mobjEmailAccount = value;
        }
        public int AccountID
        {
            get => mintAccountID;
            private set => mintAccountID = value;
        }
        public string FirstName
        {
            get => mstrFirstName;
            private set => mstrFirstName = value;
        }

        public string LastName
        {
            get => mstrLastName;
            private set => mstrLastName = value;
        }

        public string DateOfBirth
        {
            get => mstrDateOfBirth;
            private set => mstrDateOfBirth = value;
        }
    }
}
