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
            AudioManager.Ins.PauseMusic(AudioManager.Ins.backgroundSource);
            Time.timeScale = 0f;
        }

        public override void CloseDialog()
        {
            base.CloseDialog();
            Time.timeScale = 1f;
            AudioManager.Ins.ResumeMusic(AudioManager.Ins.backgroundSource);
        }

        public void BackToHome()
        {
            CloseDialog();
            SceneManager.LoadScene(GameScene.MainMenu.ToString());
            AudioManager.Ins.StopMusic(AudioManager.Ins.backgroundSource);
        }

        public void Replay()
        {
            CloseDialog();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            AudioManager.Ins.StopMusic(AudioManager.Ins.backgroundSource);
        }
    }
}
