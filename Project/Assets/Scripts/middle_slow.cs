using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middle_slow : MonoBehaviour
{
    public Transform obs;
    private RandomGeneration rg;

    public float speed = 1;
    public Vector3 endPosition;

    public bool gameEnd = false;
    public bool gameStart = false;
    public bool gate = true;

    void Start()
    {
        rg = GameObject.FindObjectOfType<RandomGeneration>();
        endPosition = new Vector3(45.0f, 0, 0);
        gate = false;
        System.Random rnd = new System.Random();
        speed = rnd.Next(30, 40) / 35.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameStart = rg.getFlag();
        if (gate)
        {
            //endPosition = rg.getPos();
            gate = false;
        }

        if (!gameEnd && gameStart)
        {
            obs.position = Vector3.Lerp(obs.position, endPosition, Time.deltaTime * speed);
        }
        else
        {
            obs.position = Vector3.Lerp(obs.position, endPosition, Time.deltaTime * 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dinosaur")
        {
            gameEnd = true;
        }
    }
}
