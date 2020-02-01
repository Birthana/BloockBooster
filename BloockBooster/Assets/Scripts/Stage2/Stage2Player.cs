using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Player : MonoBehaviour
{
    public Stage2GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<Stage2GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Stage2Bullet>())
        {
            Destroy(collision.gameObject);
            gameManager.TakeDamage();
        }
    }
}
