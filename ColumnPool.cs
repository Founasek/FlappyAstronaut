using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColumnPool : MonoBehaviour {

    [Header("Column Pooling")]
    public GameObject columnPrefab;
    public int NumberOfColumn = 5;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    public float heightMin = 10f;
    public float heightMax = 20f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(10f, -1f);
    private float timeSinceLastSpawned;
    private int currentColumn = 0;
  
    // Use this for initialization
	void Start ()
    {
        columns = new GameObject[NumberOfColumn];
        for (int i = 0; i < NumberOfColumn; i++)
        {
            columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
	    float spawnXPostition = Random.Range(heightMin, heightMax);
            float spawnYposition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPostition, spawnYposition);
            currentColumn++;

            if (currentColumn >= NumberOfColumn)
            {
                currentColumn = 0;
            }
        }
	}
}
