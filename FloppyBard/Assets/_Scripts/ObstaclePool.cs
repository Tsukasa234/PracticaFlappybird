using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float time = 2.5f;
    [SerializeField] private float xpawnPosition = 12f;
    [SerializeField] private float minY = -2, maxY = 3;

    private float timeLapsed;
    private int objectcount;
    private List<GameObject> objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(pipes);
            tmp.SetActive(false);
            objectPool.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;
        if (timeLapsed > time && !GameManager.Instance.isGameOver)
        {
            GetPooledObject();
        }
    }

    public void GetPooledObject()
    {
        timeLapsed = 0;
        float ySpawnPosition = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(xpawnPosition, ySpawnPosition);
        objectPool[objectcount].transform.position = spawnPosition;

        if (!objectPool[objectcount].activeSelf)
        {
            objectPool[objectcount].SetActive(true);
        }
        objectcount++;

        if (objectcount == poolSize)
        {
            objectcount = 0;
        }
    }
}
