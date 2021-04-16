using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScript : MonoBehaviour
{

    SavePlayerPosition playerPosData;

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPosition>();
        playerPosData.PlayerPosLoad();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
