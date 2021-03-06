using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    CanvasGroup canvasGroup;

    Vector3 startingPoint;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvas == null)
        {
            canvas = GameObject.Find("GamePlayCanvas").GetComponent<Canvas>(); //Sanity Check for when we are sleepy
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startingPoint = transform.position;
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    

    public void OnDrag(PointerEventData eventData)
    {
        //TODO game logic
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void Reset()
    {
        transform.position = startingPoint;
    }
}
