using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public float textSpeed = 0.01f;
    [TextArea(2, 10)]
    public string[] sentences;
}
