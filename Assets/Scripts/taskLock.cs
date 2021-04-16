using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskLock : MonoBehaviour
{
    public bool isLocked;
    public GameObject handler;
    private miniTask task;
    // Start is called before the first frame update
    void Start()
    {
        isLocked = false;
        task = handler.GetComponent<miniTask>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    public void LockThis()
    {
        task.isActivated = false;
        this.gameObject.SetActive(false);
        isLocked = true;

    }
}
