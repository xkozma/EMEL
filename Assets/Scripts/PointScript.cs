using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public float speed;
    public float points;
    public float pointsNeeded = 0;
    public EyeTracking et;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointScript();
    }
    void pointScript()
    {
        change = Vector3.zero;
        speed = 1;

        Vector3 crossPosition = new Vector3();
        if (!et.isActivated) { crossPosition = Input.mousePosition; }
        else { crossPosition = new Vector3(et.newX, et.newY, 0); }
        crossPosition = Camera.main.ScreenToWorldPoint(crossPosition);

        Vector2 direction = new Vector2(crossPosition.x - transform.position.x,
            crossPosition.y - transform.position.y);
        transform.up = direction;
        Vector3 temp = Vector3.MoveTowards(crossPosition, direction, speed * Time.deltaTime);
        myRigidbody.MovePosition(temp);
        
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        
        if (points > pointsNeeded)
        {
            Debug.Log("You Win!");
        }
    }
}
