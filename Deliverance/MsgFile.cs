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
    /// </summary>
    public class MsgFile
    {
        /// <summary>
        /// Returns a list of email Recipients.
        /// </summary>
        public List<Recipient> Recipients
        {
            get
            {
                return _message.Recipients;
            }
        }

        /// <summary>
        /// Returns the sender email address
        /// </summary>
        public string FromAddress
        {
            //This is messy logic... Since the SMTP address may be empty, we should use the emailaddress field.
            //The SMTP address field seems to be populated when the email address field contains an exchange address (EX).
            get
            {
                var address = _message.GetProperty(MessageProperties.PidTagSenderSmtpAddress);
                if (address == null)
                {
                    address = _message.GetProperty(MessageProperties.PidTagSenderEmailAddress); //PidTagSenderEmailAddress seems to differ if it comes from exchange
                }
                return address.ToString();
            }
        }

        /// <summary>
        /// Returns the Display Name of the sender
        /// </summary>
        public string FromName
        {
            get
            {
                return _message.GetProperty(MessageProperties.PidTagSenderName).ToString();
            }
        }

        /// <summary>
        /// Returns the email subject
        /// </summary>
        public string Subject
        {
            get
            {
                return _message.GetProperty(MessageProperties.PidTagSubject).ToString();
            }
        }

        /// <summary>
        /// Returns the email body in plain-text
        /// </summary>
        public string Body
        {
            get
            {
                return _message.GetProperty(MessageProperties.PidTagBody).ToString();
            }
        }

        /// <summary>
        /// Returns the HTML body if it exists, null if it doesn't
        /// </summary>
        public string HTMLBody
        {
            get
            {
                string htmlBody = null;
                if (_message.IsUnicode)
                {
                    //for some reason if the message is in unicode the body is in binary ASCII...
                    var htmlBinary = _message.GetProperty(MessageProperties.PidTagBodyHtml);
                    if (htmlBinary != null)
                        htmlBody = Encoding.ASCII.GetString((byte[])htmlBinary);
                }
                else
                {
                    htmlBody = _message.GetProperty(MessageProperties.PidTagBodyHtml).ToString();
                }
                return htmlBody;
            }
        }

        private Message _message;

        /// <summary>
        /// Loads a .MSG file
        /// </summary>
        /// <param name="filePath">The path to the .MSG file</param>
        public void Load(string filePath)
        {
            var msgParser = new MsgParser(filePath);
            _message = msgParser.Parse();
        }
    }
}
