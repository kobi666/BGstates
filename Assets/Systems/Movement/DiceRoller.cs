using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    #region DEBUG

#if UNITY_EDITOR

    public int Dice;
    public bool debug;
    int formerDiceRoll = 0;
    private Text _txt;

    private void Awake()
    {
        var go = new GameObject("DEBUG CANVAS");
        var c = go.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;

        var box = new GameObject("box");
        box.transform.parent = c.transform;
        var rbox = box.AddComponent<RectTransform>();
        rbox.anchorMin = Vector2.one;
        rbox.anchorMax = Vector2.one;
        rbox.pivot = Vector2.one;
        rbox.anchoredPosition = Vector2.zero;

        var img = box.AddComponent<Image>();
        img.color = Color.black;

        var txtG = new GameObject("Text");
        txtG.transform.parent = box.transform;
        _txt = txtG.AddComponent<Text>();

        _txt.text = "1-6";
        _txt.resizeTextForBestFit = true;
        _txt.font = Font.CreateDynamicFontFromOSFont("Arial", 34);
        _txt.alignment = TextAnchor.MiddleCenter;
        _txt.rectTransform.anchoredPosition = Vector2.zero;
    }

    private void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Dice = RollDice();
            }
        }
    }

#endif

    #endregion


    public int RollDice()
    {
#if UNITY_EDITOR
        
        var r = Random.Range(1, 7);
        if (r == formerDiceRoll) {
            int rr = Random.Range(1,3);
            if(rr == 2) {
                r = Random.Range(1, 7);
            }
        }
        


        if (debug)
        
        {
            _txt.text = r.ToString();
        }
        
        return r;
#endif
    }
}
