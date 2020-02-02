using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBackground(3);
        UIManager.instance.SetMaxHealth(5);
        UIManager.instance.SetBossHealth(30);
        //UIManager.instance.SetTimer(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
