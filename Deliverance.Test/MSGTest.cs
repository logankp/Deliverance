using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG;
using NUnit.Framework;

namespace Deliverance.Test
{
    [TestFixture]
    class MSGTest
    {
        MsgFile _msgFile;
        public MSGTest()
        {
            _msgFile = new MsgFile();
            _msgFile.Load(@"TestFiles\TestMessage-default.msg");
        }

        [Test]
        public void MSGFieldsTest()
        {
            Assert.That(_msgFile.Subject, Is.Not.Empty);
            Assert.That(_msgFile.Body, Is.Not.Empty);
            Assert.That(_msgFile.FromAddress, Is.EqualTo("sender@example.com"));
            Assert.That(_msgFile.FromName, Is.EqualTo("Sender"));
        }

        [Test]
        public void MSGRecipientsTest()
        {
            Assert.That(_msgFile.Recipients.Count, Is.EqualTo(3));
            Assert.That(_msgFile.Recipients[0].DisplayName, Is.EqualTo("Recipient 1"));
            Assert.That(_msgFile.Recipients[0].EmailAddress, Is.EqualTo("recipient1@example.com"));
            Assert.That(_msgFile.Recipients[0].Type, Is.EqualTo(RecipientType.To));
            Assert.That(_msgFile.Recipients[1].DisplayName, Is.EqualTo("Recipient 2"));
            Assert.That(_msgFile.Recipients[1].EmailAddress, Is.EqualTo("recipient2@example.com"));
            Assert.That(_msgFile.Recipients[1].Type, Is.EqualTo(RecipientType.To));
            Assert.That(_msgFile.Recipients[2].DisplayName, Is.EqualTo("CC1"));
            Assert.That(_msgFile.Recipients[2].EmailAddress, Is.EqualTo("cc1@example.com"));
            Assert.That(_msgFile.Recipients[2].Type, Is.EqualTo(RecipientType.CC));
        }
    }
}
