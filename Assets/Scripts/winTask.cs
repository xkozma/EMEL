using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winTask : MonoBehaviour
{
    public static int points = 0;
    public int need;
    public GameObject MiniGame;
    private pauseScript pausePanel;
    private taskLock tlock;
    private miniTask minitask;
    public GameObject winText;
    public GameObject cross;
    public GameObject list;
    public GameObject conv;
    public GameObject tracker;
    public GameObject timer;
    public static int pointsFire = 0;
    public int needFire;
    public static int pointsShip = 0;
    public int needShip;
    public static int pointsStorage = 0;
    public int needStorage;

    bool isWritten = false;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel = FindObjectOfType<pauseScript>();
        tlock = MiniGame.GetComponent<taskLock>();
        minitask = MiniGame.GetComponent<miniTask>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsFire > needFire - 1)
        {
            Debug.Log("You Win!");

            // playerPosData.PlayerPosLoad();
            pointsFire = 0;
            pausePanel.isPaused = false;
            StartCoroutine(ShowWin());

        }
        if (pointsShip > needShip - 1)
        {
            Debug.Log("You Win!");

            // playerPosData.PlayerPosLoad();
            pointsShip = 0;
            pausePanel.isPaused = false;
            StartCoroutine(ShowWin());

        }
        if (pointsStorage > needStorage - 1)
        {
            Debug.Log("You Win!");
            pointsStorage = 0;
            // playerPosData.PlayerPosLoad();

            pausePanel.isPaused = false;
            StartCoroutine(ShowWin());

        }
    }
    private IEnumerator ShowWin()
    {
        winText.SetActive(true);
        if (!isWritten)
        {
            timer.GetComponent<TimeScript>().nameTask = MiniGame.name;
            timer.GetComponent<TimeScript>().writeNow = true;
            
            isWritten = true;
        }
        yield return new WaitForSeconds(1f);
        
        winText.SetActive(false);
        taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
        points = 0;
        tracker.SetActive(true);
        list.SetActive(true);
        MiniGame.SetActive(false);
        cross.SetActive(true);
        conv.SetActive(false);
        tlock.LockThis();

    }
    }
