using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D other)
    {
        ScoreUpdate.onPocket.Invoke(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
