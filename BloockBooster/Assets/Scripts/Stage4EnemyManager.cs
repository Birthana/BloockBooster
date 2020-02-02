using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4EnemyManager : MonoBehaviour
{
    float spawnDelay;
    float time = 0f;
    
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnDelay)
        {
            time = 0;
            spawnDelay = Random.Range(5.0f, 10.0f);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject b = this.GetComponent<ObjectPool>().FindUnusedObject();
        b.SetActive(true);
        b.transform.localPosition = Vector3.Normalize((player.transform.position - this.GetComponent<ObjectPool>().transform.position));
    }
}
