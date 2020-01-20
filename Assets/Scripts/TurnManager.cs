using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    int turnCounter;
    void incrementTurnCounterByOne() {
        turnCounter++;
    }

    GameObject AllPlayerParentObject;
    Dictionary<int, GameObject> Players;




    public static TurnManager _turnManager;
    void Awake() 
    {
        AllPlayerParentObject = GameObject.FindGameObjectWithTag("Players");
        
        _turnManager = this;
        onTurnStarted += incrementTurnCounterByOne;
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
        
    }
}
