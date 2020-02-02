using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    private bool isRunning;

    private void Start()
    {
        SoundManager.instance.PlayBackground(0);
        if (!isRunning)
        {
            StartCoroutine(Revealing());
        }
    }

    IEnumerator Revealing()
    {
        isRunning = true;
        yield return new WaitForSeconds(5.0f);
        playButton.GetComponent<Animator>().SetBool("IsOpen", true);
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
