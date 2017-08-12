using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LepszeUpusc : MonoBehaviour, IDropHandler
{

    public GameObject rzecz = null;

    public void OnDrop(PointerEventData eventData)
    {
        print("Upuszczono w " + transform.name);

        if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<LepszePrzciongnij>().ZminaRodica(GetComponent<Transform>());
            rzecz = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<Karta>().CzaryMary();

        }
        else if (transform.childCount > 0)
        {
            rzecz.transform.parent = GameObject.Find("Renka").GetComponent<Transform>();
            rzecz = null;
            eventData.pointerDrag.GetComponent<LepszePrzciongnij>().ZminaRodica(GetComponent<Transform>());
            rzecz = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<Karta>().CzaryMary();
        }

    }
}
