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
    //public GameObject dialogueContainer;
    //public TextMeshProUGUI dialogueText;
    //public TextMeshProUGUI nameText;

    public string name;
    [TextArea(2, 10)]
    public string[] sentences;

    //private Queue<string> sentencesQueue;
    //private bool dialogueState;

    //private void Awake()
    //{
    //    sentencesQueue = new Queue<string>();
    //    dialogueState = false;
    //}

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 5f)
        {
            if (!dialogueSystem.GetDialogueState())
            {
                popUp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogueSystem.StartDialogue(sentences, name);
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

    //private void StartDialogue()
    //{
    //    dialogueState = true;
    //    sentencesQueue.Clear();
    //    foreach (string sentence in sentences)
    //    {
    //        sentencesQueue.Enqueue(sentence);
    //    }
    //    dialogueContainer.SetActive(true);
    //    DisplayNextSentance();
    //}
    //private void DisplayNextSentance()
    //{
    //    if(sentencesQueue.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }
    //    nameText.text = name;
    //    dialogueText.text = sentencesQueue.Dequeue();
    //}
    //private void EndDialogue()
    //{
    //    dialogueContainer.SetActive(false);
    //    dialogueState = false;
    //}
}
