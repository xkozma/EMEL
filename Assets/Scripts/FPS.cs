using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public int FrameRate;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = FrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = FrameRate;
    }
}
