using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum PlayerState{
    walk,
    attack,
    interact
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private bool running;
    private bool handsup;
    private pauseScript pscript;
    public EyeTracking et;
    private bool isMovingTowards = false;

    SavePlayerPosition playerPosData;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        pscript = FindObjectOfType<pauseScript>();
        playerPosData = FindObjectOfType<SavePlayerPosition>();
        playerPosData.PlayerPosLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX",0);
        animator.SetFloat("moveY",-1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pscript.isPaused)
        {
            change = Vector3.zero;
            speed = 5;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Fire1"))
            {
                HandleIt();
            }
            if (Input.GetKey(KeyCode.Space)&& et.isActivated )
            {
                //float moveSpeed = 4;
                isMovingTowards = true;
                Vector3 crossPosition = new Vector3();
                crossPosition = new Vector3(et.newX, et.newY, 0);
                crossPosition = Camera.main.ScreenToWorldPoint(crossPosition);
                Vector3 temp = Vector3.MoveTowards(transform.position, crossPosition, speed* 3.0f * Time.deltaTime);
                changeAnim(temp - transform.position);
                //change.x = crossPosition.x;
                //change.y = crossPosition.y;
                myRigidbody.MovePosition(temp);
                animator.SetFloat("moveX", crossPosition.x - transform.position.x);
                animator.SetFloat("moveY", crossPosition.y - transform.position.y);
                animator.SetBool("moving", true);


            }
            else { isMovingTowards = false; }

            running = Input.GetKey(KeyCode.LeftShift);
            animator.SetBool("handsUp", Input.GetKey(KeyCode.LeftControl));

            if (change != Vector3.zero)
            {
                MoveCharacter();
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
                animator.SetBool("moving", true);

            }
            else if(!isMovingTowards)
            {
                animator.SetBool("moving", false);
            }
        }
       
    }
    /* private IEnumerator PlowCo(){
         animator.SetBool("plowing",true);
         yield return null;
         animator.SetBool("plowing",false);
         yield return new WaitForSeconds(.3f);
         currentState = PlayerState.walk;
     }*/
    private IEnumerator HandleIt()
    {
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        speed = 5;
    }
    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                setAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
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
    private void setAnimFloat(Vector2 setVector)
    {
        animator.SetBool("moving", true);
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }
    void MoveCharacter(){
        
        if(running.Equals(true)){
                speed = 7;
            }
            else{
                speed = 5;
            }
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
