using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    public Transform player;
    public DialogueSystem dialogueSystem;
    public GameObject popUp;
    public Dialogue firstDialogue; // dialogue for first interaction
    public Dialogue secondDialogue; // dialogue for all other interactions
    protected int interactionCount;

    //public GameObject dialogueContainer;
    //public TextMeshProUGUI dialogueText;
    //public TextMeshProUGUI nameText;

    //public QuestManager questManager;
    //public Quest startQuest;
    //public Quest endQuest;

    //private Queue<string> sentencesQueue;
    //private bool dialogueState;

    //private void Awake()
    //{
    //    sentencesQueue = new Queue<string>();
    //    dialogueState = false;
    //}
    private void Start()
    {
        interactionCount = 0;
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 5f)
        {
            if (!dialogueSystem.GetDialogueState())
            {
                popUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(interactionCount == 0 && firstDialogue.sentences != null)
                    {
                        interactionCount++;
                        dialogueSystem.StartDialogue(firstDialogue);
                    }
                    else
                    {
                        dialogueSystem.StartDialogue(secondDialogue);
                    }
                    //StartCoroutine(WaitForDialogueEnd());
                }
            }
            else
            {
                popUp.SetActive(false);
            }
        }
    }
    protected void OnMouseExit()
    {
        popUp.SetActive(false);
    }
    //private void AdvanceQuest()
    //{
    //    if (endQuest != null && questManager != null)
    //    {
    //        questManager.CompliteQuest(endQuest);
    //    }
    //    if (startQuest != null && questManager != null)
    //    {
    //        if (!startQuest.IsActive)
    //        {
    //            questManager.StartQuest(startQuest);
    //        }
    //    }
    //}
    //private IEnumerator WaitForDialogueEnd()
    //{
    //    yield return new WaitUntil(() => (!dialogueSystem.GetDialogueState()));
    //    AdvanceQuest();
    //}
}
