using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class LevelManager : MonoBehaviour, ISingleton
    {
        public static LevelManager Ins;
        public LevelItem[] levels;

        private void Awake()
        {
            MakeSingleton();
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            if (levels == null || levels.Length <= 0)
            {
                return;
            }    
            for (int i = 0; i < levels.Length; i++)
            {
                var level = levels[i];
                if (level == null)
                {
                    continue;
                } 
                string levelDatakey = GamePref.LevelUnlocked.ToString() + i;

                if (i == 0)
                {
                    // Mở khóa level đầu tiên
                    Pref.SetLevelUnlocked(i, true);
                }
                else
                {
                    // Nếu dữ liệu chưa được lưu xuống máy người chơi thì 
                    // sẽ lưu dữ liệu (khóa các level khác lại)
                    if (!PlayerPrefs.HasKey(levelDatakey))
                    {
                        Pref.SetLevelUnlocked(i, false);
                    }
                }    

            }    
        }    

        public LevelItem GetLevel()
        {
            if (levels != null && levels.Length > 0)
            {
                return levels[Pref.CurrentLevel_ID];
            }    
            return null;
        }    

        public void MakeSingleton()
        {
            if (Ins == null)
            {
                Ins = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
