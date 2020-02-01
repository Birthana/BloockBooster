using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 mPos;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            mPos = Input.mousePosition;
    }

    void Move(Vector3 pos)
    {
        rb.velocity = Vector3.Normalize(this.transform.localPosition - pos) * speed;
    }
}
