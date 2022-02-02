using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _sentence = null;
    [SerializeField] Image _NPCPicture = null;

    public void SetSentence(string text)
    {
        _sentence.SetText(text);
    }

    public void SetSprite(Sprite sprite)
    {

        _NPCPicture.sprite = sprite;

    }

}
