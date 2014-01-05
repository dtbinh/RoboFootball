using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Timers;
using Arbiter;
using Timer = System.Timers.Timer;


namespace Arbiter
{
    /// <summary>
    /// Сервис управляет процессом игры
    /// Существует в единственном числе. 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbitrageService : IGameManager
    {
        //Субарбитры
        public IList<SubArbiter> SubArbiters = new List<SubArbiter>();

        //Proxy для Communication service. 
        private readonly OperationClient operationClient;
        // Момент времени начала старта игры
        public DateTime DateOfStart { get; private set; }
        //Количество таймов
        private int timeCount;
        //Длительность тайма
        private int timeLength;
        //Таймаут
        private int timeOut;
        //Таймер игры
        private readonly Timer timer;

        //Конструктор
        public ArbitrageService()
        {
            //Proxy для Communication service.
            operationClient = new OperationClient();
            //Чтение параметров конфигурационных файлов
            ReadParams();
            //Создание таймеров игры
            timer = new Timer
            {
                Interval = timeLength, // период, через который вызывается окончание тайма  
                Enabled = true
            };
            timer.Elapsed += StopTime; // делегат для события окончания раунда
            SubArbiters.Add(new SubArbiter(For.Ball(), this)); // создание наблюдателя для мяча
        }
        /// <summary>
        /// Чтение конфигурационных файлов игры с помощью сервиса Configuration
        /// </summary>
        private void ReadParams()
        {
            // Получение proxy для Configuration  
            var gameTimings = new ConfigurationSR.TimingSetupClient();
            // Получение количества таймов
            timeCount = gameTimings.GetGameTimings().RoundsQuantity;
            //Получение длительности таймов
            timeLength = gameTimings.GetGameTimings().RoundTime.Millisecond;
            // Получение длительности ттайм-аута
            timeOut = gameTimings.GetGameTimings().TimeOut;
            //Получение момент аначала игры
            DateOfStart = gameTimings.GetGameTimings().StartTime;
            //Получение количества команд
            var teamsCount = (new ConfigurationSR.TeamsSetupClient()).GetTeamsStructure().TeamsCount;
            SubArbiters = new List<SubArbiter>(teamsCount);
        }

        #region Implementation of IGameProcess
        /// <summary>
        /// Начало игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        public void StartGame(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            // Отключение коммуникаций
            operationClient.Disable(new DisableRequest());
            // Для каждого из команд назначается субарбитр 
            foreach (var subArbiter in SubArbiters)
                (new Thread(subArbiter.CheckRules)).Start();
            //начало тайма (открытие коммуникаций)
            StartTime();

        }
        /// <summary>
        /// Окончание игры и сворачивание всех приложений
        /// </summary>
        private void StopGame()
        {
            //отключение всех коммуникаций
            operationClient.Disable(new DisableRequest());
            //сворачивание всех субарбитров
            foreach (var subArbitr in SubArbiters)
            {
                subArbitr.RequestStop();
            }
        }
        /// <summary>
        /// Начало тайма
        /// </summary>
        private void StartTime()
        {
            //запусктаймера игры
            timer.Start();
            //открытие всех коммуникаций
            operationClient.Enable(new EnableRequest());
        }
        /// <summary>
        /// Окончание тайма. Данный метод вызывается по окончании времени тайма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        private void StopTime(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            //Если таймов больше не осталось- окончание игры
            if (--timeCount == 0)
                StopGame();
            //На время окончания таймаута - все коммуникации запрещены
            operationClient.Disable(new DisableRequest());
            // таймаут
            Thread.Sleep(timeOut);
            //начало нового тайма
            StartTime();
        }
        public void Continue()
        {
            operationClient.Enable(new EnableRequest());
            timer.Start();
        }
        public void Pause()
        {
            operationClient.Disable(new DisableRequest());
            timer.Start();
        }
        #endregion

        #region Implementation of IGameManager
        /// <summary>
        /// Пользователь сообщает сервису что его команда готова к игре
        /// Вызывая этот метод
        /// </summary>
        /// <param name="id"> id команды</param>
        public void TeamReady(Guid id)
        {
            //развертка команды
            var registrator = new RegistratorClient(); //получение proxy для Registrator
            if (registrator.IsTeamRegisteredById(id)) // проверка, зарегистрирована ли данная команда
            {
                var deploying = new DeployingSR.DeployingClient();// получение proxy для Deploying
                deploying.Deploy(id); // развертка
            }

            SubArbiters.Add(new SubArbiter(For.Team(id), this)); // создание нового субарбитра для этой команды. 
        }
        #endregion
    }
}