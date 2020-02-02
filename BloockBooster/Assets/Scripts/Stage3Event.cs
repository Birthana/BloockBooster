using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetMaxHealth(5);
        UIManager.instance.SetTimer(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
