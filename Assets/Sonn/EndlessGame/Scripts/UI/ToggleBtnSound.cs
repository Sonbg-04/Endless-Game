using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class ToggleBtnSound : ToggleButton
    {
        protected override void Start()
        {
            base.Start();
            m_isOn = Pref.GetBool(GamePref.IsSoundOn.ToString(), true);
            UpdateSprite();
        }

        public override void ClickEvent()
        {
            m_isOn = !m_isOn;
            Pref.SetBool(GamePref.IsSoundOn.ToString(), m_isOn);
            if (AudioManager.Ins == null)
            {
                return;
            }    
            AudioManager.Ins.bonusSource.mute = !m_isOn;
            AudioManager.Ins.btnClickSource.mute = !m_isOn;
            AudioManager.Ins.gameOverSource.mute = !m_isOn;
            AudioManager.Ins.jumpSource.mute = !m_isOn;
            AudioManager.Ins.landSource.mute = !m_isOn;
            AudioManager.Ins.newBestScoreSource.mute = !m_isOn;
            AudioManager.Ins.scoreSource.mute = !m_isOn;

        }
    }
}
