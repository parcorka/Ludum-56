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
    public Quest endQuest;

    private void Start()
    {
        if (questManager.GetMainQuestID() == myQuestID)
        {
            dialogueSystem.StartDialogue(questDialogue);
            //Debug.Log("Quest dialogue by " + questDialogue.name);
            StartCoroutine(WaitForDialogueEnd());
            //Debug.Log("StartCoroutine by " + questDialogue.name);
        }
    }
    //private void OnMouseOver()
    //{
    //    if (Vector3.Distance(player.transform.position, this.transform.position) <= 5f)
    //    {
    //        if (!dialogueSystem.GetDialogueState())
    //        {
    //            popUp.SetActive(true);
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                //Debug.Log(questManager.GetMainQuestID() + " == " + myQuestID);
    //                if (questManager.GetMainQuestID() == myQuestID)
    //                {
    //                    dialogueSystem.StartDialogue(questDialogue);
    //                    //Debug.Log("Quest dialogue by " + questDialogue.name);
    //                    StartCoroutine(WaitForDialogueEnd());
    //                    //Debug.Log("StartCoroutine by " + questDialogue.name);
    //                }
    //                else
    //                {
    //                    if (interactionCount == 0 && firstDialogue.sentences != null)
    //                    {
    //                        interactionCount++;
    //                        dialogueSystem.StartDialogue(firstDialogue);
    //                    }
    //                    else
    //                    {
    //                        dialogueSystem.StartDialogue(secondDialogue);
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            popUp.SetActive(false);
    //        }
    //    }
    //}
    private void AdvanceQuest()
    {
        if (endQuest != null && questManager != null)
        {
            questManager.CompliteQuest(endQuest);
        }
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
        yield return new WaitUntil(() => (!dialogueSystem.GetDialogueState()));
        //Debug.Log("WaitForDialogueEnd ended by " + questDialogue.name);
        AdvanceQuest();
    }
}
