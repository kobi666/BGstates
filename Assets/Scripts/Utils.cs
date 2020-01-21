using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // Start is called before the first frame update
    const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
    int charAmount = Random.Range(minCharAmount, maxCharAmount); //set those to the minimum and maximum length of your string
 for(int i=0; i<charAmount; i++)
 {
     myString += glyphs[Random.Range(0, glyphs.Length)];
 }
}
