using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateObjectController : MonoBehaviour
{
    string _name;
    SpriteRenderer spriteRenderer;
    Color HoverColor = Color.green;
    static Color OriginalColor;

    private void OnMouseEnter()
    {
        GameManager._gameManager.TentativeStateSelected(this.gameObject);
    }

    [SerializeField]
    ColorAndPriority HighlightedColor = new ColorAndPriority(Color.yellow, 2);
    [SerializeField]
    ColorAndPriority SelectedColor = new ColorAndPriority(Color.black, 10);
    [SerializeField]
    ColorAndPriority BaseColor = new ColorAndPriority(OriginalColor, 1);

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
        spriteRenderer.color = Color.green;
    }

    public void ChangeColorGreen()
    {
        spriteRenderer.color = Color.green;
    }

    private void OnMouseExit() {
        spriteRenderer.color = OriginalColor;
        GameManager._gameManager.TentativeState_Deslected();
    }

    private void Awake() {
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
    OriginalColor = spriteRenderer.color;  
    _name = this.gameObject.name;

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