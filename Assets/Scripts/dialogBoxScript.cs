using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBoxScript : hoverScript
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private bool coroutineStarted;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        coroutineStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToRoll && playerInRange)
        {

            if (shownObject.activeInHierarchy && !coroutineStarted)
            {
                coroutineStarted = true;
                StartCoroutine(WaitCo());
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                shownObject.SetActive(true);
                

            }
        }
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        if (other.CompareTag("cross"))
        {
            isReadyToRoll = true;
        }

    }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;

            }
        }
    
    IEnumerator WaitCo()
    {

        yield return new WaitForSeconds(4f);
        dialogBox.SetActive(false);
        dialogText.text = dialog;
        shownObject.SetActive(false);
        isReadyToRoll = false;
        if (credits != null)
        {
            credits.SetActive(true);
        }
        coroutineStarted = false;

    }

    
}
