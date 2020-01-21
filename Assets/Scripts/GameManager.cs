using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    
    int t;
    // Start is called before the first frame update
    public Transform PlayerPrefab;
    GameObject PlayersParentObj;

    public static GameManager _gameManager;
    
    public GameObject CurrentPlayer;

    public event Action _gameStarted;
    public void GameStarted() {
        if (_gameStarted != null) {
            _gameStarted();
        }
    }



    public void InstantiatePlayers(int NumberOfPlayers) {

        Vector3 pv3 = new Vector3(PlayersParentObj.transform.position.x,PlayersParentObj.transform.position.y, PlayersParentObj.transform.position.z);
        for (int i = 1 ; i <= NumberOfPlayers ; i++) {
            GameObject GO = Instantiate(PlayerPrefab, PlayersParentObj.transform.position, PlayersParentObj.transform.rotation, PlayersParentObj.transform).gameObject;
            GO.name = ("Player_" + i.ToString());
            GO.GetComponent<PlayerData>().sequenceNumber = i;
        }
    }

    public void DisableButtons() {
        Destroy(GameObject.FindGameObjectWithTag("TestButtons"));
    }

    



    

    
    


    
    

    private void Awake() {
        _gameManager = this;
        PlayersParentObj = GameObject.FindGameObjectWithTag("Players");
        
    }
    
}
