using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferScript : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    private PlayerInteracting scrpt;
    public GameObject svetlo1;
    public GameObject svetlo2;
    public bool locker = false;
    public GameObject secondDoor;
    public GameObject obj;
    public GameObject dungTask;
    public GameObject dungeonTimer;
    private pauseScript pscript;
    // Start is called before the first frame update
    void Start()
    {
        scrpt = FindObjectOfType<PlayerInteracting>();
        cam = Camera.main.GetComponent<CameraMovement>();
        pscript = FindObjectOfType<pauseScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !locker) {
            StartCoroutine(lockCo());
            StartCoroutine(lockMove());
            if (scrpt.isInDungeon)
            {
                scrpt.isInDungeon = false;
            }
            else if (placeName == "Dungeon")
            {
                dungeonTimer.SetActive(true);
                scrpt.isInDungeon = true;
                svetlo1.SetActive(true);
                svetlo2.SetActive(true);
                if (dungTask != null)
                {
                    dungTask.SetActive(true);

                }

            }
            if (obj != null) { obj.SetActive(false); }
            //if (placeName == "OverWorld")
            //{
            if (svetlo1 != null && !scrpt.isInDungeon) {
                svetlo1.SetActive(false);
            }
            if (svetlo2 != null && !scrpt.isInDungeon)
            {
                svetlo2.SetActive(false);
            }
            // }
            /*cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;*/

            other.transform.position += playerChange;
            if (needText) {
                StartCoroutine(placeNameCo());
            }
            Debug.Log("Trigger");
        }
    }
    private IEnumerator placeNameCo() {

        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
    private IEnumerator lockCo()
    {
        secondDoor.GetComponent<TransferScript>().locker = true;

        yield return new WaitForSeconds(1f);
        secondDoor.GetComponent<TransferScript>().locker = false;
    }
    private IEnumerator lockMove()
    {
        pscript.isPaused = true;
        yield return new WaitForSeconds(0.5f);
        pscript.isPaused = false;
    }
}
