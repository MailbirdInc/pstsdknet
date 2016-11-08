using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.layer.pst;

namespace pstsdk.test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PstSdkIntegrationTest
    {
        [TestInitialize()]
        public void Init()
        {
            SetupTestFile(
                new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "sample1.pst")), 
                Properties.Resources.sample1);
            SetupTestFile(
                new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "sample2.pst")),
                Properties.Resources.sample2);
            SetupTestFile(
                new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "submessage.pst")),
                Properties.Resources.submessage);
            SetupTestFile(
                new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "test_ansi.pst")),
                Properties.Resources.test_ansi);
            SetupTestFile(
                new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "test_unicode.pst")),
                Properties.Resources.test_unicode);
        }

        private void SetupTestFile(FileInfo testFile, byte[] contents)
        {
            if (testFile.Exists)
                testFile.Delete();

            using (var fs = testFile.OpenWrite())
                fs.Write(contents, 0, contents.Length);
            testFile.Refresh();
            testData.Add(testFile);
        }

        List<FileInfo> testData = new List<FileInfo>();

        [TestCleanup]
        public void Cleanup()
        {
            foreach (var testFile in testData)
                try { if (testFile.Exists) testFile.Delete(); }
                catch { }
        }

        [TestMethod]
        public void Pst_Ctor()
        {
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");

                using (var pst = new Pst(testFile.FullName))
                {
                    Assert.IsNotNull(pst);
                }
            }
        }
        [TestMethod]
        public void Pst_Name()
        {
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");
                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    var name = pst.Name;
                    Assert.IsNotNull(pst);
                    Assert.IsTrue(!string.IsNullOrEmpty(name), "Pst.Name returned an empty value.");
                    Console.WriteLine("  Name: {0}", name);
                }
            }
        }
        [TestMethod]
        public void Messages_Enumerator_Get_Subject_Prop()
        {
            int countMessages = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");
                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    foreach (var message in pst.Messages)
                    {
                        Assert.IsNotNull(message);
                        var subject = message.Subject;

                        //Assert.IsTrue(!string.IsNullOrEmpty(subject), "Message.Subject returned an empty value.");
                        Console.WriteLine("  Node: {0}, Subject: {1}", message.Node.Value, subject);
                        countMessages++;
                    }
                }
            }
            
            Assert.AreEqual(6, countMessages, "Expected 6 messages, but only iterated over " + countMessages + " messages.");
        }
        [TestMethod]
        public void Folder_Enumerator_Get_Name_Prop()
        {
            int countFolders = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");
                Console.WriteLine("File: {0}", testFile.Name);
                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    foreach (var folder in pst.Folders)
                    {
                        Assert.IsNotNull(folder);
                        var name = folder.Name;

                        //Assert.IsTrue(!string.IsNullOrEmpty(name), "Folder.Name returned an empty value.");
                        Console.WriteLine("  Node: {0}, Name: {1}", folder.Node.Value, name);
                        countFolders++;
                    }
                }
            }

            Assert.AreEqual(25, countFolders, "Expected 25 folders, but actually iterated over " + countFolders + " folders.");
        }
        [TestMethod]
        public void Folder_Enumerator_Recursive_Get_Name_Prop()
        {
            int countFolders = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");
                
                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    Queue<IFolder> folders = new Queue<IFolder>();
                    foreach (var folder in pst.Folders)
                        folders.Enqueue(folder);

                    while (folders.Count > 0)
                    {
                        var folder = folders.Dequeue();

                        Assert.IsNotNull(folder);
                        var name = folder.Name;
                        var subFolderCount = folder.SubFolderCount;

                        Console.WriteLine("  Node: {0}, Name: {1}, Count: {2}", folder.Node.Value, name, subFolderCount);
                        countFolders++;
                    }
                }
            }

            Assert.AreEqual(25, countFolders, "Expected 55 folders, but actually iterated over " + countFolders + " folders.");
        }

        [TestMethod]
        public void Folder_Enumerator_Recursive_Get_Name_Prop_And_Messages_With_Subject_Prop()
        {
            int countFolders = 0;
            int countMessages = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");

                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    var folders = new Queue<IFolder>();
                    foreach (var folder in pst.Folders)
                        folders.Enqueue(folder);

                    while (folders.Count > 0)
                    {
                        var folder = folders.Dequeue();

                        Assert.IsNotNull(folder);
                        var name = folder.Name;
                        var subFolderCount = folder.SubFolderCount;

                        Console.WriteLine("  Node: {0}, Name: {1}, Count: {2}", folder.Node.Value, name, subFolderCount);
                        countFolders++;

                        if (folder.MessageCount > 0)
                        {
                            foreach (var message in folder.Messages)
                            {
                                Assert.IsNotNull(message);
                                var subject = message.Subject;

                                //Assert.IsTrue(!string.IsNullOrEmpty(subject), "Message.Subject returned an empty value.");
                                Console.WriteLine("    Node: {0}, Subject: {1}", message.Node.Value, subject);
                                countMessages++;
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(25, countFolders, "Expected 25 folders, but actually iterated over " + countFolders + " folders.");
            Assert.AreEqual(6, countMessages, "Expected 6 messages, but actually iterated over " + countMessages + " messages.");
        }

        [TestMethod]
        public void Folder_Enumerator_Recursive_Get_Name_Prop_And_Associated_Messages_With_Subject_Prop()
        {
            // note: this test is kind of pointless at the moment, because our test data doesn't have any associated content in it.

            int countFolders = 0;
            int countMessages = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");

                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    Queue<IFolder> folders = new Queue<IFolder>();
                    foreach (var folder in pst.Folders)
                        folders.Enqueue(folder);

                    while (folders.Count > 0)
                    {
                        var folder = folders.Dequeue();

                        Assert.IsNotNull(folder);
                        var name = folder.Name;
                        var subFolderCount = folder.SubFolderCount;

                        Console.WriteLine("  Node: {0}, Name: {1}, Count: {2}", folder.Node.Value, name, subFolderCount);
                        countFolders++;

                        if (folder.AssociatedMessageCount > 0)
                        {
                            foreach (var message in folder.AssociatedMessages)
                            {
                                Assert.IsNotNull(message);
                                var subject = message.Subject;

                                //Assert.IsTrue(!string.IsNullOrEmpty(subject), "Message.Subject returned an empty value.");
                                Console.WriteLine("    Node: {0}, Subject: {1}", message.Node.Value, subject);
                                countMessages++;
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(25, countFolders, "Expected 25 folders, but actually iterated over " + countFolders + " folders.");
            Assert.AreEqual(0, countMessages, "Expected 0 messages, but actually iterated over " + countMessages + " messages.");
        }

        [TestMethod]
        public void Folder_Messages_Attachments()
        {
            int countFolders = 0;
            int countMessages = 0;
            int countAttachments = 0;
            foreach (var testFile in testData)
            {
                Assert.IsTrue(testFile.Exists, "Test file " + testFile.Name + " cannot be found, so test cannot succeed.");

                Console.WriteLine("File: {0}", testFile.Name);

                using (var pst = new Pst(testFile.FullName))
                {
                    //var name = pst.Name;
                    Assert.IsNotNull(pst);

                    Queue<IFolder> folders = new Queue<IFolder>();
                    foreach (var folder in pst.Folders)
                        folders.Enqueue(folder);

                    while (folders.Count > 0)
                    {
                        var folder = folders.Dequeue();

                        Assert.IsNotNull(folder);
                        var name = folder.Name;
                        var subFolderCount = folder.SubFolderCount;

                        Console.WriteLine("  Node: {0}, Name: {1}, Count: {2}", folder.Node.Value, name, subFolderCount);
                        countFolders++;

                        if (folder.MessageCount > 0)
                        {
                            Queue<IMessage> messages = new Queue<IMessage>();
                            foreach (var message in folder.Messages)
                                messages.Enqueue(message);

                            countMessages += messages.Count;

                            while(messages.Count > 0)
                            {
                                var message = messages.Dequeue();
                            
                                Assert.IsNotNull(message);
                                var subject = message.Subject;

                                //Assert.IsTrue(!string.IsNullOrEmpty(subject), "Message.Subject returned an empty value.");
                                Console.WriteLine("    Node: {0}, Subject: {1}", message.Node.Value, subject);
                                //countMessages++;

                                if(message.AttachmentCount > 0)
                                {
                                    foreach (var attachment in message.Attachments)
                                    {
                                        var contentSize = attachment.ContentSize;

                                        if (attachment.IsMessage)
                                        {
                                            var embeddedMessage = attachment.OpenAsMessage();
                                            messages.Enqueue(embeddedMessage);
                                            Console.WriteLine(
                                                "      Node: {0}, ContentSize: {1}, <Embedded-Message> '{2}'", attachment.Node.Value, contentSize, embeddedMessage.Subject);
                                        }
                                        else
                                        {
                                            var filename = attachment.Filename;
                                            Console.WriteLine(
                                                "      Node: {0}, ContentSize: {1}, Filename: {2}", attachment.Node.Value, contentSize, filename);
                                        }
                                        countAttachments++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(25, countFolders, "Expected 25 folders, but actually iterated over " + countFolders + " folders.");
            Assert.AreEqual(6, countMessages, "Expected 6 messages, but actually iterated over " + countMessages + " messages.");
            Assert.AreEqual(3, countAttachments, "Expected 3 attachments, but actually iterated over " + countAttachments + " attachments.");
        }

    }
}
