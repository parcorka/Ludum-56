using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    private bool complited;
    private bool isActive;
    //public string objective;
    //public ??? reward;

    public void StartQuest()
    {
        isActive = true;
        //do smth
    }
    public void CompliteQuest()
    {
        complited = true;
        isActive = false;
        //do smth
    }
    public bool Complited
    {
        get { return complited; }
        //set { complited = value; }
    }
    public bool IsActive
    {
        get { return isActive; }
        //set { isActive = value; }
    }
}
