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
        LevelPrefix,
        CurrentPlayerID,
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
}
