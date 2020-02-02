using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;
    public GameObject dialogueUI;
    public bool isOnCooldown;
    public string message;

    private void Awake()
    {
        //StartDialogue();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetDialogue(string dialogue)
    {
        message = dialogue;
        StartDialogue();
    }

    public void StartDialogue()
    {
        if (!isOnCooldown)
        {
            StartCoroutine(Talking());
        }
    }

    IEnumerator Talking()
    {
        isOnCooldown = true;
        dialogueUI.GetComponent<Animator>().SetBool("IsOpen", true);
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(Speaking());
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueUI.GetComponentInChildren<TextMeshProUGUI>().text = "";
                dialogueUI.GetComponent<Animator>().SetBool("IsOpen", false);
                still_looking = false;
            }
            yield return null;
        }
        isOnCooldown = false;
    }

    IEnumerator Speaking()
    {
        string temp = "";
        foreach (var letter in message)
        {
            temp += letter;
            dialogueUI.GetComponentInChildren<TextMeshProUGUI>().text = temp;
            yield return new WaitForEndOfFrame();
        }
    }
}
