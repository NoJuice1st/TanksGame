using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;

    private void Update()
    {
        var scaleX = health.hp / 5f;
        transform.localScale = new Vector3(scaleX, 1, 1); //Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(scaleX, 1, 1), 0.1f);
    }
}
