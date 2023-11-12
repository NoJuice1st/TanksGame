using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject shoot;

    private void Start()
    {
        Destroy(gameObject, 2f);
        Destroy(Instantiate(shoot, transform.position, transform.rotation), 3f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Destructable"))
        {

            other.gameObject.GetComponent<Health>().Damage();
        }
        

        Destroy(gameObject);
        
    }
}
