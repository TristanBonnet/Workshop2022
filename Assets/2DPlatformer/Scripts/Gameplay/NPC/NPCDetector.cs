using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetector : MonoBehaviour
{
    private InteractableNPC _currentInteractableNPC = null;


    public InteractableNPC CurrentInteractableNPC => _currentInteractableNPC;
}
