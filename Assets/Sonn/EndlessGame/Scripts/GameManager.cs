using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public static GameManager Ins;
        public float gameSpeed;
        public GameState gameState;
        public GameObject warningSignPrefab;

        private Player m_curPlayer;
        private Blocks m_curBlock;
        private LevelItem m_curLevel;
        private Vector2 m_cameraSize;
        private int m_blockIndex, m_score;
        private float m_blockSpeed, m_blockSpawnPosY;

        public Blocks CurBlock { get => m_curBlock; }
        public int Score { get => m_score; }

        private void Awake()
        {
            Ins = this;
        }

        void Start()
        {
            Init();
        }

        public void Init()
        {
            if (IsComponentNull())
            {
                return;
            }
            gameState = GameState.Starting;
            m_cameraSize = Helper.Get2DCamSize();
            m_blockSpawnPosY = -m_cameraSize.y / 2 + 1f;
            m_curLevel = LevelManager.Ins.GetLevel();
            m_blockIndex = 1;

            Pref.hasBestScore = false;
            if (m_curLevel != null)
            {
                m_blockSpeed = m_curLevel.baseSpeed;
                var mapPrefab = m_curLevel.map;
                if (mapPrefab)
                {
                    Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
                }    
                var blockPrefab = m_curLevel.blockPrefab;
                if (blockPrefab)
                {
                    m_curBlock = Instantiate(blockPrefab, new(0, m_blockSpawnPosY, 0), Quaternion.identity);
                }
            }
            ActivePlayer();
            GUIManager.Ins.ShowGUI(false);
        }

        public void ActivePlayer()
        {
            if (IsComponentNull())
            {
                return;
            }
            if (m_curPlayer)
            {
                Destroy(m_curPlayer.gameObject);
            }    
            if (m_curLevel != null)
            {
                var newPlayerPrefab = m_curLevel.playerPrefab;
                if (newPlayerPrefab)
                {
                    m_curPlayer = Instantiate(newPlayerPrefab, new(0, -1, 0), Quaternion.identity);
                }
                if (m_curPlayer)
                {
                    CameraFollow.Ins.target = m_curPlayer.transform;
                }
            }    
        }    

        public bool IsComponentNull()
        {
            bool check = LevelManager.Ins == null || GUIManager.Ins == null;
            if (check)
            {
                Debug.LogWarning("Có component bị rỗng. Vui lòng kiểm tra lại!");
            }
            return check;
        }

        IEnumerator SpawnBlockCoroutine()
        {
            if (IsComponentNull() || m_curLevel == null || m_curBlock == null)
            {
                yield break;
            }

            var blockPrefab = m_curLevel.blockPrefab;

            if (blockPrefab == null)
            {
                yield break;
            }

            while (gameState != GameState.GameOver)
            {
                SpriteRenderer currentBlockSr = m_curBlock.Sr;
                m_blockSpawnPosY += m_curBlock.blockDistance;
                m_blockSpeed += gameSpeed;
                m_blockSpeed = Mathf.Clamp(m_blockSpeed, m_curLevel.baseSpeed, m_curLevel.maxSpeed);

                float checking = Random.Range(0, 1f);
                GameObject warningSignClone = null;
                if (checking <= 0.5f)
                {
                    Vector3 spawnPos = new(m_cameraSize.x / 2 - 0.3f, m_blockSpawnPosY, 0);
                    warningSignClone = Instantiate(warningSignPrefab, spawnPos, Quaternion.identity);
                    warningSignClone.transform.localScale = new(
                        warningSignClone.transform.localScale.x * -1f, 
                        warningSignClone.transform.localScale.y, 
                        warningSignClone.transform.localScale.z);

                    
                }
                else
                {
                    Vector3 spawnPos = new(-(m_cameraSize.x / 2 - 0.3f), m_blockSpawnPosY, 0);
                    warningSignClone = Instantiate(warningSignPrefab, spawnPos, Quaternion.identity);
                }    

                    yield return new WaitForSeconds(m_curLevel.spawnTime);
                if (checking <= 0.5f)
                {
                    Vector3 spawnPos = new(m_cameraSize.x / 2 + 0.6f, m_blockSpawnPosY, 0);
                    m_curBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                    m_curBlock.moveDirection = MoveDirection.Left;
                }
                else
                {
                    Vector3 spawnPos = new(-(m_cameraSize.x / 2 + 0.6f), m_blockSpawnPosY, 0);
                    m_curBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                    m_curBlock.moveDirection = MoveDirection.Right;
                }

                m_curBlock.ChangeSprite(ref m_blockIndex);
                m_curBlock.moveSpeed = m_blockSpeed;
                m_curBlock.SpriteOrderUp(currentBlockSr);
                m_curBlock.canMove = true;

                if (warningSignClone)
                {
                    Destroy(warningSignClone);
                }

            }    
        }

        public void PlayGame()
        {
            if (IsComponentNull())
            {
                return;
            }
            gameState = GameState.Playing;
            StartCoroutine(SpawnBlockCoroutine());
            GUIManager.Ins.ShowGUI(true);
        }    
        public void GameOver()
        {
            if (IsComponentNull())
            {
                return;
            }
            gameState = GameState.GameOver;
            CamShake.Ins.ShakeTrigger();
            GUIManager.Ins.ShowGameOverTxtImg();
        }    
        public void AddScore(int score)
        {
            if (IsComponentNull() || gameState != GameState.Playing)
            {
                return;
            }
            m_score += score;
            Pref.bestScore = m_score;
            GUIManager.Ins.UpdateScore(m_score);

        }    
    }

}
