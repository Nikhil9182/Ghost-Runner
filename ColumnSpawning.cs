using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawning : MonoBehaviour
{
    public static ColumnSpawning instance;

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public GameObject columnPrefab2;
    public GameObject columnPrefab3;
    public GameObject columnPrefab4;

    public bool nextSpawn = false;
    public bool nextSpawn2 = false;
    public bool nextSpawn3 = false;

    public float afterTime = 30f;
    public float afterTime2 = 60f;
    public float afterTime3 = 60f;
    public float spawnRate = 4f;
    public float spawnRate2 = 6f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private GameObject[] columns2;
    private GameObject[] columns3;
    private GameObject[] columns4;

    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn;
    private float spawnXPosition = 10f;
    private int currentColumn = 0, currentColumn2 = 0, currentColumn3 = 0, currentColumn4 = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        /*else if( instance != null)
        {
            Destroy(gameObject);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        columns2 = new GameObject[columnPoolSize];
        columns3 = new GameObject[columnPoolSize];
        columns4 = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns2[i] = (GameObject)Instantiate(columnPrefab2, objectPoolPosition, Quaternion.identity);
        }
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns3[i] = (GameObject)Instantiate(columnPrefab3, objectPoolPosition, Quaternion.identity);
        }
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns4[i] = (GameObject)Instantiate(columnPrefab4, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (!nextSpawn)
        {
            afterTime -= Time.deltaTime;
            if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
            {
                timeSinceLastSpawn = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
        else if (afterTime <= 0)
        {
            for (int i = 0; i < columnPoolSize; i++)
            {
                //columns[i].transform.position = objectPoolPosition;
                Destroy(columns[i]);
            }
        }
        if (afterTime <= 0 && !nextSpawn2)
        {
            afterTime2 -= Time.deltaTime;
            nextSpawn = true;
            if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate2)
            {
                timeSinceLastSpawn = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns2[currentColumn2].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn2++;
                if (currentColumn2 >= columnPoolSize)
                {
                    currentColumn2 = 0;
                }
            }
        }
        else if (afterTime2 <= 0)
        {
            for (int i = 0; i < columnPoolSize; i++)
            {
                //columns2[i].transform.position = objectPoolPosition;
                Destroy(columns2[i]);
            }
        }

        if (afterTime2 <= 0 && !nextSpawn3)
        {
            nextSpawn2 = true;
            afterTime3 -= Time.deltaTime;
            if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate2)
            {
                timeSinceLastSpawn = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns3[currentColumn3].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn3++;
                if (currentColumn3 >= columnPoolSize)
                {
                    currentColumn3 = 0;
                }
            }
        }
        else if (afterTime3 <= 0)
        {
            for (int i = 0; i < columnPoolSize; i++)
            {
                //columns3[i].transform.position = objectPoolPosition;
                Destroy(columns3[i]);
            }
        }

        if (afterTime3 <= 0)
        {
            nextSpawn3 = true;
            if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate2)
            {
                timeSinceLastSpawn = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns4[currentColumn4].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn4++;
                if (currentColumn4 >= columnPoolSize)
                {
                    currentColumn4 = 0;
                }
            }
        }
    }
}
