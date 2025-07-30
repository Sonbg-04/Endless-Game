using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class Menu : MonoBehaviour
    {
        void Start()
        {
            if (AudioManager.Ins == null)
            {
                return;
            }
            bool isMusicOn = Pref.GetBool(GamePref.IsMusicOn.ToString(), true);
            if (AudioManager.Ins.menuSource ||
                AudioManager.Ins.backgroundSource)
            {
                AudioManager.Ins.menuSource.mute = !isMusicOn;
                AudioManager.Ins.backgroundSource.mute = !isMusicOn;
            }

            bool isSFXOn = Pref.GetBool(GamePref.IsSoundOn.ToString(), true);
            if (AudioManager.Ins.bonusSource ||
                AudioManager.Ins.btnClickSource ||
                AudioManager.Ins.gameOverSource ||
                AudioManager.Ins.jumpSource ||
                AudioManager.Ins.landSource ||
                AudioManager.Ins.newBestScoreSource ||
                AudioManager.Ins.scoreSource)
            {
                AudioManager.Ins.bonusSource.mute = !isSFXOn;
                AudioManager.Ins.btnClickSource.mute = !isSFXOn;
                AudioManager.Ins.gameOverSource.mute = !isSFXOn;
                AudioManager.Ins.jumpSource.mute = !isSFXOn;
                AudioManager.Ins.landSource.mute = !isSFXOn;
                AudioManager.Ins.newBestScoreSource.mute = !isSFXOn;
                AudioManager.Ins.scoreSource.mute = !isSFXOn;
            }
            AudioManager.Ins.PlayMusic(AudioManager.Ins.menuSource);
        }
    }
}
