using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInspect : MonoBehaviour
{

    public Transform player;

    //public DialogueSystem dialogueSystem;
    //public Dialogue dialogueOnInspection;
    public int myQuestID;
    public QuestManager questManager;
    public Quest endQuest;

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 6f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (questManager.GetMainQuestID() == myQuestID)
                {
                    //dialogueSystem.StartDialogue(dialogueOnInspection);
                    //StartCoroutine(WaitForDialogueEnd());
                    AdvanceQuest();
                }
            }
        }
    }
    private void AdvanceQuest()
    {
        if (endQuest != null && questManager != null)
        {
            questManager.CompliteQuest(endQuest);
        }
    }
    //private IEnumerator WaitForDialogueEnd()
    //{
    //    yield return new WaitUntil(() => (!dialogueSystem.GetDialogueState()));
    //    //Debug.Log("WaitForDialogueEnd ended by " + questDialogue.name);
    //    AdvanceQuest();
    //}
}
