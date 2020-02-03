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

    public void MouseFire(Vector3 pos)
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.localPosition = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)));
        rb.velocity = transform.localPosition * speed;
    }
    
    public void BossFire(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x);
        transform.localPosition = Vector3.Normalize(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)));
        rb.velocity = transform.localPosition * 10;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            this.gameObject.SetActive(false);
        }

        if (!(this.transform.parent.parent.gameObject.CompareTag("Player")) && other.CompareTag("Player"))
        {
            UIManager.instance.TakeDamage();
            this.gameObject.SetActive(false);
        }

        if (!(this.transform.parent.parent.gameObject.CompareTag("Boss")) && other.CompareTag("Boss"))
        {
            UIManager.instance.BossTakeDamage();
            this.gameObject.SetActive(false);
        }
        if (!(this.transform.parent.parent.gameObject.CompareTag("Enemy")) && other.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
