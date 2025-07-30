using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sonn.EndlessGame
{
    public class AudioManager : MonoBehaviour, ISingleton
    {
        public static AudioManager Ins;
      
        public AudioSource backgroundSource, menuSource, 
            bonusSource, btnClickSource, gameOverSource,
            jumpSource, landSource, newBestScoreSource,
            scoreSource;

        private void Awake()
        {
            MakeSingleton();
        }

        public void PlayMusic(AudioSource audioSource)
        {

            if (audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
        public void PauseMusic(AudioSource audioSource)
        {

            if (audioSource)
            {
                audioSource.Pause();
            }
        }
        public void ResumeMusic(AudioSource audioSource)
        {

            if (audioSource)
            {
                audioSource.UnPause();
            }
        }
        public void PlaySoundOneShots(AudioSource audioSource)
        {

            if (audioSource)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        public void StopMusic(AudioSource audioSource)
        {
            if (audioSource)
            {
                audioSource.Stop();
            }    
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
    }
}
