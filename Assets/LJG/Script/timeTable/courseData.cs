using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class courseData
{
    public string courseName;
    public int length;
    public Color color;
    public int totalCost;


    public courseData(string name, int len, Color c)
    {
        courseName = name;
        length = len;
        color = c;
        totalCost = 0;
    }
}
