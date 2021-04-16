using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.U))
        {
            playerPosition.PlayerPosSave();
            
        }
    }
}
