using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        public float jumpForce, blockCheckingRadius, blockCheckingOffset;
        public LayerMask blockLayer;
        public GameObject landVfx;

        private Rigidbody2D m_rb;
        private Animator m_animator;
        private int m_blockID;
        private bool m_isDead;
        private Vector3 m_centerPos;

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public bool IsComponentNull()
        {
            return m_rb == null || m_animator == null;
        }

        private bool IsOnBlock()
        {
            m_centerPos = new (transform.position.x,
                                transform.position.y - blockCheckingOffset,
                                            transform.position.z);
            Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius, blockLayer);
            
            return col != null;
        }

    }
}
