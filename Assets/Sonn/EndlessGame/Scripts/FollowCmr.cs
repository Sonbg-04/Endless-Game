using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class FollowCmr : MonoBehaviour
    {
        private Camera m_cam; 
        
            
        void Start()
        {
            m_cam = Camera.main;
        }
        
        void Update()
        {
            transform.position = new(
                m_cam.transform.position.x,
                m_cam.transform.position.y,
                transform.position.z
                );

        }
    }

}
