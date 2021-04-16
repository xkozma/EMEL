using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightScript : Interactable
{
    public GameObject lightSpace;
    public GameObject press;
    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) { press.SetActive(true); }
        if (Input.GetKeyDown(KeyCode.F) && playerInRange)
        {
            if (lightSpace.activeInHierarchy)
            {
                lightSpace.SetActive(false);
            }
            else
            {
                lightSpace.SetActive(true);
                
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            press.SetActive(false);
            
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
