using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXCMSG.Properties;
using Deliverance.OXMSG;
using Deliverance.OXMSG.Properties;

namespace Deliverance
{
    /// <summary>
    /// This class represents a parsed MSG file.
    /// TODO: Support HTML bodies
    /// </summary>
    public class MsgFile
    {
        public List<Recipient> Recipients
        {
            get
            {
                return _message.Recipients;
            }
        }
        public string FromAddress
        {
            //This is messy logic... Since the SMTP address may be empty, we should use the emailaddress field.
            //The SMTP address field seems to be populated when the email address field contains an exchange address (EX).
            //I'm sure there's a better way to do this...
            get
            {
                var address = _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                    .FirstOrDefault(x => x.PropertyTag.ID == MessageProperties.PidTagSenderSmtpAddress); //PidTagSenderEmailAddress seems to differ if it comes from exchange
                if (address == null)
                {
                    address = _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                        .FirstOrDefault(x => x.PropertyTag.ID == MessageProperties.PidTagSenderEmailAddress);
                }
                return address.VariableLengthData.ToString();
            }
        }
        public string FromName
        {
            get
            {
                return _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                    .First(x => x.PropertyTag.ID == MessageProperties.PidTagSenderName).VariableLengthData.ToString();
            }
        }
        public string Subject
        {
            get
            {
                return _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                    .First(x => x.PropertyTag.ID == MessageProperties.PidTagSubject).VariableLengthData.ToString();
            }
        }
        public string Body
        {
            get
            {
                return _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                    .First(x => x.PropertyTag.ID == MessageProperties.PidTagBody).VariableLengthData.ToString();
            }
        }

        public string HTMLBody
        {
            get
            {
                string htmlBody;
                if (_message.IsUnicode)
                {
                    //for some reason if the message is in unicode the body is in binary ASCII...
                    htmlBody = Encoding.ASCII.GetString((byte[])_message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                        .First(x => x.PropertyTag.ID == MessageProperties.PidTagBodyHtml).VariableLengthData);
                }
                else
                {
                    htmlBody = _message.PropertyStream.Data.OfType<VariableLengthPropertyEntry>()
                        .First(x => x.PropertyTag.ID == MessageProperties.PidTagBodyHtml).VariableLengthData.ToString();
                }
                return htmlBody;
            }
        }

        private Message _message;

        public void Load(string filePath)
        {
            var msgParser = new MsgParser(filePath);
            _message = msgParser.Parse();
        }
    }
}
