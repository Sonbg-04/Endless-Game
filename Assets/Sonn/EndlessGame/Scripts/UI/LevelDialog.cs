using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sonn.EndlessGame
{
    public class LevelDialog : Dialog, IComponentChecking
    {
        public Transform gridRoot;
        public LevelItemUI itemUIPrefab;
        public Text bestScoreTxt;

        public bool IsComponentNull()
        {
            bool check = LevelManager.Ins == null || gridRoot == null || itemUIPrefab == null;
            if (check)
            {
                Debug.LogWarning("Có component bị rỗng. Vui lòng kiểm tra lại!");
            }    
            return check;
        }

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            if (bestScoreTxt)
            {
                bestScoreTxt.text = $"TOP SCORE: {Pref.bestScore}";
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            var level = LevelManager.Ins.levels;
            if (level == null || level.Length <= 0 || IsComponentNull())
            {
                return;
            }    
            Helper.ClearChilds(gridRoot);

            for (int i = 0; i < level.Length; i++)
            {
                int lvID = i;
                var lv = level[i];
                if (Pref.bestScore >= lv.scoreRequire)
                {
                    Pref.SetLevelUnlocked(lvID, true);
                }

                if (lv == null)
                {
                    continue;
                }    

                var lvUIclone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);
                lvUIclone.transform.SetParent(gridRoot);
                lvUIclone.transform.localPosition = Vector3.zero;
                lvUIclone.transform.localScale = Vector3.one;
                lvUIclone.UpdateUI(lv, lvID);
                
                if (lvUIclone.btn)
                {
                    lvUIclone.btn.onClick.RemoveAllListeners();
                    lvUIclone.btn.onClick.AddListener(() => LevelClickEvent(lv, lvID));
                }    
            }
        }    

        private void LevelClickEvent(LevelItem levelItem, int lvId)
        {
            if (levelItem == null)
            {
                return; 
            }

            bool isUnlocked = Pref.IsLevelUnlocked(lvId);
            if (isUnlocked)
            {
                Pref.CurrentLevel_ID = lvId;

                SceneManager.LoadScene(GameScene.GamePlay.ToString());
            }

        }    
    }

}
