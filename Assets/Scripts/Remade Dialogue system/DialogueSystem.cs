using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    PlayerMovement pm;
    CameraController mc;

    //public GameObject popUp;

    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    private Queue<string> sentencesQueue;
    private bool dialogueState; // are we in dialogue rn?

    private void Awake()
    {
        sentencesQueue = new Queue<string>();
        dialogueState = false;
        pm = player.GetComponent<PlayerMovement>();
        mc = camera.GetComponent<CameraController>();
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
    public void StartDialogue(string[] sentences, string name)
    {
        dialogueContainer.SetActive(true);
        dialogueState = true;
        sentencesQueue.Clear();
        nameText.text = name;

        pm.speed = 0; // lock movement
        mc.mouse_sens = 0;

        foreach (string sentence in sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }

        DisplayNextSentance();
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
        pm.speed = 10;
        mc.mouse_sens = 10;
        dialogueState = false;
    }

    IEnumerator TypeSentance(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
