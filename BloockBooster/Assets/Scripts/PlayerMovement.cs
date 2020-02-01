using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    public Animator animator;


    private int StageNum;

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
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed;
        if(Input.GetButtonDown("SPACE"))
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), jumpHeight) * speed;
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

}
