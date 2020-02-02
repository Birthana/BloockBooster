using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTape : MonoBehaviour
{
    public Collider2D boxCollider;
    private bool isOnCooldown;

    private void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<Platform>() || collision.gameObject.GetComponent<Barrel>()) && !isOnCooldown)
        {
            StartCoroutine(Flicker());
        }
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Destroy(this.gameObject);
            Debug.Log("Player Hit.");
        }
    }

    IEnumerator Flicker()
    {
        boxCollider.enabled = false;
        isOnCooldown = true;
        yield return new WaitForSeconds(0.425f);
        boxCollider.enabled = true;
        isOnCooldown = false;
    }
}
