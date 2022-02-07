using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> _soundList = null;

    public AudioClip GetSound(int index)
    {

        return _soundList[index];


    }
}
