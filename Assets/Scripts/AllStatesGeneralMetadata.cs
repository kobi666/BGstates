using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStatesGeneralMetadata : MonoBehaviour
{
    public static AllStatesGeneralMetadata AllStatesObj;
    // Start is called before the first frame update
    public Color HighlightColor;
    public Color SelectColor;
    public Color DemocraticColor;
    public Color RepublicanColor;

    private void Awake() {
        AllStatesObj = this;
    }
}
