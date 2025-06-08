using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;

    private Queue<DialogueStep> dialogueSteps = new Queue<DialogueStep>();
    private DialogueStep currentStep;
    private bool isDialogueActive = false;

    public void StartDialogue(DialogueData data)
    {
        dialogueSteps.Clear();
        foreach (var step in data.steps)
            dialogueSteps.Enqueue(step);

        dialoguePanel.SetActive(true);
        isDialogueActive = true;

        DisplayNextStep();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextStep();
        }
    }

    public void DisplayNextStep()
    {
        if (dialogueSteps.Count == 0)
        {
            EndDialogue();
            return;
        }

        currentStep = dialogueSteps.Dequeue();
        dialogueText.text = currentStep.line;

        if (currentStep.hasStatAffect)
        {
            PlayerStats.Instance.AddSubjectStat(currentStep.statToAffect, currentStep.statChangeAmount);
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }
}
