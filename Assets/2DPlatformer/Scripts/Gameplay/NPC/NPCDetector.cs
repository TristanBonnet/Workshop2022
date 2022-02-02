using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class NPCDetector : MonoBehaviour
{
    private InteractableNPC _currentInteractableNPC = null;
    private bool _inDialogue = false;
     

    public InteractableNPC CurrentInteractableNPC => _currentInteractableNPC;
    public bool InDialogue => _inDialogue;


    public void SetInDialogue(bool inDialogue)
    {
        _inDialogue = inDialogue;

        if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cubeController))
        {

            cubeController.EnableJump(false);

        }
       


    }

    public void SetCurrentInteractableNPC(InteractableNPC interactableNPC)
    {

        _currentInteractableNPC = interactableNPC;


    }
}
