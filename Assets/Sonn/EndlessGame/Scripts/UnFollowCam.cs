using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class UnFollowCam : MonoBehaviour
    {
        private Vector3 m_startPos;

        private void Awake()
        {
            m_startPos = transform.position;
        }
        
        void Update()
        {
            transform.position = m_startPos;
        }
    }

}
