using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CapacityMenu : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private List<string> _listCapacitiesDescription = null;

    [SerializeField] private List<string> _listTitle = null;

    [SerializeField] private TextMeshProUGUI _descriptionText = null;

    [SerializeField] private TextMeshProUGUI _titleText = null;

    [SerializeField] private Button _firstAbilityButton = null;

    [SerializeField] private Button _secondAbilityButton = null;

    [SerializeField] private Button _thirdAbilityButtton = null;

    [SerializeField] private Button _fourthAbilityButton = null;

    [SerializeField] private List<Sprite> _listSprites = null;

    [SerializeField] private Image _capacityPicture = null;

    [SerializeField] private List<Button> _listButton;
    
    


    public Button FirstAbilityButton => _firstAbilityButton;

    public Button SecondAbilityButton => _secondAbilityButton;

    public Button ThirdAbilityButton => _thirdAbilityButtton;

    public Button FourthAbilityButton => _fourthAbilityButton;

    public Image CapacityPicture => _capacityPicture;

    public List<Button> ListButton => _listButton;



    private void Start()
    {
        
    }



    public void SetCapacity(int index)
    {
       

            _descriptionText.SetText(_listCapacitiesDescription[index]);
            _titleText.SetText(_listTitle[index]);
           //_capacityPicture.sprite = _listSprites[index];

        if (!_capacityPicture.isActiveAndEnabled)
        {
            _capacityPicture.gameObject.SetActive(true);

        }
        
 

       

       

    }

    public void SetElementsVisibility(int index, bool visible)
    {
        if (index == 0)
        {

            _firstAbilityButton.gameObject.SetActive(visible);

        }

        else if (index == 1)
        {

            _secondAbilityButton.gameObject.SetActive(visible);

        }

        else if (index == 2)
        {

            _thirdAbilityButtton.gameObject.SetActive(visible);

        }

        else if (index == 3)
        {
            _fourthAbilityButton.gameObject.SetActive(visible);
        }
       

    }


   

}
