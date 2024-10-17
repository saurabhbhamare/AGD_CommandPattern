using UnityEngine;
using Command.Utilities;
using Command.Sound;
using System.Collections.Generic;
using Command.Input;
using Command.Player;
using Command.UI;
using Command.Events;
using Command.Battle;
using Command.Actions;
using UnityEngine.UI;
using Command.Commands;
using Command.Replay;

namespace Command.Main
{

    public class GameService : GenericMonoSingleton<GameService>
    {
      
        public EventService EventService { get; private set; }
        public SoundService SoundService { get; private set; }
        public ActionService ActionService { get; private set; }
        public InputService InputService { get; private set; }
        public BattleService BattleService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public ReplayService ReplayService { get; private set; }
        public CommandInvoker CommandInvoker { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;


        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private List<BattleScriptableObject> battleScriptableObjects;

        // Scene References:
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource bgMusicSource;

        private void Start()
        {
            SoundService = new SoundService(soundScriptableObject, sfxSource, bgMusicSource);
            EventService = new EventService();
            ActionService = new ActionService();
            InputService = new InputService();
            BattleService = new BattleService(battleScriptableObjects);
            PlayerService = new PlayerService();
            ReplayService = new ReplayService();
            uiService.Init(battleScriptableObjects.Count);
            CommandInvoker = new CommandInvoker();
        }

        private void Update() => InputService.UpdateInputService();

        public void ProcessUnitCommand(ICommand commandToProcess) => PlayerService.ProcessUnitCommand(commandToProcess as UnitCommand);
    }
}