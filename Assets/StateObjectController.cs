using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObjectController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color HoverColor = Color.green;
    static Color OriginalColor;
    private void OnMouseEnter() {
        spriteRenderer.color = Color.green;
        GameManager._gameManager.TentativeStateSelected(this.gameObject);
    }

    class ColorAndPriority {
        Color _color;
        int _priority;
        public ColorAndPriority(Color col, int pri) {
            this._color = col;
            this._priority = pri;
        }
    }

    [SerializeField]
    ColorAndPriority HighlightedColor = new ColorAndPriority(Color.yellow, 2);
    [SerializeField]
    ColorAndPriority SelectedColor = new ColorAndPriority(Color.black, 10);
    [SerializeField]
    ColorAndPriority BaseColor = new ColorAndPriority(OriginalColor, 1);



    
    public class StateControllerClass {
        private bool _playerCanMoveToThisState = false;
        private bool _stateIsSelected = false;
        public bool PlayerCanMoveToThisState { get => _playerCanMoveToThisState ; set { _playerCanMoveToThisState = value;}}
        public bool StateIsSelected {get => _stateIsSelected ; set {_stateIsSelected = value;}}
    }

    public StateControllerClass stateControl;

    void HighlightStateAccordingToStateDictionary(Dictionary<string, GameObject> dict) {
        if (dict.ContainsKey(this.gameObject.name)) {
            this.gameObject.GetComponent<SpriteRenderer>().color = HighlightedColor;
        }
    }

    public void ColorManager() {
        if (stateControl.StateIsSelected) {
            spriteRenderer.color = SelectedColor;
        }
    }


    private void OnMouseOver() {
        
        spriteRenderer.color = Color.green;
    }
    
    private void OnMouseExit() {
        spriteRenderer.color = OriginalColor;
        GameManager._gameManager.TentativeState_Deslected();
    }

    private void Awake() {
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
    OriginalColor = spriteRenderer.color;  
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
