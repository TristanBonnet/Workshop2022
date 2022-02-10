using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    [SerializeField] List<AudioClip> _listAudioClip = null;

    [SerializeField] AudioSource _audioSource = null;

    private int currentIndexSound = 0;




    public int CurrentIndexSound => currentIndexSound;


    public void PlaySound(int index)
    {

        currentIndexSound = index;

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.clip = _listAudioClip[index];
        _audioSource.Play();
    }

}
