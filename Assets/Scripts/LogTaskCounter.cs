using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTaskCounter : MonoBehaviour
{
    public static int points;
    public int needed;
    public GameObject cross;
    bool isWritten = false;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points == needed && !isWritten)
        {
            cross.SetActive(true);
            taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
            Debug.Log("Vyhral si LogTask!");
            points = 0;
            timer.GetComponent<TimeScript>().nameTask = "Log Task";
            timer.GetComponent<TimeScript>().writeNow = true;

            isWritten = true;
        }
    }
}
