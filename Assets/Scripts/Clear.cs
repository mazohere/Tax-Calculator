using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Clear : MonoBehaviour
{
    public Text a;
    public Text b;
    public Text c;

    void Start()
    {
        a.text = "";
        b.text = "";
        c.text = "";
    }

    public void ClearText()
    {
        a.text = "";
        b.text = "";
        c.text = "";
    }
}
