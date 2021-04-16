using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantsGrown : MonoBehaviour
{
    public static int points = 0;
    public int need;
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
        if (points > need - 1 && !isWritten)
        {
            cross.SetActive(true);
            Debug.Log("You Win Plowing!");
            taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
            points = -1000;
            isWritten = true;
            timer.GetComponent<TimeScript>().nameTask = "Garden Task";
            timer.GetComponent<TimeScript>().writeNow = true;


        }
    }
}
