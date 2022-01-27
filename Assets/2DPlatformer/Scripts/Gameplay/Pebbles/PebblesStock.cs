using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebblesStock : MonoBehaviour
{
    [SerializeField] private int _maxStack = 5;
                     private int _currentStack = 0;
    [SerializeField] private bool _infinityStack = true;

    public int CurrentStack => _currentStack;
    public bool InfinityStaack => _infinityStack;

    private void Start()
    {
        _currentStack = _maxStack;
    }
    private void OnTriggerEnter(Collider other)
    {
       CheckPebbleState pebbleState =  other.GetComponentInParent<CheckPebbleState>();

        if (pebbleState != null)
        {
            pebbleState.SetOnPebblesActive(true);
            pebbleState.SetPebbleStock(this);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        CheckPebbleState pebbleState = other.GetComponentInParent<CheckPebbleState>();

        if (pebbleState != null)
        {
            pebbleState.SetOnPebblesActive(false);
            pebbleState.SetPebbleStock(null);
        }


    }

    public void RemoveStack(int numberOfStack)
    {
        _currentStack -= numberOfStack;

    }
}
