using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taskCount : MonoBehaviour
{
    public static int tasksCompleted = 0;
    public int need;
    private bool shown = false;
    public GameObject door;
    public GameObject portal;
    public GameObject notice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shown && tasksCompleted > need - 2)
        {
            shown = true;
            notice.SetActive(true);
            door.SetActive(false);
            portal.SetActive(true);
        }
        if (tasksCompleted > need - 1)
        {
            Debug.Log("You Win Absolutely!");
            
            
            tasksCompleted = 0;
            SceneManager.LoadScene("Victory");

        }
    }
}
