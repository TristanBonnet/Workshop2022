using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GSGD2;
using GSGD2.Player;
using GSGD2.Gameplay;

public class InteractableNPC : MonoBehaviour, ICommandSender


{
    [SerializeField] Sprite _NPCPicture = null;
    
    [TextArea(3, 5)]
    [SerializeField] List<string> _sentences = null;

    private string _currentSentence = "";

    private int _currentSentenceIndex = 0;

    public List<string> Sentences => _sentences;
    public int CurrentSentenceIndex => _currentSentenceIndex;

    public Sprite NPCSprite => _NPCPicture;

    [SerializeField] private bool _giveUpgrade = false;
    [SerializeField] PickupCommand _pickUpCommand = null;

    GameObject ICommandSender.GetGameObject() => gameObject;

    public bool GiveUpgrade => _giveUpgrade;

    public PickupCommand PickupCommand => _pickUpCommand;

    private void Start()
    {

        _pickUpCommand.SetDestroyOnApply(false);


    }




    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponentInParent<PlayerController>();
        NPCDetector npcDetector = other.GetComponentInParent<NPCDetector>();

        if (playerController != null && npcDetector != null)
        {
            npcDetector.SetCurrentInteractableNPC(this);
            LevelReferences.Instance.UIManager.SetInputDialogueActive(true);
            LevelReferences.Instance.UIManager.SetTextAndSprite(LevelReferences.Instance.UIManager.ListText[0], LevelReferences.Instance.UIManager.ListSprite[0]);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.GetComponentInParent<PlayerController>();
        NPCDetector npcDetector = other.GetComponentInParent<NPCDetector>();

        if (playerController != null && npcDetector != null)
        {
            
            npcDetector.SetInDialogue(false);
            npcDetector.SetCurrentInteractableNPC(null);
            LevelReferences.Instance.UIManager.SetInputDialogueActive(false);
        }


    }

    public void SetGiveUpgrade(bool giveUpgrate)
    {

        _giveUpgrade = giveUpgrate;


    }

   
}
