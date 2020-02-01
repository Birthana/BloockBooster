using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    public Animator animator;

    private bool isJumping;
    private int StageNum = 1;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StageNum == 1)
            Stage1Control();
        else if (StageNum == 2)
            Stage2Control();
        else if (StageNum == 3)
            Stage3Control();
    }

    void Stage1Control()
    {
        float h = Input.GetAxis("Horizontal");
        animator.SetFloat("horizontal", h);
        Vector2 tempVect = new Vector2(h, 0);
        animator.SetFloat("speed", tempVect.sqrMagnitude);
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void Stage2Control()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);

        Vector2 tempVect = new Vector2(h, v);
        animator.SetFloat("speed", tempVect.sqrMagnitude);

        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + tempVect * speed);
    }

    void Stage3Control()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collision.collider.bounds.center;

        if(contactPoint.y > center.y)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
}
