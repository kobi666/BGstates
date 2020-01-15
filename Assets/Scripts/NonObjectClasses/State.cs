using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    UnityEvent StateChanged;
    // Start is called before the first frame update
    private bool _stateIsHighlighted;
    public bool StateIsHighlighted { get => _stateIsHighlighted ; private set 
        {
            _stateIsHighlighted = value;
            if (StateChanged != null) {
                StateChanged.Invoke();
            }
            if (StateChanged == null) { Debug.Log("Invoked empty method from Unity event");}
        }
    }
    


}
