using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloockBoosterLights : MonoBehaviour
{
    public Animator animator;
    public float cooldown;
    private bool isOnCooldown;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        isOnCooldown = true;
        int rng = Random.Range(0, 4);
        if (rng == 0)
        {
            animator.SetInteger("lightVariation", 1);
        }
        else if (rng == 1)
        {
            animator.SetInteger("lightVariation", 2);
        }
        else if (rng == 2)
        {
            animator.SetInteger("lightVariation", 3);
        }
        else
        {
            animator.SetInteger("lightVariation", 0);
        }
        yield return new WaitForSeconds(cooldown);
        cooldown = Random.Range(1.0f, 4.0f);
        isOnCooldown = false;
    }
}
