using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public List<GameObject> AllStates;
    public static StateManager _stateManager;
    
    [SerializeField]
    public Dictionary<string, GameObject> statesDictionary;
    public GameObject SelectedState;

    private void Awake() {
        _stateManager = this;
    }

    public List<GameObject> ListBoarderingStates(GameObject state) {
        List<GameObject> states = state.GetComponent<StateMetaData>().BoarderingStates;
        
        return states;
    }

    public event Action<Dictionary<string, GameObject>> onStateMovementCalculation;
    public void StateMovementCalculate(Dictionary<string, GameObject> SD) {
        if (onStateMovementCalculation != null) {
            onStateMovementCalculation(SD);
        }
    }


    public Dictionary<string, GameObject> FindNeighboringStatesAccordingToTravelPoints(GameObject state, int travelPoints) {
        List<GameObject>[] states = new List<GameObject>[travelPoints];
        Debug.Log("travel Points : " + travelPoints + " | Original state : " + state.name);
        Debug.Log("states array length: " + states.Length.ToString());
        Dictionary<string, GameObject> stateDict = new Dictionary<string, GameObject>();
        if (state != null) {
        states[0] = ListBoarderingStates(state);
        foreach(GameObject sg in states[0]) {
            if (stateDict.ContainsKey(sg.name) == false) 
                            {
                        stateDict.Add(sg.name, sg);
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
                                stateDict.Add(sl.name, sl);
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
