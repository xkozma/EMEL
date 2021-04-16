using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    public static int pointsFire = 0;
    public int needFire;
    public static int pointsShip = 0;
    public int needShip;
    public static int pointsStorage = 0;
    public int needStorage;
    SavePlayerPosition playerPosData;


    // Start is called before the first frame update
    void Start()
    {
       // playerPosData = FindObjectOfType<SavePlayerPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsFire > needFire-1)
        {
            Debug.Log("You Win!");
            
           // playerPosData.PlayerPosLoad();
            SceneManager.LoadScene("SampleScene");
            taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
            pointsFire = 0;

        }
        if (pointsShip > needShip - 1)
        {
            Debug.Log("You Win!");

            // playerPosData.PlayerPosLoad();
            SceneManager.LoadScene("SampleScene");
            taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
            pointsShip = 0;

        }
        if (pointsStorage > needStorage - 1)
        {
            Debug.Log("You Win!");

            // playerPosData.PlayerPosLoad();
            SceneManager.LoadScene("SampleScene");
            taskCount.tasksCompleted = taskCount.tasksCompleted + 1;
            pointsStorage = 0;

        }
    }
}
