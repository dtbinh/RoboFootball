using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arbiter.CommunicationSvc;

namespace Arbiter.States
{
    public class GameEndedState : IGameState
    {
        public void goNext(GameContext context)
        {
            disactivateRobots(context.GameProperties);
            KillAllSupervisors(context.GameProperties);
           // StateService.Instance.SetStateTo<NotAGameState>(context);
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

        bool disactivateRobots(GameProperties gameProperties)
        {
            var robots = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players.Select(x => x.RobotData));
            foreach (var robot in robots)
            {
                robot.IsActive = false;

                //TODO:Here should be call to Communication module with special 
                //TODO:disactivation code for robot with special id! 
                //TODO:only in a case if robto is disactivates returned true!!"
                return gameProperties.Commander.AddCommand(new Command(/*Robot with id .. DISACTIVATE!!*/));
                return gameProperties.Commander.AddCommand(new Command(/*Robot with id .. Are you DISactivated?*/));

            }

            return true;
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