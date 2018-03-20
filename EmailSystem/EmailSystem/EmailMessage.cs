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
        DateTime? mdtTimeStamp = null;
        Boolean isNew = false;
        Boolean isDirty = false;

        //For when get load a message from disk
        public EmailMessage(int pintID, int pintEmailAccountID, string pstrSubject, string pstrMessageBody, DateTime? pdtTimeStamp, Boolean pblnIsNew)
        {
            MessageID = pintID;
            EmailAccountID = pintEmailAccountID;
            MessageSubject = pstrSubject;
            MessageBody = pstrMessageBody;
        }

        //For when we need to save a message to disk
        public EmailMessage(int pintEmailAccountID, string pstrSubject, string pstrMessageBody, DateTime? pdtTimeStamp)
        {
            EmailAccountID = pintEmailAccountID;
            MessageSubject = pstrSubject;
            MessageBody = pstrMessageBody;
            TimeStamp = pdtTimeStamp;
            //Mark object dirty so we can flag save to save it
            isDirty = true;
        }

        //save message to disk
        public Boolean Send()
        {
            if(isDirty)
            {
                //Save to disk
                //First when need a count of messages
                System.IO.StreamReader sr = new System.IO.StreamReader(@"../../EmailAccountFiles/Messages.txt");
                string file = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                string[] messageCountString = file.Split('|');
                int intMessageCount = messageCountString.Length;//Get how many messages there are currently, so we can increment the message IDS by 1

                //Create our message entry
                string messageLine = "|\r\n{\"id\":\"" + ++intMessageCount + "\",\"emailaccountid\":\"" + EmailAccountID.ToString() + "\",\"subject\":\"" + MessageSubject + "\",\"message\":\"" + MessageBody + "\":\"timestamp\":\""+ TimeStamp +"\"}";
                //Create a Files stream
                System.IO.FileStream fs = new System.IO.FileStream(@"../../EmailAccountFiles/Messages.txt", System.IO.FileMode.Append);
                //Convert out messageLine to a byte array so the file stream can write it to the file
                byte[] bytMessageLine = ASCIIEncoding.ASCII.GetBytes(messageLine);
                //Write to the stream
                fs.Write(bytMessageLine, 0, bytMessageLine.Length);
                //Commit to the file
                fs.Close();
                //Free up memory
                fs.Dispose();

                return true;
            }
            return false;
        }

        //ID of the message
        public int MessageID
        {
            get => mintID;
            private set => mintID = value;
        }
        //ID of the accounte the message belongs to
        public int EmailAccountID
        {
            get => mintEmailAccountID;
            private set => mintEmailAccountID = value;
        }
        //Subject of the message
        public string MessageSubject
        {
            get => mstrSubject;
            private set => mstrSubject = value;
        }
        //Body of the message
        public string MessageBody
        {
            get => mstrMessageBody;
            private set => mstrMessageBody = value;
        }
        //Time stamp when the message was sent
        public DateTime? TimeStamp
        {
            get => mdtTimeStamp;
            private set => mdtTimeStamp = value;
        }
    }
}
