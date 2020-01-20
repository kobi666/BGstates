using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    
    public List<GameObject> AllStatesList;
    public Dictionary<string, GameObject> AllStatesDict = new Dictionary<string, GameObject>();
    GameObject AllStatesParentObject;

    public static StateManager _stateManager;
    
    [SerializeField]
    public Dictionary<string, StateAndTravelCost> statesDictionary;
    public GameObject SelectedState;

    

    public List<GameObject> ListBoarderingStates(GameObject state) {
        List<GameObject> states = state.GetComponent<StateMetaData>().BoarderingStates;
        
        return states;
    }

    // public event Action<Dictionary<string, GameObject>> onStateMovementCalculation;
    // public void StateMovementCalculate(Dictionary<string, GameObject> SD) {
    //     if (onStateMovementCalculation != null) {
    //         onStateMovementCalculation(SD);
    //     }
    // }


    public Dictionary<string, StateAndTravelCost> FindNeighboringStatesAccordingToTravelPoints(GameObject state, int travelPoints) {
        List<GameObject>[] states = new List<GameObject>[travelPoints];
        Debug.Log("travel Points : " + travelPoints + " | Original state : " + state.name);
        Debug.Log("states array length: " + states.Length.ToString());
        Dictionary<string, StateAndTravelCost> stateDict = new Dictionary<string, StateAndTravelCost>();
        if (state != null) {
        states[0] = ListBoarderingStates(state);
        foreach(GameObject sg in states[0]) {
            if (stateDict.ContainsKey(sg.name) == false) 
                            {
                        stateDict.Add(sg.name, new StateAndTravelCost(sg, 1));
                            }
        }
        }
        for (int i = 1 ; i < travelPoints ; i++ ) {
            states[i] = new List<GameObject>();
            foreach(GameObject s in states[i - 1]) {
                if (s != null) 
                {
                    foreach(GameObject sl in ListBoarderingStates(s)) {
                        if (sl != null) {
                            states[i].Add(sl);
                            if (stateDict.ContainsKey(sl.name) == false) 
                            {
                                stateDict.Add(sl.name, new StateAndTravelCost(sl, i+1));
                            }
                        
                        }
                    }
                    
                    
                }
            }   
        }
        stateDict.Remove(state.name);
        // foreach (KeyValuePair<string, GameObject> sd in stateDict) {
        //     Debug.Log(sd.Key);
        // }
        return stateDict;
    }


    public void SetStatesAsMovableForPlayer(Dictionary<string, StateAndTravelCost> dict) {
        foreach(KeyValuePair<string, StateAndTravelCost> St_Tc in dict) {
            St_Tc.Value.GO.GetComponent<StateObjectController>().SM.PlayerCanMoveToThisState = true;
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            statesDictionary = FindNeighboringStatesAccordingToTravelPoints(AllStatesList[UnityEngine.Random.Range(0, AllStatesList.Count -1)], 3);
            SetStatesAsMovableForPlayer(statesDictionary);
        }
    }





    private void Awake() {
        _stateManager = this;
        AllStatesParentObject = GameObject.FindGameObjectWithTag("States");
        for (int i = 0 ; i <= AllStatesParentObject.transform.childCount -1 ; i++ ) {
            AllStatesList.Add(AllStatesParentObject.transform.GetChild(i).gameObject);
            AllStatesDict.Add(AllStatesParentObject.transform.GetChild(i).name, AllStatesParentObject.transform.GetChild(i).gameObject);
        }
    }
}
