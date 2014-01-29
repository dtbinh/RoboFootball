using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arbiter.CommunicationSvc;
using Arbiter.ConfigurationSvc;
using Arbiter.LoggerSvc;
using Arbiter.States;
using Moq;
using NUnit.Framework;
using PlayerData = Arbiter.ConfigurationSvc.PlayerData;

namespace Arbiter.Test
{
    [TestFixture]
    class GameContextTests
    {
        private Mock<IMembershipManager> membershipManager;
        private Mock<ITimingManager> timingManager;
        private Mock<INotificationManager> notificationManager;
        private Mock<ILogManager> logManager;
        private Mock<ICommandManager> commandManager;
        private TimeContext timeContext;
        private GameContext gameContext;
        private GameProperties gameProperties;

        [SetUp]
        public void Init()
        {
            membershipManager = new Mock<IMembershipManager>();
            timingManager = new Mock<ITimingManager>();
            notificationManager = new Mock<INotificationManager>();
            logManager = new Mock<ILogManager>();
            commandManager = new Mock<ICommandManager>();

            gameProperties = new GameProperties(membershipManager.Object,
                                                timingManager.Object,
                                                notificationManager.Object,
                                                logManager.Object
                                                ,commandManager.Object);

        }

        [Test]
        public void SimpleRun()
        {
            var gametimings = new GameTimings();
            gametimings.TimeCount = 3;
            gametimings.TimeLength = new TimeSpan(0, 0, 0, 10);
            gametimings.TimeOutLength = new TimeSpan(0, 0, 0, 3);
            timingManager.Setup(p => p.GetGameTimings()).Returns(gametimings);

            var membership = new GameMembership
            {
                TeamCount = 1,
                Teams = new List<TeamMembership> 
                { new TeamMembership
                  {
                      TeamName = "Team1",
                      TeamId = 10,
                      PlayerCount = 1,
                      Players = new List<PlayerData> 
                      { new PlayerData()
                        {
                            Name = "Player",
                            Id = 1,
                            TeamId = 10,
                            RobotData = new RobotData
                                        {
                                            IsActive = false,
                                            MachineId = 1,
                                            Width = 10,
                                            Length = 10,
                                            MarkerPositionX = 2,
                                            MarkerPositionY = 3,
                                            Marker = new Color { r = 100, g = 100, b = 100 }
                                        }
                        } },
                      ControlCenterCount = 0,
                      ControlCenters = new List<ConfigurationSvc.ControllCenterData>(),
                      GateId = 0
                  } }
            };

            membershipManager.Setup(m => m.GetMembership()).Returns(membership);

            timeContext = new TimeContext(gameProperties);
            gameContext = new GameContext(timeContext);

            gameContext.GoNext();
            var currentGameState = gameContext.CurrentGameState;
            var currentTimeState = timeContext.CurrentTimeState;
            var currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;

            gameContext.GoNext();
            currentGameState = gameContext.CurrentGameState;
            currentTimeState = timeContext.CurrentTimeState;
            currentTime = timeContext.CurrentTime;
        }
    }
}
