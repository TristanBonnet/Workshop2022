using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;

public class TeleportArea : MonoBehaviour
{
    [SerializeField] private TeleportArea _tpArea = null;

    [SerializeField] private Transform _teleportTransform = null;

    [SerializeField] private GameObject _visibleInput = null;

    [SerializeField] private string _verb = null;



    public Transform TPTransform => _teleportTransform;


    public TeleportArea TPArea => _tpArea;

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, _tpArea.transform.position, Color.blue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TPPlayer player = other.GetComponentInParent<TPPlayer>();

        if (player != null)
        {

            player.SetIsInArea(true);
            player.SetCurrentTPArea(this);
            //_visibleInput.SetActive(true);
            LevelReferences.Instance.UIManager.SetInputDialogueActive(true);
            LevelReferences.Instance.UIManager.SetTextAndSprite(_verb, LevelReferences.Instance.UIManager.ListSprite[0]);
        }
    }



    private void OnTriggerExit(Collider other)
    {

        TPPlayer player = other.GetComponentInParent<TPPlayer>();

        if (player != null)
        {

            player.SetIsInArea(false);
            player.SetCurrentTPArea(null);
            //_visibleInput.SetActive(false);
            LevelReferences.Instance.UIManager.SetInputDialogueActive(false);
        }


    }
}
