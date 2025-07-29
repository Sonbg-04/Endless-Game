using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sonn.EndlessGame
{
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Ins;
        public GameObject homeGUI, gameGUI;
        public Dialog gameoverDialog;
        public Text scorecountingTxt;
        public Image gameovertxtImg;

        
        private void Awake()
        {
            Ins = this;
        }
        
        public void ShowGUI(bool isShow)
        {
            if (gameGUI)
            {
                gameGUI.SetActive(isShow);
            }    
            if (homeGUI)
            {
                homeGUI.SetActive(!isShow);
            }    

        }    
        public void UpdateScore(int score)
        {
            if (scorecountingTxt)
            {
                scorecountingTxt.text = score.ToString();
            }    
        }    

        IEnumerator ShowGameovertxtImgCoroutine()
        {
            if (gameovertxtImg)
            {
                gameovertxtImg.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(2);
            if (gameovertxtImg)
            {
                gameovertxtImg.gameObject.SetActive(false);
            }    
            if (gameoverDialog)
            {
                gameoverDialog.Show(true);
            }    
        }    

        public void ShowGameOverTxtImg()
        {
            StartCoroutine(ShowGameovertxtImgCoroutine());
        }    

    }

}
