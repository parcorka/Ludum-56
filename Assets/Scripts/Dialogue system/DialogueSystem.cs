using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public PlayerMovement pm;
    public CameraController mc;

    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    private float textSpeed;

    private Queue<string> sentencesQueue;
    private bool dialogueState; // are we in dialogue rn?

    private void Awake()
    {
        sentencesQueue = new Queue<string>();
        dialogueState = false;
    }

    private void Update()
    {
        if (dialogueState)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayNextSentance();
            }
        }
    }
    public bool GetDialogueState()
    {
        return dialogueState;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueContainer.SetActive(true);
        dialogueState = true;

        pm.LockMovement();
        mc.mouse_sens = 0;

        sentencesQueue.Clear();
        nameText.text = dialogue.name;
        this.textSpeed = dialogue.textSpeed;

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }
    }
    private void DisplayNextSentance()
    {
        if (sentencesQueue.Count == 0)
        {
            EndDialogue(); // no sentences left then end dialogue
            return;
        }
        string sentence = sentencesQueue.Dequeue();
        StopAllCoroutines(); // stop currently running sentence
        StartCoroutine(TypeSentance(sentence));
    }
    private void EndDialogue()
    {
        dialogueContainer.SetActive(false);
        pm.UnlockMovement();
        mc.mouse_sens = 10;
        dialogueState = false;
    }

    private IEnumerator TypeSentance(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //Add sound
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
