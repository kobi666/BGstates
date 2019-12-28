using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update


    public List<GameObject> stateTiles;
    
    public int formerMovementPoints;

    public int MovementPoints (int value) {
        if (value <= 0) {
            value = UnityEngine.Random.Range(1, 6);
        }
        if (value > 6) {
            value = UnityEngine.Random.Range(1, 6);
        }

        if (value == formerMovementPoints) {
            int ff = UnityEngine.Random.Range(1,2);
            if (ff == 1) {
                value = UnityEngine.Random.Range(1, 6);
            }

        }
        Debug.Log("Player Movement points : " + value.ToString());
        formerMovementPoints = value;
        return value;
    }

    public int MovementPoints (bool randomize) {
        int value = 0;
        if (randomize == true) {
            value = UnityEngine.Random.Range(1, 6);
        }
        if (value == formerMovementPoints) {
            int ff = UnityEngine.Random.Range(1,2);
            if (ff == 1) {
                value = UnityEngine.Random.Range(1, 6);
            }

        }
        formerMovementPoints = value;
        Debug.Log("Player Movement points : " + value.ToString());
        return value;
    }

    



    public void TestSetPlayerAtPoint(Vector2 position) {
        
        
    }


        
    
    
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("States")) 
            {
            GameObject StateParent = GameObject.FindGameObjectWithTag("States");
            for (int i = 0 ; i < StateParent.transform.childCount ; i++)
                {
                    stateTiles.Add(StateParent.transform.GetChild(i).gameObject);      
                }
            }
        else { Debug.Log("No Object tagged States");}
    }

    void Start() {
             
        //SetPlayerAtRandomState(this.gameObject, stateTiles);
    }

    


    public void SetPlayerAtRandomState (GameObject Object, List<GameObject> TargetPositionList) {
        Object.transform.position = TargetPositionList[UnityEngine.Random.Range(0, TargetPositionList.Count)].transform.position;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SetPlayerAtRandomState(this.gameObject, stateTiles);
        }
    }



}
