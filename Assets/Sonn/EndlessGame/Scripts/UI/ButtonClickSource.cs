using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sonn.EndlessGame
{
    public class ButtonClickSource : MonoBehaviour
    {
        private Button m_btn;

        private void Awake()
        {
            m_btn = GetComponent<Button>();
        }

        void Start()
        {
            if (m_btn == null)
            {
                return;
            }    
            m_btn.onClick.AddListener(() => PlaySoundEvent());

        }
        private void PlaySoundEvent()
        {
            if (AudioManager.Ins == null)
            {
                return;
            }    
            AudioManager.Ins.PlaySoundOneShots(AudioManager.Ins.btnClickSource);
        }    
    }
}
