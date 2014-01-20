using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbiter.States
{

    public class StateService
    {
        private static readonly StateService instance = new StateService();

        public static StateService Instance { get { return instance; } }

        IDictionary<Type, object> states ;
        
        private StateService()
        {
            states = new Dictionary<Type, object>{
                {typeof(NotAGameState),Singleton<NotAGameState>.Instance},
                {typeof(GameInProgressState),Singleton<GameInProgressState>.Instance},
                {typeof(GameEndedState),Singleton<GameEndedState>.Instance},
                {typeof(GamePreparedState),Singleton<GamePreparedState>.Instance},
                {typeof(GameSuspendedState),Singleton<GameSuspendedState>.Instance},

                {typeof(NotATimeState),Singleton<NotATimeState>.Instance},
                {typeof(TimeInProgressState),Singleton<TimeInProgressState>.Instance},
                {typeof(TimeEndedState),Singleton<TimeEndedState>.Instance},
                {typeof(TimeFinishState),Singleton<TimeFinishState>.Instance},
            };
        }

        public T State<T>() 
        {
            var state= (T)states[typeof(T)];
            if (state==null) throw new NullReferenceException("There is not registered state of type "+typeof(T).Name);
            return state; 
        }

        public void SetStateTo<S>(GameContext context) where S : IGameState
        {
            var state = State<S>();
            context.CurrentGameState = state;
        }

        public void SetStateTo<S>(TimeContext context) where S : ITimeState
        {
            var state = State<S>();
            context.CurrentTimeState = state;
        }
    }
}