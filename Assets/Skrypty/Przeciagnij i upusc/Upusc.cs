﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Upusc : MonoBehaviour, IDropHandler
{
    public Transform reka;
    public int rozmoiar;
    public Cmentarz cmentarz;

    private void Start()
    {
       reka = GameObject.FindGameObjectWithTag("Reka").GetComponent<Transform>();
    }


    public void OnDrop(PointerEventData eventData)
    {
      
         if (!Zmienne.wyswietlam)
         {
            eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
            eventData.pointerDrag.GetComponent<Przeciagnij>().jestWupuszeniu = true;
            eventData.pointerDrag.GetComponent<Karta>().CzaryMary();
         }
        Zmienne.wyswietlam = true;
        
    }

    public void Usun()
    {
        Transform[] karty = new Transform[transform.childCount];
        karty = gameObject.GetComponentsInChildren<Transform>();
        karty[0] = null;
        cmentarz.Przyjmij(karty);
    }

}
