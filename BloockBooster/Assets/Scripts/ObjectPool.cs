using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;//bullet script
    [SerializeField] int poolMax;

    BulletMovement Bmove;

    List<GameObject> objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
        for (int i = 0; i < poolMax; i++)
        {
            GameObject g = Instantiate(objectToPool, this.transform);
            g.SetActive(false);
            objects.Add(g);
        }
    }

    //FInd inactive bullets
    public GameObject FindUnusedObject()
    {
        
        foreach (GameObject g in objects)
        {
            if (!g.activeInHierarchy)
            {
                g.transform.SetParent(this.transform);
                return g;
            }
            
            
        }
        GameObject obj = Instantiate(objectToPool, this.transform);
        return obj;

    }
}
