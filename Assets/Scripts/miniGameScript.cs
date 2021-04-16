using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniGameScript : Interactable
{

    SavePlayerPosition playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<SavePlayerPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange)
        {
            playerPosition.PlayerPosSave();
            SceneManager.LoadScene("MiniGame");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            
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
