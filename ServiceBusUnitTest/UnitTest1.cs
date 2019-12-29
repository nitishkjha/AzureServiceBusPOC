using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceBusPOC;

namespace ServiceBusUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CallSender()
        {
            Sender.Send().GetAwaiter().GetResult();
        }

        [TestMethod]
        public void CallReceiver()
        {
            //Receiver.MainAsync().GetAwaiter().GetResult();
            Receiver.Main();
        }
    }
}
