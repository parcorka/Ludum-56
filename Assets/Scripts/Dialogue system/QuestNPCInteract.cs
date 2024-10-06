using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestNPCInteract : NPCInteract
{
    //public Transform player;
    //public DialogueSystem dialogueSystem;
    //public GameObject popUp;

    //public string name;
    //public float textSpeed = 0.1f;
    //[TextArea(2, 10)]
    //public string[] sentences;

    public Dialogue questDialogue;
    public int myQuestID;

    public QuestManager questManager;
    public Quest startQuest;
    public Quest endQuest;

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 5f)
        {
            if (!dialogueSystem.GetDialogueState())
            {
                popUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log(questManager.GetMainQuestID() + " == " + myQuestID);
                    if (questManager.GetMainQuestID() == myQuestID)
                    {
                        dialogueSystem.StartDialogue(questDialogue);
                        //Debug.Log("Quest dialogue by " + questDialogue.name);
                        StartCoroutine(WaitForDialogueEnd());
                        //Debug.Log("StartCoroutine by " + questDialogue.name);
                    }
                    else
                    {
                        if (interactionCount == 0 && firstDialogue.sentences != null)
                        {
                            interactionCount++;
                            dialogueSystem.StartDialogue(firstDialogue);
                        }
                        else
                        {
                            dialogueSystem.StartDialogue(secondDialogue);
                        }
                    }
                }
            }
            else
            {
                popUp.SetActive(false);
            }
        }
    }
    private void OnMouseExit()
    {
        popUp.SetActive(false);
    }
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
