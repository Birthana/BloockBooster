using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public float cooldown;
    private bool isOnCooldown;

    private void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(SpawningGround());
        }
    }

    IEnumerator SpawningGround()
    {
        isOnCooldown = true;
        GameObject tempGround = Instantiate(groundPrefab, this.transform.position, Quaternion.identity);
        Destroy(tempGround, 5f);
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
