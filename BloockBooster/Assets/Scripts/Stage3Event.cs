using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SoundManager.instance.PlayBackground(3);
        UIManager.instance.SetMaxHealth(15);
        UIManager.instance.SetBossHealth(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
