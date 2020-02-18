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
    public GameObject bossHealthText;
    public GameObject heartPrefab;
    public Sprite heartLossSprite;

    public int maxHealth;
    private int currentHealth;
    public float maxTimer;
    private float currentTimer;
    private bool isTimerOn;
    private int nextScene;
    public int bossHealth;
    private int currentBossHealth;
    private bool isBossHealthOn;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentHealth = maxHealth;
            currentTimer = maxTimer;
            //ShowHealth();
            timer.SetActive(false);
            bossHealth = currentBossHealth;
            bossHealthText.SetActive(false);
            //StartTimer();
            //SetMaxHealth(5);
        }
        else
        {
            Destroy(this.gameObject);
            ;
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
        if (isBossHealthOn)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            bossHealthText.transform.position = Camera.main.WorldToScreenPoint(boss.transform.position);
        }
    }

    public void BossTakeDamage()
    {
        currentBossHealth--;
        bossHealthText.GetComponent<TextMeshProUGUI>().text = "" + currentBossHealth;
        if (currentBossHealth <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void SetMaxHealth(int health)
    {
        foreach (Transform child in healthHearts.transform)
        {
            Destroy(child.gameObject);
        }
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

    public void SetBossHealth(int health)
    {
        bossHealth = health;
        currentBossHealth = bossHealth;
        ShowBossHealthBar();
    }

    public void ShowBossHealthBar()
    {
        isBossHealthOn = true;
        bossHealthText.SetActive(true);
        bossHealthText.GetComponent<TextMeshProUGUI>().text = "" + currentBossHealth;
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
            //Debug.Log("Game Over.");
            SceneManager.LoadScene(6);
        }
    }

    public void StartTimer()
    {
        timer.SetActive(true);
        isTimerOn = true;
    }
}
