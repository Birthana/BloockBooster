using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 mPos;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            mPos = Input.mousePosition;
    }

    public void Fire(Vector3 pos)
    {
        Debug.Log(rb.velocity);
        mPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
        pos = new Vector2(transform.position.x, transform.position.y + 1);
        
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x);
        
        transform.localPosition = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)));

        var rotation1 = Quaternion.Euler(dir.x, dir.y, dir.z);
        rb.velocity = transform.localPosition * speed;
        Debug.Log(transform.localPosition);
        this.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
