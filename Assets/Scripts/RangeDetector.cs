using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    public GameObject Player;
    private dialogBoxScript script;
    // Start is called before the first frame update

    private void Start()
    {
        script = Player.GetComponent<dialogBoxScript>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            script.playerInRange = false;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            script.playerInRange = true;

        }

    }
}
