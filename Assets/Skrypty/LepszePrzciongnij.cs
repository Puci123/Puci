using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LepszePrzciongnij : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform powroc = null;
    private bool h = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.parent = GameObject.Find("Canvas").GetComponent<Transform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (h == true)
        {
            transform.parent = GameObject.Find("Renka").GetComponent<Transform>();
            print("a teraz u");
        }
        h = true;
    }

    public void ZminaRodica(Transform t)
    {
        h = false;
        print("jestem tutaj");
        GetComponent<Transform>().parent = t;
    }
}
