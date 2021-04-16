using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniTask : Interactable
{
    public bool isActivated;
    public GameObject MiniGame;
    private pauseScript pausePanel;
    private taskLock tlock;
    public GameObject list;
    public GameObject bugfix;
    public GameObject tracker;
    public GameObject pressF;
    



    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        pausePanel = FindObjectOfType<pauseScript>();
        tlock = MiniGame.GetComponent<taskLock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && isActivated)
        {
            MiniGame.GetComponent<TimeScript>().setLastTime();
            CancelGame();

        }
        if (Input.GetKeyDown(KeyCode.F) && playerInRange && !tlock.isLocked)
        {
            isActivated = true;
            list.SetActive(false);
            tracker.SetActive(false);
            pausePanel.isPaused = true;

            MiniGame.SetActive(true);
            MiniGame.GetComponent<TimeScript>().Start();
            pressF.SetActive(false);

        }
        else if (playerInRange && !tlock.isLocked && !isActivated)
        {
            pressF.SetActive(true);
        }
        //else { pressF.SetActive(false); }
       // if (!playerInRange) { pressF.SetActive(false); }

    }
    public void CancelGame()
    {

        pausePanel.isPaused = false;
        bugfix.SetActive(false);
        tracker.SetActive(true);
        list.SetActive(true);
        
        MiniGame.SetActive(false);
        
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        StartCoroutine(ActiveCo());


    }

    IEnumerator ActiveCo()
    {
        yield return new WaitForSeconds(0.1f);

        isActivated = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            pressF.SetActive(false);

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

        }
    }

}
