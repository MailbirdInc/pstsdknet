using System;
using pstsdk.definition.pst.message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using pstsdk.definition.util.primitives;
using pstsdk.layer.pst;
using pstsdk.test.mocks;

namespace pstsdk.test
{
    public class IAttachmentTest
    {
        public static void SizeTest(IAttachment target, int expects)
        {
            Assert.AreEqual(expects, target.Size);
        }

        public static void IsMessageTest(IAttachment target, bool expects)
        {
            Assert.IsTrue(target.IsMessage == expects);
        }

        public static void FilenameTest(IAttachment target, string expects)
        {
            Assert.IsTrue(target.Filename.CompareTo(expects) == 0);
        }

        public static void ContentSizeTest(IAttachment target, int expects)
        {
            Assert.AreEqual(expects, target.ContentSize);
        }

        public static void ByteStreamTest(IAttachment target)
        {
            Assert.Inconclusive("Need to implement this test correctly");
        }

        public static void OpenAsMessageTestExpectsNull(IAttachment target)
        {
            Assert.IsNull(target.OpenAsMessage());
        }

        public static void OpenAsMessageTestExpectsNotNull(IAttachment target)
        {
            Assert.IsNotNull(target.OpenAsMessage());
        }

        public static void BytesTest(IAttachment target, byte[] expects)
        {
            Assert.IsTrue(target.Bytes.SequenceEqual(expects));
        }

        public static void BytesTestExpectsNull(IAttachment target)
        {
            Assert.IsNull(target.Bytes);
        }
    }
}
