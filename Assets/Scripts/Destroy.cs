using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject ruble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < 5; i++)
        {
              Instantiate(ruble, collision.transform.position, collision.transform.rotation);
        }
        Destroy(gameObject);
    }
}
