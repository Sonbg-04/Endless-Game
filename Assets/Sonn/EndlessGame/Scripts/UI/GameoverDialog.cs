using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sonn.EndlessGame
{
    public class GameoverDialog : Dialog
    {
        public Text scoreTxt, bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            if (scoreTxt)
            {
                scoreTxt.text = GameManager.Ins.Score.ToString();
            }    
            if (Pref.hasBestScore)
            {
                if (bestScoreTxt)
                {
                    bestScoreTxt.text = $"NEW BEST: {Pref.bestScore}";
                }    
            }
            else
            {
                if (bestScoreTxt)
                {
                    bestScoreTxt.text = $"TOP SCORE: {Pref.bestScore}";
                }    
            }    
        }

        public void BackToHome()
        {
            CloseDialog();
            SceneManager.LoadScene(GameScene.MainMenu.ToString());
        }    
        public void Replay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
    }
}
