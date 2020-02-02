using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public float cooldown;
    public bool isOnCooldown;

    private Animator animator;

    private void Start()
    {
        SoundManager.instance.PlayBackground(1);
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(RollingBarrel());
        }
    }

    IEnumerator RollingBarrel()
    {
        isOnCooldown = true;
        animator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("IsOpen", false);
        GameObject barrel = Instantiate(barrelPrefab, this.transform.position + new Vector3(1.5f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        cooldown = Random.Range(1, 4);
        isOnCooldown = false;
    }
}
