using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public KeyValuePair<int, GameObject> CurrentPlayer;
    public int NumberOfPlayers = 0;
    public int turnCounter = 0;
    public int roundCounter = 0;
    void incrementTurnCounterByOne() {
        turnCounter++;
    }

    void incrementRoundByOne() {
        roundCounter++;
    }

    public void StartNextTurn() {

    }

    public event Action _turnEnded;
    public void TurnEnded() {
        if (_turnEnded != null) {
            _turnEnded();
        }
    }

    GameObject AllPlayerParentObject;    
    public Dictionary<int, GameObject> Players = new Dictionary<int, GameObject>();

    public void InitPlayersDictionary() {
        AllPlayerParentObject = GameObject.FindGameObjectWithTag("Players");
        for (int i = 0 ; i < AllPlayerParentObject.transform.childCount ; i++) {
            Players.Add(i+1, AllPlayerParentObject.transform.GetChild(i).gameObject);
        }
        NumberOfPlayers = AllPlayerParentObject.transform.childCount;
    }
    
    private void Start() {
        GameManager._gameManager._gameStarted += TurnStarted;
        GameManager._gameManager._gameStarted += InitPlayersDictionary;
        GameManager._gameManager._gameStarted += incrementRoundByOne;
        CurrentPlayer = new KeyValuePair<int, GameObject>(1, Players[1].gameObject);
    }



    public static TurnManager _turnManager;
    void Awake() 
    {
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
