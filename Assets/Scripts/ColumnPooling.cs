using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPooling : MonoBehaviour
{
    public GameObject columnPrefab;                                    
    public int columnPoolSize = 5;                                    
    public float spawnRate = 3f;                                   
    public float columnMin = -1f;                                    //Minimum y value of the column position.
    public float columnMax = 3.5f;                                    //Maximum y value of the column position.

    private GameObject[] columns;                                    //Collection of pooled columns.
    private int currentColumn = 0;                                    //Index of the current column in the collection.

    private Vector2 poolPosition = new Vector2 (-15,-25);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceSpawned;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize;i++){
            columns[i] = (GameObject) Instantiate(columnPrefab, poolPosition, Quaternion.identity); 
        }
    }

    // Update is called once per frame
     //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceSpawned >= spawnRate) 
        {    
            timeSinceSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn ++;

            if (currentColumn >= columnPoolSize) 
            {
                currentColumn = 0;
            }
        }
    }
}
