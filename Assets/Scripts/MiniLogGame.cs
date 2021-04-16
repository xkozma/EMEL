using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLogGame : Interactable
{
    public int NumberOfDock;
    public int NumberOfTree;
    public bool NPCInRange;
    private LogScr log;
    // Start is called before the first frame update
    void Start()
    {
        NPCInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPCLog"))
        {
            NPCInRange = true;
            log = other.GetComponent<LogScr>();
            if (log.NumberOfTree == NumberOfDock)
            {
                Debug.Log("Spravne!");
                log.isDocked = true;
                LogTaskCounter.points = LogTaskCounter.points + 1;

            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPCLog"))
        {
            NPCInRange = false;

        }

    }
}
