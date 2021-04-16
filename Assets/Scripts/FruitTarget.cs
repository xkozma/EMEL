using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTarget : MonoBehaviour
{   private float basicScale = 1.0f;
    public GameObject counter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.localScale = this.transform.localScale*1.01f;
            basicScale = basicScale * 1.01f;
            if (basicScale > 2.0f)
            {
                winScript.pointsStorage = winScript.pointsStorage + 1;

                this.gameObject.SetActive(false);

                Debug.Log("Trigger");
            }
        }
        if (other.CompareTag("cross"))
        {
            this.transform.localScale = this.transform.localScale * 1.01f;
            basicScale = basicScale *1.01f; ;
            if (basicScale > 2.0f)
            {
                winTask.pointsStorage = winTask.pointsStorage + 1;
                this.gameObject.SetActive(false);

                Debug.Log("Trigger");
            }
        }
    }
}
