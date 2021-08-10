using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_slow : MonoBehaviour
{
    public Transform obs;

    public float speed = 1;
    public Vector3 endPosition;

    public bool gameEnd = false;
    public bool gameStart = false;

    void Start()
    {
        endPosition = new Vector3(45.0f, 0, -5.0f);
        System.Random rnd = new System.Random();
        speed = rnd.Next(10, 25) / 25.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameEnd)
        {
            obs.position = Vector3.Lerp(obs.position, endPosition, Time.deltaTime * speed);
        }
        else
        {
            obs.position = Vector3.Lerp(obs.position, endPosition, Time.deltaTime * 0);
        }
    }
}
