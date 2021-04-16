using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;
public class EyeTracking : MonoBehaviour
{

    float x, y = 0.0f;
    public float newX, newY = 0.0f;
    public bool isActivated = false;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent()) // Use IsValid property instead to process old but valid data
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!isActivated)
                {
                    text.text = "Keyboard and EyeTracker";
                    isActivated = true;
                }
                else {
                    text.text = "Keyboard and Mouse";
                    isActivated = false; }
            }
            StartCoroutine(WaitAndCalc(gazePoint));
            
        }
        
    }
    IEnumerator WaitAndCalc(GazePoint gazePoint)
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.05f);
        x = gazePoint.Screen.x;
        y = gazePoint.Screen.y;
        //newX = Screen.width - x;
        // newY = Screen.height - y;
        newX = x;
        newY = y;

        //transform.position = new Vector3((-x+960)/90, (-y+540)/115, 1);
        Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(newX, newY, 0));

        temp.z = 0;
        transform.position = temp;
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x ,y,0));
        // Note: Values can be negative if the user looks outside the game view.
        //print("Gaze point on Screen (X,Y): " + x + ", " + y);
        //print("Gaze point on Screen (X,Y): " + transform.position.x + ", " + transform.position.y);
    }
}
