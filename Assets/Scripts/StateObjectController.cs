using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateObjectController : MonoBehaviour
{
    string _name;
    SpriteRenderer spriteRenderer;
    static Color OriginalColor;


    public State SM;

    public void StatePropertyManager () {
        
    }

    public void PreSelectState(State _sm){
        if (_sm.StateCanBePreSelected) {
            SM.StatePreSelected = true;
        }
    }

    


    private void OnMouseDown() {
        
    }

    
    

    




    public void StateColorManager(SpriteRenderer SR, State _state) {
        if (_state.PlayerCanMoveToThisState == true) {
            SR.color = AllStatesGeneralMetadata.AllStatesObj.HighlightColor;
        }
        else if (_state.StatePreSelected == true) {
            SR.color = AllStatesGeneralMetadata.AllStatesObj.PreSelectColor;
        }
        else if (_state.StatePreSelected == true && _state.PlayerCanMoveToThisState == true) {
            SR.color = AllStatesGeneralMetadata.AllStatesObj.PreSelectColor;
        }
        
    }


    ///Theoratically, add functions here to execute on state change
    public void ExecuteOnStatePropertyChange() {
        StateColorManager(spriteRenderer, SM);
    }


    

    private void OnMouseEnter()
    {
        //GameManager._gameManager.TentativeStateSelected(this.gameObject);
    }

    

    public StateControllerClass stateControl;

    // void HighlightStateAccordingToStateDictionary(Dictionary<string, GameObject> dict) {
    //     if (dict.ContainsKey(this.gameObject.name)) {
    //         this.gameObject.GetComponent<SpriteRenderer>().color = AllStatesGeneralMetadata.AllStatesObj.HighlightColor;
    //     }
    // }

    public void StateSettingsManager(Dictionary<string, GameObject> dict) {
        if (dict.ContainsKey(_name)) {
            
        }
    }

    private void OnMouseOver()
    {
        if (SM.PlayerCanMoveToThisState == true)
        {
        spriteRenderer.color = Color.green;
        }
    }

    public void ChangeColorGreen()
    {
        spriteRenderer.color = Color.green;
    }

    private void OnMouseExit() { 
        
        StateColorManager(spriteRenderer, SM);
    }

    private void Awake() {
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
    OriginalColor = spriteRenderer.color;  
    _name = this.gameObject.name;
    SM = this.gameObject.GetComponent<State>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}