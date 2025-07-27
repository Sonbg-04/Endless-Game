using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class DestroyDelay : MonoBehaviour
    {
        public float timeToDestroy;
        public bool isAutoDestroy;

        private void Awake()
        {
            if (isAutoDestroy)
            {
                DestroyObj();
            }
        }
        private void DestroyObj()
        {
            Destroy(gameObject, timeToDestroy);
        }    
    }

}
