using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject creditsButton;
    public GameObject creditPoster;
    private bool isRunning;
    private bool isShowingPoster;

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
        yield return new WaitForSeconds(3.0f);
        creditsButton.GetComponent<Animator>().SetBool("IsOpen", true);
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        if (!isShowingPoster)
        {
            StartCoroutine(ShowPoster());
        }
    }

    IEnumerator ShowPoster()
    {
        isShowingPoster = true;
        creditPoster.GetComponent<Animator>().SetBool("IsOpen", true);
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                creditPoster.GetComponent<Animator>().SetBool("IsOpen", false);
                still_looking = false;
            }
            yield return null;
        }
        isShowingPoster = false;
    }
}
