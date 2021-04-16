using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantWatering : MonoBehaviour
{
    SpriteRenderer sprite;
    growing grow;
    float r=1, g=1, b=1;
    public GameObject player;
    bool isGrown = false;
    public GameObject script;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        grow = GetComponent<growing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (r < 0.8f && !isGrown)
        {
            grow.Grow();
            isGrown = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        /*if (other.CompareTag("Player") && Vector3.Distance(player.transform.position, transform.position) <= 1 && !isGrown)
        {
            script.SetActive(true);
            r -= 0.001f;
            g -= 0.001f;
            b -= 0.001f;
            sprite.color = new Color(r, g, b, 1);
        }*/
        if (other.CompareTag("cross") && Vector3.Distance(player.transform.position, transform.position) <= 3 && !isGrown)
        {
            script.SetActive(true);
            r -= 0.001f;
            g -= 0.001f;
            b -= 0.001f;
            sprite.color = new Color(r, g, b, 1);
            crosshair.SetActive(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("cross") || Vector3.Distance(player.transform.position, transform.position) <= 3)
        {
            crosshair.SetActive(false);
        }
    }
}
