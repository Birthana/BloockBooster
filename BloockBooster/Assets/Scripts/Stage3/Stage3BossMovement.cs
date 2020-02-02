using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3BossMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Camera cam;

    [SerializeField] float speed;

    float time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if( time <= 0 )
        {
            RandomMove(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0));
            time = 10f;
        }
    }

    void RandomMove(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x);
        rb.velocity = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))) * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border") && other.name == "Right")
        {
            RandomMove(new Vector3(Random.Range(-0.9f, -0.1f), Random.Range(-0.9f, 0.9f)));
            time = 31f;
            if (rb.velocity.x >= 0) ;
        }

        if (other.CompareTag("Border") && other.name == "Left")
        {
            RandomMove(new Vector3(Random.Range(0.1f, 0.9f), Random.Range(-0.9f, 0.9f)));
            time = 31f;
        }

        if (other.CompareTag("Border") && other.name == "Top")
        {
            RandomMove(new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-0.9f, -0.1f)));
            time = 31f;
        }

        if (other.CompareTag("Border") && other.name == "Bottom")
        {
            RandomMove(new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(0.1f, 0.9f)));
            time = 31f;
        }
    }
}
