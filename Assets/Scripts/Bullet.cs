using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    public GameObject explosionMark;
    public float speed;
    public int particleCount;
    public GameObject explosiveObject;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Destructable"))
        {
            Instantiate(explosiveObject, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            for (int i = 0; i < particleCount; i++)
            { 
                Vector3 offset = Random.insideUnitSphere;
                var part = Instantiate(particle, transform.position + offset, transform.rotation);
                part.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
                part.transform.localScale = Random.insideUnitSphere * 2 + new Vector3(0.1f, 0.1f, 0.1f);
            }
            Instantiate(explosionMark, other.gameObject.transform.position + new Vector3(0,0.001f,0), Quaternion.identity);
        }

        Destroy(gameObject);
        
    }
}
