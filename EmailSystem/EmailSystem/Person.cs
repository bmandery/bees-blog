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
        string strFirstName = string.Empty;
        string strLastName = string.Empty;
        string strDateOfBirth = string.Empty;

        public Person(string pFirstName, string pLastName, string pDateOfBirth)
        {
            FirstName = pFirstName;
            LastName = pLastName;
            DateOfBirth = pDateOfBirth;
        }




        /*Properties*/
        public string FirstName
        {
            get => strFirstName;
            private set => strFirstName = value;
        }

        public string LastName
        {
            get => strLastName;
            private set => strLastName = value;
        }

        public string DateOfBirth
        {
            get => strDateOfBirth;
            private set => strDateOfBirth = value;
        }
    }
}
