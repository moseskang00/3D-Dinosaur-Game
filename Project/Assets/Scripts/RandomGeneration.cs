using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomGeneration : MonoBehaviour
{
    //Script to randomly spawn obstacles on path
    //Script is placed on GroundPlane object in scene

    public float pointIncrementPerSecond; //number by which points increased
    public float score;
    protected GameObject obstacle; //Pointer to current obstacle
	protected GameObject[] obstacles = new GameObject[3]; //Array of currently loaded obstacles
    public GameObject[] spawnPoints = new GameObject[3]; //Spawn Points, filed with empty 3d objects in scene
    protected Vector3 spawnPos; //Vec3 position
    public Vector3 spawnPos0 = new Vector3(0.0f, 0.0f, 21.31655f);
    public Vector3 spawnPos1 = new Vector3(-10.0f, 0.0f, 21.31655f);
    public Vector3 spawnPos2 = new Vector3(-20.0f, 0.0f, 21.31655f);
    protected int count = 0; //counter
	private float time = 0.0f;
	public float spawnInterval = 3.0f;

    public jumpAnimation ja;

    public bool flag = false;

    public int countdownTimer;
    public Text countdownDisplay;
    public Vector3 retPosition;
	
    // Start is called before the first frame update
    void Start()
    {
        ja = GameObject.FindObjectOfType<jumpAnimation>();
        pointIncrementPerSecond = 5;
       
    }

    // Update is called once per frame
   void Update()
    { //will want to call Requests() every few seconds
        
		if (Input.GetKeyDown("s"))
        {
            StartCoroutine(CountdownStart());
        }

        updateScore();//update score as player survives obstacles

        if (flag == true)
        {
            flag = ja.end();
            if (flag == false)
            {
                StartCoroutine(CountdownEnd());
            }
        }

        if (time >= spawnInterval && flag == true)
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


        //restart scene when r is pressed
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
	
	//Requests spawns in obstacles
    void Requests()
    {
        System.Random rnd = new System.Random(); //Random function
        for (int i = 0; i <= 2; i++) //do three times
        {
            spawnPos = spawnPoints[i].transform.position; //set spawn location
            // retPosition = new Vector3(20, 0, spawnPos[1]); 
            var rotationVector = transform.rotation.eulerAngles; //rotation
            rotationVector.y = 90; //rotation
            int rndName = rnd.Next(0, 3); //Get rand number
            if (i == 0)
            {
                if (rndName == 0)
                {
                    Debug.Log("spawn log");
                    //fetch 1st obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/log/log_left.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 1 * obstacles[i].transform.localScale;
                }
                else if (rndName == 1)
                {
                    Debug.Log("spawn spike");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/spike/spikeObject_Left.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 0.75f * obstacles[i].transform.localScale;
                    retPosition = new Vector3(30, 0, spawnPos[2]);
                    Debug.Log(spawnPos);

                }
                else if (rndName == 2)
                {
                    Debug.Log("spawn wall");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/wall/wallObstacle_Left.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);
                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 60 * obstacles[i].transform.localScale;
                }
            }
            else if (i == 1)
            {
                if (rndName == 0)
                {
                    Debug.Log("spawn log");
                    //fetch 1st obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/log/log_right.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 1 * obstacles[i].transform.localScale;
                }
                else if (rndName == 1)
                {
                    Debug.Log("spawn spike");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/spike/spikeObject_Right.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 0.75f * obstacles[i].transform.localScale;
                    retPosition = new Vector3(30, 0, spawnPos[2]);
                    Debug.Log(spawnPos);

                }
                else if (rndName == 2)
                {
                    Debug.Log("spawn wall");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/wall/wallObstacle_Right.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);
                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 60 * obstacles[i].transform.localScale;
                }

            }
            if (i == 2)
            {
                if (rndName == 0)
                {
                    Debug.Log("spawn log");
                    //fetch 1st obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/log/log_middle.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 1 * obstacles[i].transform.localScale;
                }
                else if (rndName == 1)
                {
                    Debug.Log("spawn spike");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/spike/spikeObject.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);

                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 0.75f * obstacles[i].transform.localScale;
                    retPosition = new Vector3(30, 0, spawnPos[2]);
                    Debug.Log(spawnPos);

                }
                else if (rndName == 2)
                {
                    Debug.Log("spawn wall");
                    //fetch obstacle from asset path
                    obstacle = AssetDatabase.LoadAssetAtPath("Assets/Models/FBXfiles/wall/wallObstacle.prefab", typeof(GameObject)) as GameObject;

                    //instantiate obstacle into scene
                    obstacles[i] = Instantiate(obstacle);
                    //move newly spawned obstacle to correct location
                    obstacles[i].transform.position = spawnPos;
                    obstacles[i].transform.rotation = Quaternion.Euler(rotationVector); //rotate
                    obstacles[i].transform.localScale = 60 * obstacles[i].transform.localScale;
                }
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

    IEnumerator CountdownStart()
    {
        while(countdownTimer > 0)
        {
            countdownDisplay.text = countdownTimer.ToString();

            yield return new WaitForSeconds(1f);

            countdownTimer--;
            Debug.Log(countdownTimer);
            if (countdownTimer == 0)
            {
                countdownDisplay.text = "GO!";
                yield return new WaitForSeconds(1f);
                flag = true;
                //countdownDisplay.gameObject.SetActive(false);
            }
        }



    }

   
   //display players score and game over message 
    IEnumerator CountdownEnd()
    {
        countdownDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        countdownDisplay.text = "Your score:" + (int)score;
        yield return new WaitForSeconds(2);
        countdownDisplay.text = "Game Over! Press R to restart.";
    }

    //update function to update score as long as flag is true
    public void updateScore()
    {
        if (flag == true)
        {
            countdownDisplay.text = (int)score + ".";
            score += pointIncrementPerSecond * Time.deltaTime;
        }
    }

    public bool getFlag()
    {
        return flag;
    }
    public Vector3 getPos()
    {
        return retPosition;
    }
}
