using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotScript : MonoBehaviour
{
    public int dayIndex;
    public int periodIndex;
    public int cost;
    public bool isOccupied = false;

    public void Init(int day, int period)
    {
        dayIndex = day;
        periodIndex = period;
        cost = period + 1;


        GetComponentInChildren<Text>().text = $"{period+1}교시\n코스트: {cost}";
    }
}
