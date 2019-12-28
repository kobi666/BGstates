using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    // Start is called before the first frame update

    MovementController _movementController;
    
    private void Awake() {
        _movementController = gameObject.GetComponent<MovementController>();
    }
    void Start()
    {
        TurnManager._turnManager.onTurnStarted += InitilizePlayerTurn;
    }

    private void InitilizePlayerTurn() {
        _movementController.MovementPoints(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
