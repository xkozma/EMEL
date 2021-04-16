using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{

    public PlayerState currentState;
    private Animator animator;
    public GameObject flashCone;
    public GameObject flashCircle;
    public bool isInDungeon;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        isInDungeon = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(PlowCo());
        }
        if (Input.GetButtonDown("Fire2") && isInDungeon)
        {
            if (flashCone.activeSelf == false)
            {
                flashCone.SetActive(true);
                flashCircle.SetActive(true);
            }
            else
            {
                flashCone.SetActive(false);
                flashCircle.SetActive(false);
            }
        }

    }
    private IEnumerator PlowCo()
    {
        
        animator.SetBool("plowing", true);
        yield return null;
        animator.SetBool("plowing", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
}
