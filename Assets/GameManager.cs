using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    int t;
    // Start is called before the first frame update

    public static GameManager _gameManager;
    public GameObject TentativeSelectedState;
    public GameObject CurrentPlayer;
    public GameObject StatesPlaceholder;
    public List<GameObject> AllStates;
    public GameObject RandomState() {
        return AllStates[UnityEngine.Random.Range(0, AllStates.Count)];
    }

    [SerializeField]
    public Dictionary<string, GameObject> stateDictionary;

    public event Action<GameObject> onTentativeStateSelection;

    public void TentativeStateSelected(GameObject state) {
        if (onTentativeStateSelection != null) {
            onTentativeStateSelection(state);
        }
    }

    public event Action onTentativeStateDeselect;

    public void TentativeState_Deslected() {
        TentativeSelectedState = null;
    }

    void setTentativeState(GameObject state) {
        TentativeSelectedState = state;
    }

    public List<GameObject> ListBoarderingStates(GameObject state) {
        List<GameObject> states = state.GetComponent<StateMetaData>().BoarderingStates;
        
        return states;
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

    void HighlightStates(Dictionary<string, GameObject> sd) {
        foreach(KeyValuePair<string, GameObject> sdi in sd) {
            sdi.Value.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }



    

    
    


    
    

    private void Awake() {
        _gameManager = this;
        onTentativeStateSelection += setTentativeState;


        onTentativeStateDeselect += TentativeState_Deslected;

        StatesPlaceholder = GameObject.FindGameObjectWithTag("States");
        for (int i = 0; i < StatesPlaceholder.transform.childCount ; i++) 
        {
            AllStates.Add(StatesPlaceholder.transform.GetChild(i).gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // mostly testing conditions
        if (Input.GetKeyDown(KeyCode.I)) {
            stateDictionary = FindNeighboringStatesAccordingToTravelPoints(AllStates[UnityEngine.Random.Range(0, AllStates.Count)], UnityEngine.Random.Range(1,6));
            HighlightStates(stateDictionary);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3)) {
            int t = 0;
            if (Input.GetKeyDown(KeyCode.Keypad1)) {
                t = 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)){
                t = 2;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3)){
                t = 3;
            }
            stateDictionary = FindNeighboringStatesAccordingToTravelPoints(AllStates[UnityEngine.Random.Range(0, AllStates.Count)], t);
            HighlightStates(stateDictionary);
        }
        
    }
}
