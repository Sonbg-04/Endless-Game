using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sonn.EndlessGame
{
    public class LevelItemUI : MonoBehaviour
    {
        public Text scoreRequireTxt;
        public Image lockThumb, unlockThumb;
        public Button btn;

        public void UpdateUI(LevelItem lv, int levelIndex)
        {
            if (lv == null) return;

            bool isUnlocked = Pref.IsLevelUnlocked(levelIndex);
            if (lockThumb)
            {
                lockThumb.gameObject.SetActive(!isUnlocked);
            }    
            if (unlockThumb)
            {
                unlockThumb.gameObject.SetActive(isUnlocked);
            }

            if (isUnlocked)
            {
                if (unlockThumb)
                {
                    unlockThumb.sprite = lv.unlockThumb;
                }    
            }
            else
            {
                if (scoreRequireTxt)
                {
                    scoreRequireTxt.text = lv.scoreRequire.ToString();
                }    
                if (lockThumb)
                {
                    lockThumb.sprite = lv.lockThumb;
                }
            }    
        }    

    }
}
