using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlideController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform sideMenuRectTransform;
    private float height;
    private float startPositionY;
    private float startingAnchoredPositionY;

    public enum Side { top, bottom }
    public Side side;

    // Start is called before the first frame update
    void Start()
    {
        height = Screen.height;
    }

    public void OnDrag(PointerEventData eventData)
    {
        sideMenuRectTransform.anchoredPosition = new Vector2(0, Mathf.Clamp(startingAnchoredPositionY - (startPositionY - eventData.position.y), GetMinPosition(), GetMaxPosition()));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        startPositionY = eventData.position.y;
        startingAnchoredPositionY = sideMenuRectTransform.anchoredPosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float currentPos = sideMenuRectTransform.anchoredPosition.y;
        float minPos = GetMinPosition();
        float maxPos = GetMaxPosition();

        if (currentPos < minPos + (maxPos - minPos) / 2)
        {
            StartCoroutine(HandleMenuSlide(0.25f, currentPos, minPos));
        }
        else
        {
            StartCoroutine(HandleMenuSlide(0.25f, currentPos, maxPos));
        }
    }

    private float GetMinPosition()
    {
        if (side == Side.bottom)
            return -height * 0.4f;
        return height / 2;
    }

    private float GetMaxPosition()
    {
        if (side == Side.bottom)
            return height * 1.4f;
        return height / 2;
    }

    private IEnumerator HandleMenuSlide(float slideTime, float startingY, float targetY)
    {
        for (float i = 0; i <= slideTime; i += 0.025f)
        {
            sideMenuRectTransform.anchoredPosition = new Vector2(0, Mathf.Lerp(startingY, targetY, i / slideTime));
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }
}
