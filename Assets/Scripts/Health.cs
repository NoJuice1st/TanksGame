using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject particle;
    public GameObject explosiveObject;
    public GameObject explosionMark;
    public int hp;
    public int particleCount;
    public bool autoDestroy = true;
    public float maxParticleSize = 1f;

    public void Damage()
    {
        hp--;

        if(hp <= 0) Die();
        
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 offset = Random.insideUnitSphere;
            var part = Instantiate(particle, transform.position + offset, transform.rotation);
            if(gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
            {
                part.GetComponent<MeshRenderer>().material.color = mesh.material.color;
            }
            part.transform.localScale = new Vector3(Random.Range(0.1f, maxParticleSize), Random.Range(0.1f, maxParticleSize), Random.Range(0.1f, maxParticleSize));
            //FadeAway(part);
            Destroy(part, 10f);
        }
    }

    public void Die()
    {


        if(autoDestroy)Destroy(gameObject);

        Instantiate(explosiveObject, transform.position, transform.rotation).GetComponent<AudioSource>().Play();

        if(gameObject.name.Contains("Tank"))
            Instantiate(explosionMark, gameObject.transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        else
            Instantiate(explosionMark, gameObject.transform.position + new Vector3(0, 0.001f, 0), Quaternion.identity);
    }

    /*public void FadeAway(GameObject other)
    {
        var materialColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
        float alpha = 1;
        while(alpha !<= 0)
        {
            alpha -= 0.1f;
            materialColor.a = alpha;
        }
    }*/
}
