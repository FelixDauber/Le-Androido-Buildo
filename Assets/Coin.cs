using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ScoreHolder.scoreHolder.AddPoint();
            Destroy(gameObject);
        }
    }
}
