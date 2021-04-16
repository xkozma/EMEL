using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLightScript : MonoBehaviour
{
    public float speed = 5f;
    public float offset = 0f;
    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
