using Arbiter.ConfigurationSvc;
using Arbiter.LoggerSvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbiter.Test
{
    [TestFixture]
    public class OrderClientTests2
    {
        Mock<IStatusMessageLogger> statusMessageLogger;
        Mock<ITimingManager> timingManager;
        Mock<IMembershipManager> membershipManager;
        [SetUp]
        public void Setup()
        {
            statusMessageLogger = new Mock<IStatusMessageLogger>();
            timingManager = new Mock<ITimingManager>();
            membershipManager = new Mock<IMembershipManager>();
        }

        [Test]
        public void GetOrderTest()
        {
            var m = membershipManager.Object;
            var client = new GameProcessManager(membershipManager.Object, 
                                                timingManager.Object, 
                                                statusMessageLogger.Object);
            
        }
    }
}
