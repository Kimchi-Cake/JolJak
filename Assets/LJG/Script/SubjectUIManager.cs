using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectUIManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;

    void Start()
    {
        var stats = PlayerStats.Instance.subjectStats[PlayerStats.Instance.currentSemester];

        foreach (var pair in stats)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            SubjectSlot slotScript = slot.GetComponent<SubjectSlot>();
            slotScript.SetSlot(pair.Key, pair.Value);
        }
    }
}
