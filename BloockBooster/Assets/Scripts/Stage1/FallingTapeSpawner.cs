using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTapeSpawner : MonoBehaviour
{
    public GameObject fallingTape;
    public float cooldown;
    public bool isOnCooldown;
    public int numberOfTapesToSpawn;

    private void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(Spawning());
        }
    }

    IEnumerator Spawning()
    {
        isOnCooldown = true;
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        for (int i = 0; i < numberOfTapesToSpawn; i++)
        {
            GameObject tape = Instantiate(fallingTape, new Vector3(Random.Range(-cameraSize.x, cameraSize.x), cameraSize.y, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
