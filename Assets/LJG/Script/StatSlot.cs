using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSlot : MonoBehaviour
{
    public Text statNameText;
    public Text valueText;
    public Button plusButton;
    public Button minusButton;

    [HideInInspector] public int value = 0;
    [HideInInspector] public int index;
    [HideInInspector] public statDistributionManager manager;

    public void Init(int _index, statDistributionManager _manager)
    {
        index = _index;
        manager = _manager;

        plusButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();

        plusButton.onClick.AddListener(() => manager.Increase(index));
        minusButton.onClick.AddListener(() => manager.Decrease(index));
    }

    public void UpdateDisplay()
    {
        valueText.text = value.ToString();
    }
}
