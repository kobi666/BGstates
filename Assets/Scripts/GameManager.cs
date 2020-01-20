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
    
    public void InstantiatePlayers(int NumberOfPlayers) {

        Vector3 pv3 = new Vector3(PlayersParentObj.transform.position.x,PlayersParentObj.transform.position.y, PlayersParentObj.transform.position.z);
        for (int i = 1 ; i <= NumberOfPlayers ; i++) {
        
        
         
        }

    }



    

    
    


    
    

    private void Awake() {
        _gameManager = this;
        PlayersParentObj = GameObject.FindGameObjectWithTag("Players");
        
    }
    
}
