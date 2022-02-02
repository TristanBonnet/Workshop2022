using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetector : MonoBehaviour
{
    private InteractableNPC _currentInteractableNPC = null;
    private bool _inDialogue = false;


    public InteractableNPC CurrentInteractableNPC => _currentInteractableNPC;
    public bool InDialogue => _inDialogue;


    public void SetInDialogue(bool inDialogue)
    {

        _inDialogue = inDialogue;


    }

    public void SetCurrentInteractableNPC(InteractableNPC interactableNPC)
    {

        _currentInteractableNPC = interactableNPC;


    }
}
