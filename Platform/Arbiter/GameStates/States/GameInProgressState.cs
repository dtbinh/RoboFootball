﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arbiter.CommunicationSvc;

namespace Arbiter.States
{
    public class GameInProgressState : IGameState
    {
        public void goNext(GameContext context)
        {
            var robotsAreReady = PrepareRobots(context.GameProperties);

            var timeLimboState = StateService.Instance.State<TimeLimboState>();

            if (context.TimeContext.CurrentTimeState.Equals(timeLimboState))
                StateService.Instance.SetStateTo<GameEndedState>(context);
            else
            {
                StateService.Instance.SetStateTo<GameInProgressState>(context);
                context.TimeContext.GoNext();
            }
        }

        public string Description
        {
            get
            {
                return "The game process has been started. " +
                        "All supervisors are alive but not active. " +
                        "Timers are started. " +
                        "Players are active. " +
                        "Wait for the administrator to start first time.";
            }
        }

        private bool PrepareRobots(GameProperties gameProperties)
        {
            var robots = gameProperties.Membership.GetMembership().Teams.SelectMany(t => t.Players.Select(p => p.RobotData));
            if (!robots.Any(r => !r.IsActive)) return true;
            foreach (var robot in robots)
            {
                robot.IsActive = true;
                //TODO:Here should be call to Communication module with special 
                //TODO:activation code for robot with special id! 
                //TODO:only in a case if robto is activated returned true!!"
                return gameProperties.Commander.AddCommand(new Command(/*Robot with id .. ACTIVATE!!*/));
                return gameProperties.Commander.AddCommand(new Command(/*Robot with id .. Are you activated?*/));
            }
            return false;
        }
    }
}