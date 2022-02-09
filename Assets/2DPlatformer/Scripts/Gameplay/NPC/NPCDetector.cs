using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;
using GSGD2.Gameplay;

public class NPCDetector : MonoBehaviour
{
    
    private InteractableNPC _currentInteractableNPC = null;
    private bool _inDialogue = false;
    private int _currentSentenceIndex = 0;
    private bool runDelay = false;


    

    public InteractableNPC CurrentInteractableNPC => _currentInteractableNPC;
    public bool InDialogue => _inDialogue;

    private float _currentDelayBeforeJump = 0;

    

    private void Update()
    {

        if (runDelay)
        {
            if (_currentDelayBeforeJump < 0.1f)
            {
                _currentDelayBeforeJump += Time.deltaTime;


            }

            else
            {
                if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cubeController))
                {
                    cubeController.EnableJump(true);

                }
                _currentDelayBeforeJump = 0;
                runDelay = false;
            }
        }



    }



    public void SetInDialogue(bool inDialogue)
    {
        _inDialogue = inDialogue;

        if (inDialogue)
        {
            if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cubeController))
            {
               cubeController.EnableJump(false);

            }

            LevelReferences.Instance.UIManager.DialogueUI.gameObject.SetActive(true);
            StartDialogue();
           
        }


        else
        {

            runDelay = true;
            LevelReferences.Instance.UIManager.DialogueUI.gameObject.SetActive(false);
            LevelReferences.Instance.UIManager.InputDialogue.SetActive(false);
            


        }
        

       



    }

    public void SetCurrentInteractableNPC(InteractableNPC interactableNPC)
    {

        _currentInteractableNPC = interactableNPC;


    }



    public void SetSentence(string sentence)
    {

        LevelReferences.Instance.UIManager.DialogueUI.SetSentence(sentence);


    }

    public void StartDialogue()
    {

        SetSentence(_currentInteractableNPC.Sentences[0]);
        SetSprite();
        

    }


    public void GetNextSentence()
    {
        _currentSentenceIndex += 1;

        if (_currentSentenceIndex > _currentInteractableNPC.Sentences.Count - 1)
        {
            if (_currentInteractableNPC.GiveUpgrade && _currentInteractableNPC.PickupCommand != null)
            {
                _currentInteractableNPC.PickupCommand.Apply(_currentInteractableNPC);
                _currentInteractableNPC.SetGiveUpgrade(false);
            }
            SetInDialogue(false);
            _currentSentenceIndex = 0;

        }

        else
        {
            SetSentence(_currentInteractableNPC.Sentences[_currentSentenceIndex]);
            
        }

    }

    public void SetSprite()
    {

        LevelReferences.Instance.UIManager.DialogueUI.SetSprite(_currentInteractableNPC.NPCSprite );

    }



}
