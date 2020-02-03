using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldownTime;
    public bool isOnCooldown;

    private void Start()
    {
        SoundManager.instance.PlayBackground(2);
        UIManager.instance.SetTimer(60.0f, 0);
        UIManager.instance.SetMaxHealth(7);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        isOnCooldown = true;
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        int rngAxis = Random.Range(0, 4);
        if (rngAxis == 0)
        {
            GameObject temp = Instantiate(bulletPrefab, new Vector3(Random.Range(-cameraSize.x, cameraSize.x), -cameraSize.y, 0), Quaternion.identity);
        }
        else if(rngAxis == 1)
        {
            GameObject temp = Instantiate(bulletPrefab, new Vector3(-cameraSize.x, Random.Range(-cameraSize.y, cameraSize.y), 0), Quaternion.identity);
        }else if (rngAxis == 2)
        {
            GameObject temp = Instantiate(bulletPrefab, new Vector3(Random.Range(-cameraSize.x, cameraSize.x), cameraSize.y, 0), Quaternion.identity);
        }
        else if(rngAxis == 3)
        {
            GameObject temp = Instantiate(bulletPrefab, new Vector3(cameraSize.x, Random.Range(-cameraSize.y, cameraSize.y), 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
