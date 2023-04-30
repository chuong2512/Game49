using System.Collections;
using System.Collections.Generic;
using JumpFrog;
using TMPro;
using UnityEngine;

public class TheLevelTMP : Singleton<TheLevelTMP>
{
    public TextMeshProUGUI textMeshProUgui;

    public int point;


    // Start is called before the first frame update
    void OnEnable()
    {
        point = 0;
        textMeshProUgui.SetText($"0");
    }

    public void Add()
    {
        if (GameManager.Instance.currentState == State.Playing)
        {
            point++;
            textMeshProUgui.SetText($"{point}");
        }
    }
}