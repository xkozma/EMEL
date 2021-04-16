using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Victory")
        {
            win = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");

        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGame()
    { 
        SceneManager.LoadScene("SampleScene");
    }
    public void Quitter()
    {
        if (win)
        {
            PlayerPrefs.DeleteKey("p_x");
            PlayerPrefs.DeleteKey("p_y");
            PlayerPrefs.DeleteKey("TimeToLoad");
            PlayerPrefs.DeleteKey("Saved");
        }
        Application.Quit();
    }
}
