using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public Transform startPos;
    public Transform endPos;
    private float minY = -4.5f;
    private float maxY = 0.5f;

    public int poolSize = 3;
    public float timeCooldown = 2f;
    public float moveSpeed = 2f;

    public Queue<GameObject> pool = new Queue<GameObject>();
    private float timerCooldown;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pipePrefab, startPos.position, Quaternion.identity);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        timerCooldown = timeCooldown;
    }

    private void Update()
    {
        foreach (GameObject obj in pool)
        {
            if (obj.activeSelf)
            {
                if (obj.transform.position.x < endPos.position.x)
                {
                    obj.SetActive(false);
                }
            }
        }

        timerCooldown -= Time.deltaTime;

        if (timerCooldown < 0f)
        {
            SpawnFromPool();
            timerCooldown = timeCooldown;
        }
    }

    private void SpawnFromPool()
    {
        GameObject obj = pool.Dequeue();

        if (!obj.activeSelf)
        {
            float y = Random.Range(minY, maxY);
            startPos.position = new Vector3(6f, y, 0f);
            obj.transform.position = startPos.position;
            obj.SetActive(true);
        }

        pool.Enqueue(obj);
    }
}
