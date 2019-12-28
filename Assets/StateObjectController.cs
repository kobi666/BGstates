using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObjectController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color HoverColor = Color.green;
    Color OriginalColor;
    private void OnMouseEnter() {
        spriteRenderer.color = Color.green;
        GameManager._gameManager.TentativeStateSelected(this.gameObject);
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
