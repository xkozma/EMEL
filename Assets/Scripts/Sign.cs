using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private bool lookingAt = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.F) && playerInRange){
        if (playerInRange && lookingAt)
        {
          //  if (dialogBox.activeInHierarchy){
               // dialogBox.SetActive(false);
          //  }
            //else{
            
                dialogBox.SetActive(true);
                dialogText.text = dialog;
           // }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
        if (other.CompareTag("cross"))
        {
            lookingAt = false;
            
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
        }
        if (other.CompareTag("cross"))
        {
            lookingAt = true;

        }

    }

}
