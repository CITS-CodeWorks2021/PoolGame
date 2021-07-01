using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestImpulse : MonoBehaviour
{
    public Vector2 pushAmount;
    public void pushMe()
    {
        GetComponent<Rigidbody2D>().AddForce(pushAmount, ForceMode2D.Impulse);
    }
}
