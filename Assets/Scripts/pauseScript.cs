using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour

{
    public bool isPaused;
    public GameObject pausePanel;
    public miniTask task;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        task = FindObjectOfType<miniTask>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !task.isActivated)
        {
            Debug.Log(task.isActivated);
            Resume();
        }

    }
    public void Resume()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }
    public void QuitToDT()
    {
        SceneManager.LoadScene("StartScene");
    }

}
