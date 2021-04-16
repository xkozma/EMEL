using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointAndDo : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    public GameObject crosshairs;
    private Vector3 scaleChange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));
        crosshairs.transform.position = new Vector2(target.x,target.y);
        scaleChange = new Vector3(0.1f,0.1f,0);
        if(Input.GetButton("Fire1")){
            crosshairs.transform.localScale = new Vector3(0.2f,0.2f,0);
        }
        else{
            crosshairs.transform.localScale = new Vector3(0.1f,0.1f,0);
        }
    }
}
