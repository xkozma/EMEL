using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class logScribbler : MonoBehaviour
{
    string path = "Assets/Resources/timelogs.txt";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void stringWrite(string time)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(time);
        writer.Close();
        
    }
}
