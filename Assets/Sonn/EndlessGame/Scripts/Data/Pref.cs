using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public static class Pref
    {
        public static bool hasBestScore;


        public static int bestScore
        {
            get => PlayerPrefs.GetInt(GamePref.BestScore.ToString());
            set
            {
                int oldScore = PlayerPrefs.GetInt(GamePref.BestScore.ToString(), 0);
                if (oldScore < value)
                {
                    hasBestScore = true;
                    PlayerPrefs.SetInt(GamePref.BestScore.ToString(), value);
                }
                else
                {
                    hasBestScore = false;
                }
            }
        }

        public static int CurrentLevel_ID
        {
            set => PlayerPrefs.SetInt(GamePref.CurrentLevelID.ToString(), value);
            get => PlayerPrefs.GetInt(GamePref.CurrentLevelID.ToString(), 0);
        }

        public static void SetLevelUnlocked(int lvId, bool unlocked)
        {
            SetBool(GamePref.LevelUnlocked.ToString() + lvId, unlocked);
        }

        public static bool IsLevelUnlocked(int lvId)
        {
            return GetBool(GamePref.LevelUnlocked.ToString() + lvId);
        }

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            return PlayerPrefs.HasKey(key)
                ? PlayerPrefs.GetInt(key) == 1 ? true : false
                : defaultValue;
        }
    }

}
