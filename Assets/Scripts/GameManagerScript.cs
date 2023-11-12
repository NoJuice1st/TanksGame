using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Health player1;
    public Health player2;

    private void Update()
    {
        if (player1.hp == 0 || player2.hp == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
