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
    public class GameManagerTests
    {
        Mock<IStatusMessageLogger> statusMessageLogger;
        Mock<ITimingManager> timingManager;
        Mock<IMembershipManager> membershipManager;
        
        [SetUp]
        public void Setup()
        {
            statusMessageLogger = new Mock<IStatusMessageLogger>();
            timingManager = new Mock<ITimingManager>();
            var gametimings = new GameTimings();
            var datetimenow= DateTime.Now.AddMilliseconds(1000);
            gametimings.GameStartDate = datetimenow;
            timingManager.Setup(p=>p.GetGameTimings()).Returns(gametimings);
            membershipManager = new Mock<IMembershipManager>();
        }

        [Test]
        public void StatusCallTest()
        {
            var client = new GameProcessManager(membershipManager.Object, 
                                                timingManager.Object, 
                                                statusMessageLogger.Object);
            client.StartGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
        }
    }
}
