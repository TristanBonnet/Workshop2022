using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainLayer = null;
    [SerializeField] GameObject _storyLayer = null;
    [SerializeField] GameObject _commandLayer = null;
    [SerializeField] GameObject _firstScreen = null;
    [SerializeField] GameObject _playeButton = null;
    [SerializeField] private EventSystem _eventSystem = null;
    private bool _activeTimer = false;
    private float _currentTime = 0;

   public  enum Layer
   {
        MainLayer,
        StoryLayer,
        CommandLayer,
        FirstScreen

   }

    Layer _currentLayer = Layer.FirstScreen;

    private void Update()
    {
        if (_activeTimer)
        {
            if (_currentTime < 0.1)
            {
                _currentTime += Time.deltaTime;
            }

            else
            {
                Debug.Log("FOCUS BUTTON");
                _eventSystem.SetSelectedGameObject(_playeButton);
                _activeTimer = false;

            }
        }


    }
    public void SwitchLayer(int layer)
    {


        if (layer == 0)
        {
            // Active Main Layer
            _mainLayer.SetActive(true);
            _storyLayer.SetActive(false);
            _commandLayer.SetActive(false);
            _firstScreen.SetActive(false);
             
            _currentLayer = Layer.MainLayer;
            _activeTimer = true;
            
        }

        else if (layer == 1)
        {
            // Active Story Layer
            _mainLayer.SetActive(false);
            _storyLayer.SetActive(true);
            _commandLayer.SetActive(false);
            _currentLayer = Layer.StoryLayer;
        }

        else if (layer == 2)
        {
            // Active Main Command Layer
            _mainLayer.SetActive(false);
            _storyLayer.SetActive(false);
            _commandLayer.SetActive(true);
            _currentLayer = Layer.CommandLayer;
        }

        
                  
                               
                         
    }
    public void PressBButton()
    {
        switch (_currentLayer)
        {
            case Layer.MainLayer:
                {
                    


                }
                break;
            case Layer.StoryLayer:
                {
                    SwitchLayer(0);


                }
                break;
            case Layer.CommandLayer:
                {

                    SwitchLayer(0);

                }
                break;
            case Layer.FirstScreen:
                {




                }
                break;
            default:
                break;
        }



    }

    public void PressAButton()
    {
        switch (_currentLayer)
        {
            case Layer.MainLayer:
                {




                }
                break;
            case Layer.StoryLayer:
                {



                }
                break;
            case Layer.CommandLayer:
                {



                }
                break;
            case Layer.FirstScreen:
                {

                    SwitchLayer(0);

                }
                break;
            default:
                break;
        }



    }

    public void QuitGame()
    {

        Application.Quit();
       
    }
    
}
