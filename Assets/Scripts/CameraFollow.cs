using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.Lerp(player1.position, player2.position, 0.5f);
        //var dist = Vector3.Distance(player1.position, player2.position);
        transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
    }
}
