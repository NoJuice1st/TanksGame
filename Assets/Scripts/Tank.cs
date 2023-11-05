using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    public string verticalAxis;
    public string horizontalAxis;
    public KeyCode shootKey;

    public GameObject bullet;
    public Transform shootPoint;

    private void Update()
    {
        var vert = Input.GetAxis(verticalAxis);
        transform.position += transform.forward * vert * speed * Time.deltaTime;

        var horizon = Input.GetAxis(horizontalAxis);
        transform.Rotate(0, horizon * rotateSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }
    }
}