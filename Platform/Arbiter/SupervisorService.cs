using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Arbiter
{
    public class SupervisorsService
    {
        private static SupervisorsService instance;
        public static SupervisorsService Instance
        {
            get { return instance ?? (instance = new SupervisorsService()); }
        }


        private static Func<ConfigurationSvc.PlayerData, Supervisor> SpervisorFactory;
        private ObjectContainer<ConfigurationSvc.PlayerData, Supervisor> supervisors;

        public class Supervisor
        {
            ConfigurationSvc.PlayerData playerData;
            //ObserverSvc.PhysicInfo currentPhysicInfo;
            public bool IsSuspended { get; set; }
            public bool IsAlive { get; set; }
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
                IsAlive = true;
                IsSuspended = true;
                thread = new Thread(this.CheckRules);
                thread.Start();
            }

            public void CheckRules()
            {
                while (IsAlive)
                {
                    if (IsSuspended) continue;
                    //var acc=currentPhysicInfo.Acceleration;
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
            this.supervisors =
            new ObjectContainer<ConfigurationSvc.PlayerData, Supervisor>(CreateSupervisor);
        }

        private Supervisor CreateSupervisor(ConfigurationSvc.PlayerData player)
        {
            return SpervisorFactory(player);
        }

        public Supervisor GetSupervisorFor(ConfigurationSvc.PlayerData player)
        {
            return supervisors.GetObjectFor<ConfigurationSvc.PlayerData>(player);
        }

        public IList<Supervisor> CreateSupervisorsFor(ConfigurationSvc.GameMembership mem)
        {
            return mem.Teams.SelectMany(t => t.Players.Select(p=>GetSupervisorFor(p))).ToList();
        }

        public void KillSupervisors(IEnumerable<Supervisor> SupervisorToKill)
        {
            foreach (var supervisor in SupervisorToKill)
            {
                supervisor.IsAlive = false;
                supervisors.RemoveObject(supervisor);
            }
        }

        public void SuspendSupervisors(IEnumerable<Supervisor> SupervisorToSuspend)
        {
            foreach (var supervisor in SupervisorToSuspend)
            {
                supervisor.IsSuspended = true;
            }
        }

        public void StartSupervisors(IEnumerable<Supervisor> supervisorsToStart)
        {
            foreach (var supervisor in supervisorsToStart)
            {
                supervisor.IsSuspended = false;
            }
        }
    }


    class ObjectContainer<I,T>
    {
        private readonly ISet<T> objects;
        private readonly Func<I, T> objectGenerator;

        public ObjectContainer(Func<I, T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            objects = new HashSet<T>();
            this.objectGenerator = objectGenerator;
        }

        public T GetObjectFor<TP>(TP param) where TP:I
        {
            var generated = objectGenerator(param);
            if (!objects.Contains(generated)) objects.Add(generated);
            return generated;
        }

        public bool RemoveObject(T item)
        {
            return objects.Remove(item);
        }

    }
}