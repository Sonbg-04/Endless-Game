using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sonn.EndlessGame
{
    public class PauseDialog : Dialog
    {

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            Time.timeScale = 0f;
        }

        public override void CloseDialog()
        {
            base.CloseDialog();
            Time.timeScale = 1f;
        }

        public void BackToHome()
        {
            CloseDialog();
            SceneManager.LoadScene(GameScene.MainMenu.ToString());
        }

        public void Replay()
        {
            CloseDialog();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
