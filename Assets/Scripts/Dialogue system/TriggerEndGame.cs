using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TriggerEndGame : MonoBehaviour
{
    //public PlayerMovement pm;
    //public CameraController mc;
    //public PullOutPutAway popa; // da popa

    //public Transform player;
    //public Transform homyak;

    public Animator homAnimator;
    public GameObject blackOut;
    private bool startTimer = false;
    private float targetTime = 3f;
    private float targetTimeTwo = 5f;

    void Update()
    {
        if (startTimer)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                blackOut.SetActive(true);
                targetTimeTwo -= Time.deltaTime;
                if(targetTimeTwo <= 0.0f)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pm.LockMovement();
            //mc.mouse_sens = 0;
            //popa.DialogueTime();
            //mc.Look(homyak);
            homAnimator.SetTrigger("Turn");
            startTimer = true;
            //StopAllCoroutines();
            //StartCoroutine(EndGame());
        }
    }
    //private IEnumerable EndGame()
    //{
    //    yield return new WaitForSeconds(5f);
    //    blockOut.SetActive(true);
    //    yield return new WaitForSeconds(5f);
    //    SceneManager.LoadScene(2);
    //}
}
