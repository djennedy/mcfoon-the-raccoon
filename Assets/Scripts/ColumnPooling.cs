using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPooling : MonoBehaviour
{
    public GameObject columnPrefab;
    public GameObject constructionPrefab;
    public int columnPoolSize = 5;                                    
    public float spawnRate = 10f;                                   
    public float columnMin = -2f;                                    //Minimum y value of the column position.
    public float columnMax = 2f;                                    //Maximum y value of the column position.

    private GameObject[] columns;                                    //Collection of pooled columns.
    private GameObject[] buildings;
    private int currentColumn = 0;                                    //Index of the current column in the collection.

    private Vector2 poolPosition = new Vector2 (-2,-40);        //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    private float buildingXPositionOffset = 10f;
    private float buildingYPosition = -1.25f;

    private float timeSinceSpawned = 0;

    void Start()
    {
        columns = new GameObject[columnPoolSize];
        buildings = new GameObject[columnPoolSize];

        for(int i = 0; i < columnPoolSize;i++){
            columns[i] = (GameObject) Instantiate(columnPrefab, poolPosition, Quaternion.identity);
            buildings[i] = (GameObject) Instantiate(constructionPrefab, poolPosition, Quaternion.identity);
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
            buildings[currentColumn].transform.position = new Vector2(spawnXPosition + buildingXPositionOffset, buildingYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn ++;

            if (currentColumn >= columnPoolSize) 
            {
                currentColumn = 0;
            }
        }
    }
}
