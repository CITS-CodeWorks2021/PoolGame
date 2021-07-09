using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static UnityEvent<GameObject> onPocket = new UnityEvent<GameObject>();
    public Text player1score, player2score;
    int p1score, p2score;
void Start()
    {
        onPocket.AddListener(HandleOnPocket);

    }
void HandleOnPocket(GameObject ball)
    {
        PoolBall daball = ball.GetComponent<PoolBall>();
        if (daball)
        {
            if (daball.ballNum == 8)
            {
                //handle 8 ball
                return;
            }
            if (daball.isSolid)
            {
                //handle solid
                return;
            }
            //handle striped
        }
    }
    void UpdateScores()
    {
        player1score.text = p1score.ToString();
        player2score.text = p2score.ToString();
    }
}
