using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growing : MonoBehaviour

{
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Grow(){
        
       if(animator.GetCurrentAnimatorStateInfo(0).IsName("PlantGrow")){
           animator.SetBool("isGrowing",true);
       }
       else{
        if(animator.GetBool("isGrowing")){
            animator.SetBool("isGrowing",false);
        }
        else{
            animator.SetBool("isGrowing",true);
        }
        
        StartCoroutine(GrowCo());}
    }
    IEnumerator GrowCo(){
        yield return new WaitForSeconds(46f);
        
        this.gameObject.SetActive(true);
        plantsGrown.points = plantsGrown.points + 1;
        Debug.Log("Vyrastla mrkva a pridal sa bod!");
    }
}
