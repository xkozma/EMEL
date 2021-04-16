using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverScript : Interactable
{
    // Start is called before the first frame update
    public float delayTime;
    public GameObject shownObject;
    private float help;
    public bool isReadyToRoll;
    void Start()
    {
        isReadyToRoll = false;
        help = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToRoll)
        {
            shownObject.SetActive(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cross"))
        {
            delayTime = help;
            delayTime += Time.time;
            //Debug.Log(Time.time);
            // Debug.Log(delayTime);
            isReadyToRoll = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("cross"))
        {
            if (Time.time > delayTime)
            {
                Debug.Log("Teraz to bolo 5 sekund!");
                isReadyToRoll = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("cross"))
        {
            isReadyToRoll = false;
        }
    }

}
