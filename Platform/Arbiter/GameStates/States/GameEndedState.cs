using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{
    public class GameEndedState : IGameState
    {
        public void goNext(GameContext context)
        {
            disactivateRobots(context.gameProperties);
            KillAllSupervisors(context.gameProperties);
            StateService.Instance.SetStateTo<NotAGameState>(context);
        }

        public string Description
        {
            get
            {
                return "The game process has been ended. " +
                        "All supervisors are dead. " +
                        "Timers are stopped. " +
                        "Players are dead. " +
                        "Wait for the administrator to quit game process.";
            }
        }

        void disactivateRobots(GameProperties gameProperties)
        {
            var robots = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players.Select(x => x.RobotData));
            foreach (var robot in robots)
            {
                robot.IsActive = false;
                throw new NotImplementedException("here we should call robot with communication service with special code");
            }
        }

        void KillAllSupervisors(GameProperties gameProperties)
        {
            var sups = gameProperties.
                          Membership.GetMembership()
                          .Teams.SelectMany(x => x.Players)
                          .Select(p=>SupervisorsService
                          .Instance
                          .GetSupervisorFor(p));
               SupervisorsService.Instance.KillSupervisors(sups);
        }


    }
}