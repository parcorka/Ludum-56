using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Dialogue questDialogue;
    public int myQuestID = 0;

    public QuestManager questManager;
    public Quest startQuest;

    private void Start()
    {
        if (questManager.GetMainQuestID() == myQuestID)
        {
            StartCoroutine(WaitForDialogueEnd());
        }
    }
    private void AdvanceQuest()
    {
        if (startQuest != null && questManager != null)
        {
            if (!startQuest.IsActive)
            {
                questManager.StartQuest(startQuest);
            }
        }
    }
    private IEnumerator WaitForDialogueEnd()
    {
        yield return new WaitForSeconds(2f);
        dialogueSystem.StartDialogue(questDialogue);
        yield return new WaitUntil(() => (!dialogueSystem.GetDialogueState()));
        //Debug.Log("WaitForDialogueEnd ended by " + questDialogue.name);
        AdvanceQuest();
    }
}