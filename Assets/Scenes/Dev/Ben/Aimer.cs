using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{

    public GameObject aimObject;
    //Ask where playerCam comes into play
    public Camera playerCam;
    public float pushMulti;
    bool isPlaying = false, isTracking = false, isShooting = false;
    public Transform CueBall;

    // Start is called before the first frame update
    void Start()
    {
        //Temp
        isPlaying = true;
    }
    public void StartGame()
    {
        isPlaying = true;
        isTracking = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("Started");
        

            if (isPlaying && !isTracking && !isShooting)
            {
                CheckInput();
            }

            if (isTracking)
            {
                TrackInput();
            }

        if (isShooting)
        {
            TrackShot();
        }
        }
    
    void TrackShot()
    {
        Debug.Log("Is Tracking");
        float currentVelocity = CueBall.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (currentVelocity < .05f)
        {
            CueBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            CueBall.GetComponent<Rigidbody2D>().angularVelocity = 0;
            transform.position = CueBall.position;
            isShooting = false;
        }
    }

    void CheckInput()
    {
        //Debug.Log("Checking Input");
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                Debug.Log("Hit Something");
                Vector3 point = hit.point;
                CueBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                CueBall.GetComponent<Rigidbody2D>().angularVelocity = 0;
                CueBall.transform.position = point;

                isTracking = true;
            }
        }
    }

    void TrackInput()
    {
        Debug.Log("Tracking Input");
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                Debug.Log("Hitting Something(Tracking Input)");
                Vector3 point = hit.point;
                CueBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                CueBall.GetComponent<Rigidbody2D>().angularVelocity = 0;

                aimObject.transform.position = hit.point;
            }
        }
        else
        {
            KickBall();
            isTracking = false;
        }
    }

    void KickBall()
    {
        Vector3 pushDir = CueBall.transform.position - aimObject.transform.position;
        pushDir *= pushMulti;
        CueBall.GetComponent<Rigidbody2D>().AddForce(pushDir, ForceMode2D.Impulse);
        isShooting = true;

    }
}