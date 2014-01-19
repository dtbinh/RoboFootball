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
            membershipManager = new Mock<IMembershipManager>();
        }

        [Test]
        public void StatusCallTest()
        {
            var client = new GameProvider(membershipManager.Object,
                                                timingManager.Object,
                                                statusMessageLogger.Object);
            client.StartGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
        }

        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void StartBeforeDateOfStart()
        {
            var gametimings = new GameTimings();
            var datetimenow = DateTime.Now.AddDays(-10);
            gametimings.GameStartDate = datetimenow;
            timingManager.Setup(p => p.GetGameTimings()).Returns(gametimings);

            var client = new GameProvider(membershipManager.Object,
                                    timingManager.Object,
                                    statusMessageLogger.Object);
            client.StartGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void StartAfterDateOfStart()
        {
            var gametimings = new GameTimings();
            var datetimenow = DateTime.Now.AddDays(10);
            gametimings.GameStartDate = datetimenow;
            timingManager.Setup(p => p.GetGameTimings()).Returns(gametimings);

            var client = new GameProvider(membershipManager.Object,
                                    timingManager.Object,
                                    statusMessageLogger.Object);
            client.StartGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
            timingManager.Verify(t => t.GetGameTimings());
            membershipManager.Verify(m => m.GetMembership());
            client.EndGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
        }

        [Test]
        public void StartWithOneTeam()
        {
            var gametimings = new GameTimings();
            var datetimenow = DateTime.Now.AddDays(10);
            gametimings.GameStartDate = datetimenow;
            timingManager.Setup(p => p.GetGameTimings()).Returns(gametimings);

            var player = new Arbiter.ConfigurationSvc.PlayerData()
            {
                Name = "Player",
                MachineId = 1,
                Width = 10,
                Length = 10,
                MarkerPositionX = 2,
                MarkerPositionY = 3,
                Marker = new Color { r = 100, g = 100, b = 100 }
            };
            var team = new TeamMembership
            {
                TeamName = "Team1",

                TeamId = 10,
                PlayerCount = 1,
                Players = new List<Arbiter.ConfigurationSvc.PlayerData> { player },
                ControlCenterCount = 0,
                ControlCenters = new List<Arbiter.ConfigurationSvc.ControllCenterData>(),
                GateId = 0
            };

            var membership = new GameMembership
            {
                TeamCount = 1,
                Teams = new List<TeamMembership> { team }
            };

            membershipManager.Setup(m => m.GetMembership()).Returns(membership);

            var client = new GameProvider(membershipManager.Object,
                                    timingManager.Object,
                                    statusMessageLogger.Object);
            client.StartGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
            timingManager.Verify(t => t.GetGameTimings());
            membershipManager.Verify(m => m.GetMembership());
            client.EndGame();
            statusMessageLogger.Verify(m => m.ShowStatusMessage(It.IsAny<string>()));
        }

        [Test]
        public void PlayerSupervisorsFactoryTest()
        {

            var player = new Arbiter.ConfigurationSvc.PlayerData()
            {
            };
            var team = new TeamMembership
            {
                Players = new List<Arbiter.ConfigurationSvc.PlayerData> { player },
            };

            var membership = new GameMembership
            {
                Teams = new List<TeamMembership> { team }
            };

            membershipManager.Setup(m => m.GetMembership()).Returns(membership);

            var client = new GameProvider(membershipManager.Object,
                                    timingManager.Object,
                                    statusMessageLogger.Object);
            var spv = client.SupervisorFactory(membership);
            Assert.That(spv, Is.Not.Null,"Collection of returned supervisors is null");
            Assert.That(spv, Is.Not.Empty,"Collection of returned supervisors is empty");
            Assert.That(spv.Count(), Is.EqualTo(1), "Collection of supervisors contains more than 1 supervisor");
            var supervisor = spv.ToArray()[0];
        }

        [Test]
        public void SupervisorThreadFactoryTest()
        {
            var player = new Arbiter.ConfigurationSvc.PlayerData();
            var supervisor = new PlayerSupervisor(player);
            var client = new GameProvider(membershipManager.Object,
                                    timingManager.Object,
                                    statusMessageLogger.Object);
            var threads = client.SupervisorThreadFactory(new List<PlayerSupervisor> { supervisor });
            Assert.That(threads, Is.Not.Null, "Collection of returned threads is null");
            Assert.That(threads, Is.Not.Empty, "Collection of returned threads is empty");
            Assert.That(threads.Count(), Is.EqualTo(1), "Collection of threads contains more than 1 supervisor");
        }

    }
}
