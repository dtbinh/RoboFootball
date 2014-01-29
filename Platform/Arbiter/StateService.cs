using System;
using System.Collections.Generic;

namespace Arbiter.States
{

    public class StateService
    {
        private static StateService instance;

        public static StateService Instance
        {
            get
            {
                if (Instance == null) { instance = new StateService(); } 
            return instance; 
            } 
        }

        IDictionary<Type, object> states ;
        
        private StateService()
        {
            states = new Dictionary<Type, object>{
                {typeof(NotAGameState),Singleton<NotAGameState>.Instance},
                {typeof(GameInProgressState),Singleton<GameInProgressState>.Instance},
                {typeof(GameEndedState),Singleton<GameEndedState>.Instance},
                {typeof(GamePreparationState),Singleton<GamePreparationState>.Instance},

                {typeof(NotATimeState),Singleton<NotATimeState>.Instance},
                {typeof(TimeInProgressState),Singleton<TimeInProgressState>.Instance},
                {typeof(TimeEndedState),Singleton<TimeEndedState>.Instance},
                {typeof(TimeLimboState),Singleton<TimeLimboState>.Instance},
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