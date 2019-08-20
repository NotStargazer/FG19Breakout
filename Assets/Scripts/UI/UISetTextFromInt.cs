using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISetTextFromInt : MonoBehaviour
{
    TextMeshProUGUI TMP;

    private void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    public void SetTextFromInt(int value)
    {
        TMP.text = value.ToString().PadLeft(2, '0');
    }
}
