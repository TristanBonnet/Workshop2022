using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] Sprite _NPCPicture = null;
    
    [TextArea(3, 5)]
    [SerializeField] List<string> _sentences = null;
}
