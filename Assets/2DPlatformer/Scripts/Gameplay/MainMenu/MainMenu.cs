using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainLayer = null;
    [SerializeField] GameObject _storyLayer = null;
    [SerializeField] GameObject _commandLayer = null;
    [SerializeField] GameObject _firstScreen = null;
     

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
}
