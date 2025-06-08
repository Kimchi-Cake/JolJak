using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public DialogueUI dialogueUI;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        dialogueUI.StartDialogue(dialogueData);
    }
}
