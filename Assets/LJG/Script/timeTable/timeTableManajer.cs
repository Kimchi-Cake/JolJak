using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTableManajer : MonoBehaviour
{
    public static timeTableManajer Instance; 

    public GameObject slotPrefab;
    public Transform timetableParent;

    private slotScript[,] slots = new slotScript[5, 7];

    void Awake()
    {
        Instance = this; 
    }


    public slotScript GetSlot(int day, int period)
    {
        if (day < 0 || day >= 5 || period < 0 || period >= 7) return null;
        return slots[day, period];
    }

    void Start()
    {
        GenerateTimetable();
    }

    void GenerateTimetable()
    {
        for (int period = 0; period < 7;  period++)
        {
            for (int day = 0; day < 5; day++)
            {
                GameObject slot = Instantiate(slotPrefab, timetableParent);
                slot.GetComponent<slotScript>().Init(day, period);
            }
        }
    }
}
