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
        private bool m_isDead, m_isOnBlock;
        private Vector3 m_centerPos;

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (m_isDead || IsComponentNull())
            {
                return;
            }    

            Jump();
            
            if (m_rb.velocity.y < 0)
            {
                if (m_isOnBlock)
                {
                    m_animator.SetBool(CharacterAnimator.Jump.ToString(), false);
                    m_animator.SetBool(CharacterAnimator.Land.ToString(), true);
                }
                else
                {
                    m_animator.SetBool(CharacterAnimator.Jump.ToString(), false);
                }    
            }    
        }

        private void FixedUpdate()
        {
            IsOnBlock();
        }

        public bool IsComponentNull()
        {
            return m_rb == null || m_animator == null;
        }

        private void IsOnBlock()
        {
            m_centerPos = new(transform.position.x,
                                transform.position.y - blockCheckingOffset,
                                            transform.position.z);
            Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius, blockLayer);
            
            m_isOnBlock = col != null;
        }

        public void BackToIdle()
        {
            m_animator.SetBool(CharacterAnimator.Land.ToString(), false);
            m_animator.SetTrigger(CharacterAnimator.Idle.ToString());
        }   
        
        public void Jump()
        {
            if (!GamePadController.Ins.CanJump || !m_isOnBlock || IsComponentNull())
            {
                return;
            }
            GamePadController.Ins.CanJump = false;
            m_rb.velocity = Vector2.up * jumpForce;

            m_animator.SetBool(CharacterAnimator.Jump.ToString(), true);
            m_animator.SetBool(CharacterAnimator.Land.ToString(), false);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(GameTag.Block.ToString()))
            {
                Blocks bl = col.gameObject.GetComponent<Blocks>();
                if (bl)
                {
                    bl.PlayerLand();
                }    
            }    
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(GameTag.DeadZone.ToString()))
            {
                Debug.Log("Đã va chạm vào vùng chết");
            }    
        }

    }
}
