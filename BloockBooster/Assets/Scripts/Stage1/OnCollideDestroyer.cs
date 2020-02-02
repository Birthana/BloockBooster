using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Barrel>() || collision.gameObject.GetComponent<FallingTape>())
        {
            Destroy(collision.gameObject);
        }
    }
}
