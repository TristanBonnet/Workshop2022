using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveCanvas : MonoBehaviour
{
    [SerializeField] List<GameObject> _listCanvas = null;
    



    public void SetObjectVisibilityOn ( int index)
    {

        _listCanvas[index].SetActive(true);
        


    }

    public void SetObjectVisibilityOff( int index)
    {

        _listCanvas[index].SetActive(false);


        

    }

    public void FocusButton(GameObject buttonToFocus)
    {

        EventSystem.current.SetSelectedGameObject(buttonToFocus);


    }
}
