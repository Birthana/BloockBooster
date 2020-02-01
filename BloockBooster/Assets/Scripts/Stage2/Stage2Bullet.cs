using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Bullet : MonoBehaviour
{
    public float speed;
    public Vector3 playerPosition;

    void Start()
    {
        playerPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Vector2.Distance(this.transform.position, playerPosition) > 0)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Random.Range(0.5f, 2.0f) * Time.deltaTime);
        }
    }
}
