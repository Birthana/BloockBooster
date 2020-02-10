using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform position;
    public float speed;
    [SerializeField] private Vector3 player;

    private GameObject currentPlayer;
    private float maxDistance;

    Rigidbody2D rb;

    private void Start()
    {
        position = this.transform;
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        player = currentPlayer.transform.position;
        maxDistance = Vector3.Distance(position.position, player);

        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        player = currentPlayer.transform.position;
        position = this.transform;
        Vector3 zAxis = new Vector3(0, 0, 1); 
        player = currentPlayer.transform.position;
        if (Vector3.Distance(position.position, player) > maxDistance+0.1f)
        {
            this.transform.position = Vector3.MoveTowards(position.position, player, 5* Time.deltaTime);
            Vector3 dir = (position.position - player).normalized;
            this.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x)) + 90f);
        }else if (Vector3.Distance(position.position, player) < maxDistance-0.1f)
        {
            Vector3 dir = (position.position - player).normalized;
            this.transform.position = Vector3.MoveTowards(position.position, player, -5* Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x))+90f);
        }
        else
        {
            Vector3 dir = (position.position - player).normalized;
            this.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x)) + 90f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            position.RotateAround(player, zAxis, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            position.RotateAround(player, zAxis, -speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            position.RotateAround(player, zAxis, 180);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<BulletMovement>())
        {
            Debug.Log(collision.gameObject);
            if ((this.GetComponentInParent<PlayerMovement>().StageNum == 2))
            {
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            
        }
    }
}
