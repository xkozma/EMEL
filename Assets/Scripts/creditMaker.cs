using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditMaker : MonoBehaviour
{
    public GameObject credits;
    public GameObject tasks;
    public GameObject clock;
    public GameObject timer;
    bool isWritten = false;
    // Start is called before the first frame update
    void Start()
    {
        tasks.SetActive(false);
        credits.SetActive(true);
        clock.SetActive(false);
        if (!isWritten)
        {
            timer.GetComponent<TimeScript>().nameTask = "Dungeon run ";
            timer.GetComponent<TimeScript>().writeNow = true;

            isWritten = true;
        }
        StartCoroutine(destroyCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroyCo()
    {
        yield return new WaitForSeconds(20f);
        credits.SetActive(false);
    }
}
