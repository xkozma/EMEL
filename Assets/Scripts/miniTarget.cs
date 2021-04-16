using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniTarget : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.tag == "fireplace")
            {
                winScript.pointsFire = winScript.pointsFire + 1;
            }
            else
            {
                winScript.pointsShip = winScript.pointsShip + 1;
            }
            
            this.gameObject.SetActive(false);
            
            Debug.Log("Trigger");
        }
        if (other.CompareTag("cross"))
        {


            //winTask.points = winTask.points + 1;
            this.gameObject.SetActive(false);
            if (this.tag == "fireplace")
            {
                winTask.pointsFire = winTask.pointsFire + 1;
            }
            else if (this.tag == "clone")
            {
                winTask.pointsShip = winTask.pointsShip + 1;
            }
            else if(this.tag!="fireplace" && this.tag!="clone")
            {
                winTask.pointsStorage = winTask.pointsStorage + 1;
            }

            Debug.Log("Trigger");
        }
    }
}
