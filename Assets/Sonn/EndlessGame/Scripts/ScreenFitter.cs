using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class ScreenFitter : MonoBehaviour
    {
        public SpriteRenderer sp;
        public bool resetScale, fitX, fitY, isOverride;
        public float offsetX, offsetY;

        private void Awake()
        {
            if (!isOverride)
                Helper.FitSpriteToScreen(sp, resetScale, fitX, fitY, offsetX, offsetY);
        }

        public void Fit()
        {
            Helper.FitSpriteToScreen(sp, resetScale, fitX, fitY, offsetX, offsetY);
        }
    }
}
