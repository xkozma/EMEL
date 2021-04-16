using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
using System.Security.Cryptography;
using UnityEngine;

public class LogScr : Enemy {

    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    public bool isFollowing;
    public int NumberOfTree;
    public bool isDocked;
    public EyeTracking et;
    public GameObject script;
    public GameObject crosshair;
    private bool deact = false;
    public GameObject press;


    // Start is called before the first frame update
    void Start()
    {
        
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        isFollowing = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        
    }

    void CheckDistance()
    {
        if (!isDocked)
        {

            if (!isFollowing)
            {

                if (Vector3.Distance(target.position, transform.position) < chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
                {
                    StartCoroutine(ActiveCo());
                    if (Input.GetKeyDown(KeyCode.F))
                    {

                        isFollowing = true;
                    }
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidbody.MovePosition(temp);

                    ChangeState(EnemyState.walk);
                    anim.SetBool("wakeUp", true);
                    anim.SetBool("Stay", false);
                }
                else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
                {

                    if (Input.GetKeyDown(KeyCode.F) && anim.GetBool("wakeUp"))
                    {

                        isFollowing = true;
                    }
                    anim.SetBool("wakeUp", false);
                    anim.SetBool("Stay", false);

                }
                else if (Vector3.Distance(target.position, transform.position) <= attackRadius + 0.1)
                {
                    StartCoroutine(ActiveCo());
                    anim.SetBool("Stay", true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        crosshair.SetActive(true);
                        script.SetActive(true);
                        isFollowing = true;
                    }
                }

            }
            else
            {
                press.SetActive(false);
                moveSpeed = 4;
                Vector3 crossPosition = new Vector3();
                if (!et.isActivated) { crossPosition = Input.mousePosition; }
                else { crossPosition = new Vector3(et.newX, et.newY, 0); }
                crossPosition = Camera.main.ScreenToWorldPoint(crossPosition);
                
                Vector3 temp = Vector3.MoveTowards(transform.position, crossPosition, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                //myRigidbody.MovePosition(temp);
                //Debug.Log(Vector3.Distance(target.position, transform.position));

                /* if (Vector3.Distance(crossPosition, transform.position) <= chaseRadius + 0.05 || Vector3.Distance(target.position, transform.position) <= attackRadius-0.5)
                 {
                     anim.SetBool("Stay", true);

                 }
                 else
                 {
                     */
                anim.SetBool("Stay", false);
                myRigidbody.MovePosition(temp);
                
                //}

            }
        }
        else
        {
            if (!deact)
            {
                crosshair.SetActive(false);
                deact = true;
            }
            anim.SetBool("wakeUp", false);
            anim.SetBool("Stay", false);
        }
    }

    private void setAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                setAnimFloat(Vector2.right);
            } else if (direction.x < 0)
            {
                setAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                setAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                setAnimFloat(Vector2.down);
            }
        }

    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
    IEnumerator ActiveCo()
    {
        press.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        press.SetActive(false);
        
    }
   
}
