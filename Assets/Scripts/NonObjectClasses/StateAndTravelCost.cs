using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAndTravelCost
{
    public GameObject GO {get ; set ;}
    public int TC {get ; set ;}
    public StateAndTravelCost(GameObject _go, int _tc ) {
        GO = _go;
        TC = _tc;

    }
}
