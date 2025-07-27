using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class GameManager : MonoBehaviour, ISingleton, IComponentChecking
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
            MakeSingleton();
        }

        void Start()
        {
            Init();
        }

        public void MakeSingleton()
        {
            if (Ins == null)
            {
                Ins = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
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
            }    
        }    

        public bool IsComponentNull()
        {
            return LevelManager.Ins == null;
        }
    }

}
