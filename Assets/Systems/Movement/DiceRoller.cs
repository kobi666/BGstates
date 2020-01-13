using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int RollDice()
    {
        return Random.Range(1, 6);
    }
}
