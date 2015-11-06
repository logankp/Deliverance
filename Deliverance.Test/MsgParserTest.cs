using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliverance.OXMSG;
using Deliverance.OXMSG.Properties;
using NUnit.Framework;

namespace Deliverance.Test
{
    [TestFixture]
    public class MsgParserTest
    {
        MsgParser parser;
        Message msgFile;
        [Test]
        public void ReadPropertyStreamAnsiTest()
        {
            parser = new MsgParser(@"TestFiles\TestMessage-ansi.msg");
            msgFile = parser.Parse();
            PropertyStream ps = msgFile.PropertyStream;
            Assert.That(ps.Header, Is.Not.Null);
            Assert.That(ps.Header.NextRecipientId, Is.EqualTo(3));
            Assert.That(ps.Header.NextAttachmentId, Is.EqualTo(1));
            Assert.That(ps.Header.RecipientCount, Is.EqualTo(3));
            Assert.That(ps.Header.AttachmentCount, Is.EqualTo(1));
            Assert.That(ps.NumberOfProperties, Is.EqualTo(23));
        }

        [Test]
        public void ReadPropertyStreamUnicodeTest()
        {
            parser = new MsgParser(@"TestFiles\TestMessage-unicode.msg");
            msgFile = parser.Parse();
            PropertyStream ps = msgFile.PropertyStream;
            Assert.That(ps.Header, Is.Not.Null);
            Assert.That(ps.Header.NextRecipientId, Is.EqualTo(3));
            Assert.That(ps.Header.NextAttachmentId, Is.EqualTo(1));
            Assert.That(ps.Header.RecipientCount, Is.EqualTo(3));
            Assert.That(ps.Header.AttachmentCount, Is.EqualTo(1));
            Assert.That(ps.NumberOfProperties, Is.EqualTo(24));
        }

        [Test]
        public void ReadPropertyStreamDefaultTest()
        {
            parser = new MsgParser(@"TestFiles\TestMessage-default.msg");
            msgFile = parser.Parse();
            PropertyStream ps = msgFile.PropertyStream;
            Assert.That(ps.Header, Is.Not.Null);
            Assert.That(ps.Header.NextRecipientId, Is.EqualTo(3));
            Assert.That(ps.Header.NextAttachmentId, Is.EqualTo(1));
            Assert.That(ps.Header.RecipientCount, Is.EqualTo(3));
            Assert.That(ps.Header.AttachmentCount, Is.EqualTo(1));
            Assert.That(ps.NumberOfProperties, Is.EqualTo(24));
        }

        [Test]
        public void GetNamedPropertiesTest()
        {
            parser = new MsgParser(@"TestFiles\TestMessage-default.msg");
            msgFile = parser.Parse();
            var namedProperties = msgFile.NamedProperties;
            Assert.That(namedProperties.Count, Is.EqualTo(1));
            Assert.That(namedProperties[0].GUID, Is.EqualTo(new Guid("{86030200-0000-0000-c000-000000000046}")));
            Assert.That(namedProperties[0].ID, Is.EqualTo(32772));
            Assert.That((namedProperties[0].Entry as VariableLengthPropertyEntry).VariableLengthData, Is.EqualTo("en-US").IgnoreCase);
        }


    }
}
