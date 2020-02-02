using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject gapPrefab;

    private float X_OFFSET = 10f;

    List<GameObject> platforms;

    private void Start()
    {
        platforms = new List<GameObject>();
    }

    private void Update()
    {
        if (platforms.Count == 0)
        {
            StartCoroutine(SpawningGround());
        }
    }



    IEnumerator SpawningGround()
    {
        float rand = Random.Range(2f, 7f);
        GameObject tempGround = Instantiate(groundPrefab, this.transform.position, Quaternion.identity);
        platforms.Add(tempGround);
        Destroy(tempGround, 5f);
        for (int i = 0; i < 3; i++)
        {
            GameObject tempGround2 = Instantiate(groundPrefab, this.transform.position+ new Vector3(X_OFFSET, 0,0), Quaternion.identity);
            platforms.Add(tempGround2);
            Destroy(tempGround2, 5f);
            
        }
        GameObject tempGround3 = Instantiate(gapPrefab, this.transform.position + new Vector3(X_OFFSET+10.25f, 0.3f, 0), Quaternion.identity);
        Destroy(tempGround3, 7f);
        yield return new WaitForSeconds(Random.Range(4,4));
        
        platforms.Clear();
        
    }
}
