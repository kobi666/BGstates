using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerClass : MonoBehaviour
{
    // Start is called before the first frame update
        private bool _playerCanMoveToThisState = false;
        public bool StatePreSelected() {
            if (StateManager._stateManager.SelectedState != null) {
                if (StateManager._stateManager.SelectedState.name == this.gameObject.name) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else { return false;}
        }
        public bool PlayerCanMoveToThisState { get => _playerCanMoveToThisState ; set { _playerCanMoveToThisState = value;}}
        //public bool StatePreSelected {get => _statePreSelected ; set {_statePreSelected = value;}}




        
    
}
