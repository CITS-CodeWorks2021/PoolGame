using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMovementTester : MonoBehaviour
{
    public void stopMe()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
    }
