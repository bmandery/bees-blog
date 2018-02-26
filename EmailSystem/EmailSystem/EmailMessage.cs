using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem
{
    public class EmailMessage
    {
        int mintID = -1;
        string mstrSubject = string.Empty;
        string mstrMessageBody = string.Empty;
        int mintEmailAccountID = -1;
        Boolean isDirty = false;

        //For when get load a message from disk
        public EmailMessage(int pintID, int pintEmailAccountID, string pstrSubject, string pstrMessageBody)
        {
            MessageID = pintID;
            EmailAccountID = pintEmailAccountID;
            MessageSubject = pstrSubject;
            MessageBody = pstrMessageBody;
        }

        //For when we need to save a message to disk
        public EmailMessage(int pintEmailAccountID, string pstrSubject, string pstrMessageBody)
        {
            EmailAccountID = pintEmailAccountID;
            MessageSubject = pstrSubject;
            MessageBody = pstrMessageBody;

            //Mark object dirty so we can flag save to save it
            isDirty = true;
        }



        public int MessageID
        {
            get => mintID;
            private set => mintID = value;
        }

        public int EmailAccountID
        {
            get => mintEmailAccountID;
            private set => mintEmailAccountID = value;
        }
        public string MessageSubject
        {
            get => mstrSubject;
            private set => mstrSubject = value;
        }

        public string MessageBody
        {
            get => mstrMessageBody;
            private set => mstrMessageBody = value;
        }
    }
}
