using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public PlayerMovement pm;
    public CameraController mc;
    public PullOutPutAway popa; // da popa

    public AudioSource audioSource;

    public GameObject dialogueContainer;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    private string defaultName;
    private float defaultTextSpeed;
    [SerializeField] AudioClip defaultTalkSound;

    private Queue<Sentence> sentencesQueue;
    private bool dialogueState; // are we in dialogue rn?

    private void Awake()
    {
        sentencesQueue = new Queue<Sentence>();
        dialogueState = false;
        defaultTextSpeed = 0.05f;
        defaultName = "???";
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
        //if(Input.GetKeyDown(KeyCode.T)) 
        //{
        //    Debug.Log("Playing"); 
        //    audioSource.Stop();
        //    audioSource.clip = defaultTalkSound;
        //    audioSource.Play();
        //}
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
        popa.DialogueTime();

        sentencesQueue.Clear();
        //nameText.text = dialogue.name;
        //this.textSpeed = dialogue.textSpeed;

        foreach (Sentence sentence in dialogue.sentences)
        {
            
            sentencesQueue.Enqueue(sentence);
        }
    }
    private void DisplayNextSentance()
    {
        string sentence, name;
        AudioClip talkSound;
        float textSpeed;
        if (sentencesQueue.Count == 0)
        {
            EndDialogue(); // no sentences left then end dialogue
            return;
        }

        Sentence newSentence = sentencesQueue.Dequeue();
        
        sentence = newSentence.sentence;
        if(newSentence.talkSound != null)
        {
            talkSound = newSentence.talkSound;
        }
        else
        {
            talkSound = defaultTalkSound;
        }
        if(newSentence.name != null)
        {
            name = newSentence.name;
        }
        else
        {
            name = defaultName;
        }
        if (newSentence.textSpeed != null)
        {
            textSpeed = newSentence.textSpeed;
        }
        else
        {
            textSpeed = defaultTextSpeed;
        }

        StopAllCoroutines(); // stop currently running sentence
        StartCoroutine(TypeSentance(sentence, talkSound, name, textSpeed));
    }
    private void EndDialogue()
    {
        dialogueContainer.SetActive(false);
        pm.UnlockMovement();
        mc.mouse_sens = 10;
        popa.FreeZoom();
        dialogueState = false;
    }

    private IEnumerator TypeSentance(string sentence, AudioClip talkSound, string name, float textSpeed)
    {
        nameText.text = name;
        dialogueText.text = "";
        audioSource.clip = talkSound;
        audioSource.Play();
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        audioSource.Stop();
    }
}
