using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMetaData : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> BoarderingStates;

    void removeNullValuesFromTopOfList(List<GameObject> list) {
        for(int i = list.Count-1 ; i >= 0 ; i--) {
            if (list[i] == null) {
                list.RemoveAt(i);
            }
        }
        
       

    }
    void Start()
    {
        removeNullValuesFromTopOfList(BoarderingStates);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
