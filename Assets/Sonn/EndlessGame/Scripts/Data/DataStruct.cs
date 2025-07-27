using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public enum GameTag
    {
        Player,
        Block,
        DeadZone
    }

    public enum GameLayer
    {
        Player,
        Block,
        Dead
    }

    public enum CharacterAnimator
    {
        Jump,
        Land,
        Idle,
        Dead
    }

    public enum GamePref
    {
        BestScore,
        LevelUnlocked,
        CurrentLevelID,
        IsMusicOn,
        IsSoundOn
    }

    public enum GameScene
    {
        MainMenu,
        GamePlay,
    }

    public enum MoveDirection
    {
        Left,
        Right
    }

    public enum GameState
    {
        Starting,
        Playing,
        GameOver
    }

    [System.Serializable]
    public class LevelItem
    {
        public int scoreRequire;
        public Sprite unlockThumb, lockThumb, levelBG, characterPrevImg;
        public Player playerPrefab;
        public Blocks blockPrefab;
        public float spawnTime, baseSpeed, maxSpeed;
        public GameObject map;

    }
}
