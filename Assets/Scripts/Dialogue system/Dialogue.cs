using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public string name;
    //AudioClip talkSound;
    //public float textSpeed = 0.01f;
    //[TextArea(2, 10)]
    public Sentence[] sentences;
}

[System.Serializable]
public class Sentence
{
    public string name;
    public AudioClip talkSound;
    public float textSpeed = 0.01f;
    public string sentence;
}

