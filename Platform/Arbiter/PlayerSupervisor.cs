using System;
using System.Collections.Concurrent;
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

    //    private IList<PlayerSupervisor> supervisorsPool;

    //    public IEnumerable<PlayerSupervisor> Supervisors
    //    {
    //        get
    //        {
    //            return supervisorsPool
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
    //                if (supervisorsPool.Contains(supervisor))
    //                    supervisorsPool.Add(supervisor);
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
        private static SupervisorsService instance;
        public static SupervisorsService Instance
        {
            get
            {
                if (Instance == null) { instance = new SupervisorsService(); }
                return instance;
            }
        }


        private static Func<ConfigurationSvc.PlayerData, Supervisor> SpervisorFactory;
        private ObjectPool<ConfigurationSvc.PlayerData, Supervisor> supervisorsPool;

        public class Supervisor
        {
             ConfigurationSvc.PlayerData playerData;
             ObserverSvc.PhysicInfo currentPhysicInfo;
             public bool IsSuspended { get; set; }
             public bool IsRun { get; set; }
             Thread thread;

            internal static void Initialize()
            {
                SupervisorsService.SpervisorFactory = SupervisorProducer;
            }
            private static Supervisor SupervisorProducer(ConfigurationSvc.PlayerData player)
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

        private SupervisorsService()
        {
            Supervisor.Initialize();
            this.supervisorsPool =
            new ObjectPool<ConfigurationSvc.PlayerData, Supervisor>(CreateSupervisor);
        }

        private Supervisor CreateSupervisor(ConfigurationSvc.PlayerData player)
        {
            return SpervisorFactory(player);
        }

        public Supervisor GetSupervisorFor(ConfigurationSvc.PlayerData player)
        {
            return supervisorsPool.GetObjectFor<ConfigurationSvc.PlayerData>(player);
        }
    }


    public class ObjectPool<I,T>
    {
        private ConcurrentBag<T> objects;
        private Func<I,T> objectGenerator;

        public ObjectPool(Func<I,T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            objects = new ConcurrentBag<T>();
            this.objectGenerator = objectGenerator;
        }

        public T GetObjectFor<I>(I param)
        {
            T item;
            if (objects.TryTake(out item)) return item;
            
            var generatedObject=objectGenerator(param);
            return generatedObject;
        }

        public void PutObject(T item)
        {
            objects.Add(item);
        }
    }
}