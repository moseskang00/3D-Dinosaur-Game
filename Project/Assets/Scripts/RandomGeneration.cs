using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
	//Script to randomly spawn obstacles on path
	//Script is placed on GroundPlane object in scene
	
    protected GameObject obstacle; //Pointer to current obstacle
	protected GameObject[] obstacles = new GameObject[3]; //Array of currently loaded obstacles
    public GameObject[] spawnPoints = new GameObject[3]; //Spawn Points, filed with empty 3d objects in scene
    protected Vector3 spawnPos; //Vec3 position
    protected int count = 0; //counter
	private float time = 0.0f;
	public float spawnInterval = 3.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        Requests(); //call random method
    }

    // Update is called once per frame
    void Update()
    { //will want to call Requests() every few seconds
		if (time >= spawnInterval)
		{
            Debug.Log("spawn");
			time = 0;
			
			//Note:
			//Right now only spawns three obstacles at once. If you want more obstacles viewable, then increase obstacles array size and edit this section
			Clear(); //remove existing obstacles
			Requests(); //spawn new obstacles
		}
		time += Time.deltaTime;
		//Debug.Log(time);
    }
	
	//Requests spawns in obstacles
    void Requests()
    {
        System.Random rnd = new System.Random(); //Random function
        for (int i = 0; i <= 2; i++) //do three times
        {
			spawnPos = spawnPoints[i].transform.position; //set spawn location
            var rotationVector = transform.rotation.eulerAngles; //rotation
            rotationVector.y = 90; //rotation
            int rndName = rnd.Next(0, 4); //Get rand number
            if (rndName == 0)
            {
                Debug.Log("spawn log");
				//fetch 1st obstacle from asset path
				obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/logObstaclePrefab.prefab", typeof(GameObject)) as GameObject;
				
				//instantiate obstacle into scene
				obstacles[i] = Instantiate(obstacle);

				//move newly spawned obstacle to correct location
				obstacles[i].transform.position = spawnPos;
                obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                obstacles[i].transform.localScale = 2*obstacles[i].transform.localScale;
            }
            else if (rndName == 1)
            {
                Debug.Log("spawn spike");
				//fetch obstacle from asset path
				obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/spikeObstacle.fbx", typeof(GameObject)) as GameObject;
				
				//instantiate obstacle into scene
				obstacles[i] = Instantiate(obstacle);

				//move newly spawned obstacle to correct location
				obstacles[i].transform.position = spawnPos;
                obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                obstacles[i].transform.localScale = 200*obstacles[i].transform.localScale;
            }
            else if (rndName == 2)
            {
                Debug.Log("spawn wall");
				//fetch obstacle from asset path
				obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/wallObstacle.fbx", typeof(GameObject)) as GameObject;
				
				//instantiate obstacle into scene
				obstacles[i] = Instantiate(obstacle);
				//move newly spawned obstacle to correct location
				obstacles[i].transform.position = spawnPos;
                obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                obstacles[i].transform.localScale = 200*obstacles[i].transform.localScale;
            }
            else if (rndName == 3)
            {
                Debug.Log("spawn nothing");
			}
        }
    }
	
    void Clear()
    { //unload existing obstacles
        count = 0;
        spawnPos = spawnPoints[0].transform.position;
        
        for (int i = 0; i <= 2; i++)
        {
            //Debug.Log("clear" + i);
            Destroy(obstacles[i]);
        }
    }
}
