using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

[System.Serializable]
public class State : MonoBehaviour
{
    [SerializeField]
    public UnityEvent StatePropertyChanged;
    // Start is called before the first frame update
    private bool _playerCanMoveToThisState;
    private bool _stateIsSelected;
    private UnityAction _action;
    [SerializeField]
    public bool PlayerCanMoveToThisState { get => _playerCanMoveToThisState ; set 
        {
            _playerCanMoveToThisState = value;
            if (StatePropertyChanged != null) {
                StatePropertyChanged.Invoke();
            }
            if (StatePropertyChanged == null) { Debug.Log("Invoked empty method from Unity event");}
        }
    }
    [SerializeField]
    public bool StateIsSelected {get => _stateIsSelected ; set 
        {
            _stateIsSelected = value;
            if (StatePropertyChanged != null) {
                StatePropertyChanged.Invoke();
            }
            if (StatePropertyChanged == null) { Debug.Log("Invoked empty method from Unity event");}
        }
        }

        

    
    

        // public State(UnityAction action) {
        //     _action = action;
        //     StatePropertyChanged.AddListener(_action);
        // }

        private void Awake() {
            _action = gameObject.GetComponent<StateObjectController>().ExecuteOnStatePropertyChange;
        }    
    }


    



