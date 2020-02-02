using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public GameObject healthHearts;
    public GameObject timer;
    public GameObject heartPrefab;
    public Sprite heartLossSprite;

    public int maxHealth;
    private int currentHealth;
    public float maxTimer;
    private float currentTimer;
    private bool isTimerOn;
    private int nextScene;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentHealth = maxHealth;
            currentTimer = maxTimer;
            //ShowHealth();
            timer.SetActive(false);
            //StartTimer();
            //SetMaxHealth(5);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isTimerOn)
        {
            currentTimer -= Time.deltaTime;
            timer.GetComponentInChildren<TextMeshProUGUI>().text = " " + string.Format("{0:0.0}", currentTimer);
            if (currentTimer <= 0.0f)
            {
                isTimerOn = false;
                timer.SetActive(false);
                //Debug.Log("Timer at Zero.");
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        ShowHealth();
    }

    public void SetTimer(float timer, int scene)
    {
        maxTimer = timer;
        currentTimer = maxTimer;
        nextScene = scene;
        StartTimer();
    }

    public void ShowHealth()
    {
        if (currentHealth > 0)
        {
            for(int i = 0; i < maxHealth; i++)
            {
                GameObject tempHeart = Instantiate(heartPrefab, healthHearts.transform.position, Quaternion.identity);
                tempHeart.transform.SetParent(healthHearts.transform);
                tempHeart.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        for (int i = currentHealth; i < maxHealth; i++)
        {
            LoseHealth();
        }
    }

    public void LoseHealth()
    {
        GameObject tempHeart = healthHearts.transform.GetChild(currentHealth).gameObject;
        tempHeart.GetComponent<Image>().sprite = heartLossSprite;
        tempHeart.transform.SetParent(healthHearts.transform);
        tempHeart.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void TakeDamage()
    {
        currentHealth--;
        LoseHealth();
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over.");
        }
    }

    public void StartTimer()
    {
        timer.SetActive(true);
        isTimerOn = true;
    }
}
