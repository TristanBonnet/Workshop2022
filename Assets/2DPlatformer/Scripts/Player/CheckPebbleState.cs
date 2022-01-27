using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPebbleState : MonoBehaviour
{
    private bool _onPebbles = false;
    private PebblesStock _pebbleStock = null;

    public bool OnPebbles => _onPebbles;

    
    public PebblesStock PebbleStock => _pebbleStock;



    public void SetOnPebblesActive(bool active)
    {
        _onPebbles = active;

    }

    public void SetPebbleStock(PebblesStock pebbleStock)
    {
      _pebbleStock = pebbleStock;

    }
}
