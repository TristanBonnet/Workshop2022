using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GSGD2;
using GSGD2.Player;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] Sprite _NPCPicture = null;
    
    [TextArea(3, 5)]
    [SerializeField] List<string> _sentences = null;

    private string _currentSentence = "";

    private int _currentSentenceIndex = 0;




    private void Start()
    {
            



    }




    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponentInParent<PlayerController>();
        NPCDetector npcDetector = other.GetComponentInParent<NPCDetector>();

        if (playerController != null && npcDetector != null)
        {
            npcDetector.SetCurrentInteractableNPC(this);


        }
    }


    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.GetComponentInParent<PlayerController>();
        NPCDetector npcDetector = other.GetComponentInParent<NPCDetector>();

        if (playerController != null && npcDetector != null)
        {
            npcDetector.SetCurrentInteractableNPC(null);
            npcDetector.SetInDialogue(false);

        }


    }

   
}
