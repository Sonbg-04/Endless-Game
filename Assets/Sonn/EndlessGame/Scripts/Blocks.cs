using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class Blocks : MonoBehaviour, IComponentChecking
    {
        public float moveSpeed, blockDistance;
        public MoveDirection moveDirection;
        public Sprite[] blockSprites;
        public bool canMove;
        public int minScore, maxScore;

        private Rigidbody2D m_rb;
        private SpriteRenderer m_sr;
        private int m_id, m_currentScore;

        public SpriteRenderer Sr { get => m_sr; }
        public int Id { get => m_id; }
        public int CurrentScore { get => m_currentScore; }


        private void Awake()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_sr = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            m_id = GetInstanceID();
            m_currentScore = Random.Range(minScore, maxScore);
        }

        void Update()
        {
            BlockMoving();
        }
        public bool IsComponentNull()
        {
            bool check = m_rb == null || m_sr == null;
            if (check)
            {
                Debug.LogError("Có thành phần để rỗng. Vui lòng kiểm tra lại!");
            }
            return check;
        }
        
        public void ChangeSprite(ref int index)
        {
            if (blockSprites == null || blockSprites.Length <= 0
                || IsComponentNull())
            {
                return;
            }    
            m_sr.sprite = blockSprites[index];
            index++;
            if (index >= blockSprites.Length)
            {
                index = 0;
            }

        }    

        private void BlockMoving()
        {
            if (IsComponentNull() || !canMove)
            {
                return;
            }    
            if (moveDirection == MoveDirection.Left)
            {
                m_rb.velocity = Vector2.left * moveSpeed;
            }    
            else if (moveDirection == MoveDirection.Right)
            {
                m_rb.velocity = Vector2.right * moveSpeed;
            }

            Vector3 centerPos = new(0, transform.position.y, transform.position.z);
            float distanceToCenterPos = Vector2.Distance(transform.position, centerPos);
            if (distanceToCenterPos <= 0.1f)
            {
                m_rb.velocity = Vector2.zero;
                transform.position = centerPos;
            }    
        }  
        
        public void PlayerLand()
        {
            if (IsComponentNull() || !canMove)
            {
                return;
            }
            canMove = false;
            m_rb.velocity = Vector2.zero;
        }   
        
        public void SpriteOrderUp(SpriteRenderer prevBlockSp)
        {
            if (IsComponentNull())
            {
                return;
            }
            m_sr.sortingOrder = prevBlockSp.sortingOrder + 1;
        }    
    }

}
