using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TimeScript : MonoBehaviour
{
    public float seconds, minutes, mili;
    public Text text;
    float upTime;
    public bool writeNow = false;
    public string nameTask;
    string path;
    float initializationTime = 0f;


    // Start is called before the first frame update

    public void Start()
    {
        path = Application.dataPath + "/timelogs.txt";
        upTime = Time.timeSinceLevelLoad;
        //upTime = Time.timeSinceLevelLoad;

    }

    // Update is called once per frame
    void Update()
    {
        if (writeNow) {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(System.DateTime.Now + " Time was: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + mili.ToString("00") + " on task " + nameTask);
            writer.Close();
            writeNow = false;
        }

        minutes = (int)((Time.timeSinceLevelLoad - upTime + initializationTime) / 60f);
        seconds = (int)((Time.timeSinceLevelLoad - upTime + initializationTime) % 60);
        mili = (int)(((Time.timeSinceLevelLoad - upTime + initializationTime) * 1000) % 1000f) / 10.1f;
        text.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + mili.ToString("00");


    }
    public void setLastTime()
    {
        initializationTime = Time.timeSinceLevelLoad - upTime + initializationTime;
    }
}
