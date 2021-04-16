using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject testObject;
    GameObject newObj;
    Vector3 movePos;
    Vector3 position;
    bool reload = true;
    bool reloadstuck = true;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(WaitAndCalc());
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (newObj != null)
        {
            Vector3 newPos = Vector3.MoveTowards(newObj.transform.position, movePos, 4.0f * Time.deltaTime);
            newObj.transform.position = newPos;
            newObj.transform.localScale *= 1.01f;
        }
        else if (reload)
        {
            StartCoroutine(WaitAndCalc());
        }
        else if (reloadstuck)
        {
            Debug.Log("RELOAD STUCK");
            StartCoroutine(ReloadStuck());
        }






    }
    IEnumerator WaitAndCalc()
    {
        reload = false;
        reloadstuck = false;
        // execute block of code here
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            
            if (Random.Range(0f, 2f) > 1f)
            {
                position = new Vector3(Random.Range(-26.5f, -23f), Random.Range(5.3f, 5.5f), Random.Range(-10.0f, 10.0f));
            }
            else
            {
                position = new Vector3(Random.Range(-19f, -17.0f), Random.Range(5.3f, 5.5f), Random.Range(-10.0f, 10.0f));
            }
            GameObject newObject = Instantiate(testObject, position, Quaternion.identity);
            newObject.tag = "clone";
            movePos = new Vector3(Random.Range(-30.5f, -16.5f), Random.Range(0.0f, 9.0f), Random.Range(-20.0f, 20.0f));
            newObj = newObject;
            reload = true;
            reloadstuck = true;
            
            
        }






    }
    IEnumerator ReloadStuck()
    {
        reload = true;
        yield return new WaitForSeconds(2.0f);
        reloadstuck = true;
    }
}
