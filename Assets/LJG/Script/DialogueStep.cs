using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueStep : MonoBehaviour
{
    public string line;

    public bool hasStatAffect;
    public string statToAffect;
    public int statChangeAmount;
}
