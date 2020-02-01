using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage2UIManager : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject timerUI;

    private void Awake()
    {
        Stage2GameManager.OnPlayerChange += SetUI;
    }

    public void SetUI(float currentHealth, float currentTime)
    {
        playerUI.GetComponent<TextMeshProUGUI>().text = "" + currentHealth;
        timerUI.GetComponent<TextMeshProUGUI>().text = " "+ string.Format("{0:0.0}", currentTime);
    }
}
