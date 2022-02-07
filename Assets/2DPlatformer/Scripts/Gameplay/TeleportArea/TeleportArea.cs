using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArea : MonoBehaviour
{
    [SerializeField] private TeleportArea _tpArea = null;

    [SerializeField] private Transform _teleportTransform = null;

    [SerializeField] private GameObject _visibleInput = null;



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
            _visibleInput.SetActive(true);

        }
    }



    private void OnTriggerExit(Collider other)
    {

        TPPlayer player = other.GetComponentInParent<TPPlayer>();

        if (player != null)
        {

            player.SetIsInArea(false);
            player.SetCurrentTPArea(null);
            _visibleInput.SetActive(false);
        }


    }
}
