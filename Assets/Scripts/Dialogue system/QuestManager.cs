using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests = new List<Quest>();
    public List<Quest> complitedQuests = new List<Quest>(); // do we need these?

    public GameObject questUIContainer;
    public TextMeshProUGUI questUIName;
    public TextMeshProUGUI questUIText;

    private int mainQuestID; // better intaractions with quest npc (they will check if they need to give a quest)
    public QuestBlockRemoval blockMove;

    private void Start()
    {
        mainQuestID = 0;
    }
    public int GetMainQuestID()
    {
        return mainQuestID;
    }

    public void StartQuest(Quest quest)
    {
        if(!quest.Complited && !quest.IsActive)
        {
            quest.StartQuest();
            activeQuests.Add(quest);

            questUIContainer.SetActive(true);
            questUIName.text = quest.questName;
            questUIText.text = quest.description;

            mainQuestID++;
            if (mainQuestID == 7)
            {
                blockMove.MoveBlock();
            }
        }
    }
    public void CompliteQuest(Quest quest)
    {
        if(quest.IsActive && !quest.Complited)
        {
            quest.CompliteQuest();
            activeQuests.Remove(quest);
            complitedQuests.Add(quest);

            questUIContainer.SetActive(false);
        }
    }
    public bool IsQuestActive(string questName)
    {
        foreach(Quest quest in activeQuests)
        {
            if(quest.questName == questName)
            {
                return true;
            }
        }
        return false;
    }
}
