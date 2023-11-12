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

    private AudioSource movementSound;
    public GameObject bullet;
    public Transform shootPoint;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSound = GetComponent<AudioSource>();
       
    }
    private void Update()
    {
        var vert = Input.GetAxis(verticalAxis);
        //transform.position += transform.forward * vert * speed * Time.deltaTime;

        var horizon = Input.GetAxis(horizontalAxis);
        transform.Rotate(0, horizon * rotateSpeed * Time.deltaTime, 0);

        rb.velocity = transform.forward * vert * speed;

        if (rb.velocity == Vector3.zero)
        {
            movementSound.Pause();
        }
        else
        {
            movementSound.UnPause();
        }



        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            //movementSound.Play();
        }
    }
}
