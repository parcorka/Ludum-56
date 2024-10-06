using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestList : MonoBehaviour // not being used
{
    public QuestManager questManager;
    public GameObject questNameUI;
    public GameObject questTextUI;
    
    private void ClearQuestLog()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    //public void DisplayActiveQuests()
    //{
    //    foreach (Quest quest in questManager.activeQuests)
    //    {
    //        //GameObject questElement = Instantiate(GameAssets.i.uiQuest, transform);
    //        //GameObject[] children = questElement.GetComponentsInChildren();
    //        GameObject questNameObj = Instantiate(questNameUI, transform);
    //        TextMeshProUGUI textComponent = questText.GetComponent<TextMeshProUGUI>();

    //        if(textComponent != null )
    //        {
    //            textComponent = 
    //        }
    //    }
    //}
}
