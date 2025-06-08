using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectSlot : MonoBehaviour
{
    public Text subjectNameText;
    public Text statValueText;

    public void SetSlot(string subjectName, int value)
    {
        subjectNameText.text = subjectName;
        statValueText.text = value.ToString();
    }
}
