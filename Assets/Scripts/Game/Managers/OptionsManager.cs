using System;
using Lean.Gui;
using ShhhSilence.Base.Managers;
using ShhhSilence.Game.Controller;
using ShhhSilence.Menu.Behaviours;
using UnityEngine;

namespace ShhhSilence.Game.Managers
{
    public class OptionsManager : BaseManager<PointManager>
    {
        [SerializeField]
        PlayerControlsProvider playerControlsProvider;

        [SerializeField]
        GameObject mainMenuObject;

        [SerializeField]
        LeanToggle muteToggle;

        [SerializeField]
        Pause pause;

        private bool active;

        private void Start()
        {
            InitializeMainMenuObject();
            InitializePauseOnActive();
            InitializeMuteOption();
        }

        private void InitializeMainMenuObject()
        {
            mainMenuObject.SetActive(active);
        }

        private void InitializePauseOnActive()
        {
            pause = this.gameObject.AddComponent<Pause>();
            pause.Switch(active);
        }

        private void Update()
        {
            if (Input.GetButtonDown(playerControlsProvider.MainMenuButton))
            {
                active = !active;
                mainMenuObject.SetActive(active);
                pause.Switch(active);
                HandleCursor(active);
            }
        }

        private void HandleCursor(bool active)
        {
            playerControlsProvider.ShowCursor(active);
            if (active)
            {
                playerControlsProvider.SetCursorLockState(CursorLockMode.Confined);
            }
            else
            {
                playerControlsProvider.SetCursorLockState(CursorLockMode.Locked);
            }
        }

        private void InitializeMuteOption()
        {
            muteToggle.OnOn.AddListener(MuteOn);
            muteToggle.OnOff.AddListener(MuteOff);
            muteToggle.On = AudioManager.Instance.Muted;
        }

        private void MuteOn()
        {
            AudioManager.Instance.MuteRequest(true);
        }

        private void MuteOff()
        {
            AudioManager.Instance.MuteRequest(false);
        }
    }
}