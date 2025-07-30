using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class ToggleBtnMusic : ToggleButton
    {
        protected override void Start()
        {
            base.Start();
            m_isOn = Pref.GetBool(GamePref.IsMusicOn.ToString(), true);
            UpdateSprite();
        }

        public override void ClickEvent()
        {
            m_isOn = !m_isOn;
            Pref.SetBool(GamePref.IsMusicOn.ToString(), m_isOn);
            if (AudioManager.Ins == null)
            {
                return;
            }
            AudioManager.Ins.backgroundSource.mute = !m_isOn;
            AudioManager.Ins.menuSource.mute = !m_isOn;
        }
    }
}
