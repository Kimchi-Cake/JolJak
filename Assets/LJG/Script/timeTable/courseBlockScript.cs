using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class courseBlockScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public courseData data;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    public LayerMask slotLayerMask;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(courseData d)
    {
        data = d;

        GetComponent<Image>().color = d.color;
        GetComponentInChildren<Text>().text = d.courseName;

        rectTransform.sizeDelta = new Vector2(100, d.length * 50);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var result in results)
        {
            slotScript slot = result.gameObject.GetComponent<slotScript>();
            if (slot != null)
            {
                if (CanPlaceBlock(slot))
                {
                    PlaceBlock(slot);
                    return;
                }
            }
        }


        rectTransform.anchoredPosition = originalPosition;
    }

    bool CanPlaceBlock(slotScript startSlot)
    {
        int startPeriod = startSlot.periodIndex;
        int day = startSlot.dayIndex;

        if(startPeriod + data.length > 7) return false;

        for (int i = 0; i < data.length; i++)
        {
            slotScript s = timeTableManajer.Instance.GetSlot(day, startPeriod + i);
            if (s == null || s.isOccupied) return false;
        }

        return true;
    }


    void PlaceBlock(slotScript startSlot)
    {
        int startPeriod = startSlot.periodIndex;
        int day = startSlot.dayIndex;

        int totalCost = 0;

        for (int i = 0; i < data.length; i++)
        {
            slotScript s = timeTableManajer.Instance.GetSlot(day, startPeriod + i);
            totalCost += s.cost;
        }

        if (!courseManager.Instance.CanAfford(totalCost))
        {
            Debug.LogWarning("코스트 초과! 배치 불가");
            rectTransform.anchoredPosition = originalPosition; 
            return;
        }

        Vector2 newPos = startSlot.GetComponent<RectTransform>().anchoredPosition;
        rectTransform.anchoredPosition = newPos;

        for (int i = 0; i < data.length; i++)
        {
            slotScript s = timeTableManajer.Instance.GetSlot(day, startPeriod + i);
            s.isOccupied = true;
        }

        courseManager.Instance.AddCost(totalCost);

        Debug.Log($"{data.courseName} 배치 완료 | 코스트: {totalCost}, 누적: {courseManager.Instance.currentCost}");
    }
}
