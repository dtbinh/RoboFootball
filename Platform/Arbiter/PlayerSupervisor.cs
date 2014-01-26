using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Arbiter
{
    //public class PlayerSupervisorService
    //{
    //    private PlayerSupervisorService();

    //    PlayerSupervisorService instance = null;

    //    private IList<PlayerSupervisor> supervisors;

    //    public IEnumerable<PlayerSupervisor> Supervisors
    //    {
    //        get
    //        {
    //            return supervisors
    //                   .Select(s => s.Clone())
    //                   .Cast<PlayerSupervisor>();
    //        }
    //        private set { Supervisors = new List<PlayerSupervisor>(); }
    //    }

    //    public PlayerSupervisorService Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //                instance = new PlayerSupervisorService();
    //            return instance;
    //        }
    //    }

    //    public class PlayerSupervisor : ICloneable
    //    {
    //        ConfigurationSvc.PlayerData playerData;
    //        ObserverSvc.PhysicInfo currentPhysicInfo;
    //        public bool IsSuspended { get; set; }
    //        public bool IsRun { get; set; }
    //        Thread thread;

    //        protected PlayerSupervisor(ConfigurationSvc.PlayerData player)
    //        {
    //            if (player == null) throw new ArgumentException("Player data should not be null");
    //            this.playerData = player;
    //            IsRun = true;
    //            IsSuspended = false;
    //            thread = new Thread(this.CheckRules);
    //            thread.Start();
    //        }

    //        private PlayerSupervisor()
    //        { 
    //        }

    //        public void CheckRules()
    //        {
    //            while (IsRun)
    //            {
    //                if (IsSuspended) continue;
    //                //checking logic
    //            }
    //        }

    //        public override bool Equals(object obj)
    //        {
    //            if (obj.GetType() != typeof(PlayerSupervisor)) return false;
    //            var ouetrSupervisor = (PlayerSupervisor)obj;
    //            return this.playerData.Id.Equals(ouetrSupervisor.playerData.Id);
    //        }

    //        public override int GetHashCode()
    //        {
    //            return playerData.Id.GetHashCode();
    //        }


    //        public object Clone()
    //        {
    //            return new PlayerSupervisor
    //            {
    //                playerData = this.playerData,
    //                currentPhysicInfo = this.currentPhysicInfo,
    //                IsSuspended = this.IsSuspended,
    //                IsRun = this.IsRun
    //            };
    //        }
    //    }

    //    public void SupervisorFactory(ConfigurationSvc.GameMembership mem)
    //    {
    //        foreach (var team in mem.Teams)
    //        {
    //            foreach (var player in team.Players)
    //            {
    //                var supervisor = new PlayerSupervisor(player);
    //                if (supervisors.Contains(supervisor))
    //                    supervisors.Add(supervisor);
    //            }
    //        }
    //    }

    //    public static bool ActivateSupervisors(System.Collections.Generic.IEnumerable<PlayerSupervisor> supervisorsToActivate)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public static bool DisactivateSupervisors(System.Collections.Generic.IEnumerable<PlayerSupervisor> supervisorsToDisactivate)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public static bool SuspendSupervisors(System.Collections.Generic.IEnumerable<PlayerSupervisor> supervisorsToActivate)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public static bool StartSupervisors(System.Collections.Generic.IEnumerable<PlayerSupervisor> supervisorsToActivate)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}


    public class SupervisorsService
    {
        private static Func<ConfigurationSvc.PlayerData, Supervisor> SpervisorFactory;
        
        public class Supervisor
        {
            ConfigurationSvc.PlayerData playerData;
             ObserverSvc.PhysicInfo currentPhysicInfo;
             public bool IsSuspended { get; set; }
             public bool IsRun { get; set; }
             Thread thread;


            internal static void Initialize()
            {
                SupervisorsService.SpervisorFactory = CreateSupervisor;
            }
            private static Supervisor CreateSupervisor(ConfigurationSvc.PlayerData player)
            {
                if (player == null) throw new ArgumentException("Player data should not be null");
                return new Supervisor(player);
            }
            
            private Supervisor(ConfigurationSvc.PlayerData player)
             {
                 this.playerData = player;
                 IsRun = true;
                 IsSuspended = false;
                 thread = new Thread(this.CheckRules);
                 thread.Start();
             }

             public void CheckRules()
             {
                 while (IsRun)
                 {
                     if (IsSuspended) continue;
                     //checking logic
                 }
             }

             public override bool Equals(object obj)
             {
                 if (obj.GetType() != typeof(Supervisor)) return false;
                 var ouetrSupervisor = (Supervisor)obj;
                 return this.playerData.Id.Equals(ouetrSupervisor.playerData.Id);
             }

             public override int GetHashCode()
             {
                 return playerData.Id.GetHashCode();
             }
        }

        static SupervisorsService()
        {
            Supervisor.Initialize();
        }

        static Supervisor CreateSupervisor(ConfigurationSvc.PlayerData player)
        {
            return SpervisorFactory(value);
        }

    }
}