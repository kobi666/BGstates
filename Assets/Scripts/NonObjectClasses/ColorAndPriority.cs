using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAndPriority : MonoBehaviour
{
        Color __color;
        int _priority;
        public ColorAndPriority(Color col, int pri) {
            this.__color = col;
            this._priority = pri;
        }
        public Color _color {get => __color ; }
    
}
