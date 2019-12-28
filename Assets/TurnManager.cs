using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static TurnManager _turnManager;
    void Awake() 
    {
        _turnManager = this;
    }

    public event Action onTurnStarted;

    public void TurnStarted() {
        if (onTurnStarted != null) {
            onTurnStarted();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            TurnStarted();
        }
    }
}
