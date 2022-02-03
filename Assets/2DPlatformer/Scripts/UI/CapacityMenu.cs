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



    public void SetCapacity(int index)
    {
       

            _descriptionText.SetText(_listCapacitiesDescription[index]);
            _titleText.SetText(_listTitle[index]);
 

       

       

    }


}
