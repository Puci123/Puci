using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upusc : MonoBehaviour {

   protected Przeciagnij slot;
   protected RectTransform rt;
   protected Vector2 pos;
   protected Vector2 slotPos;


     void Start () {
        rt = gameObject.GetComponent<RectTransform>();
        print(rt.anchoredPosition);
        pos = rt.anchoredPosition;
    }
     void Update () {
		if(slot != null)
        {
          slotPos = slot.GetComponent<RectTransform>().anchoredPosition;
         float odleglosc = Mathf.Sqrt(Mathf.Pow(pos.x - slotPos.x, 2) + Mathf.Pow(pos.y - slotPos.y, 2));
            if(odleglosc > 100)
            {
                slot = null;
            }

        }
    }
    public void Dodaj(Przeciagnij nowy)
    {
        if(slot != null)
        {
            slot.PowrocNaStart();
        }
        slot = nowy;

        slot.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y);
       // ZmienRozmiar(1.2f);
    }
    public void ZmienRozmiar(float s)
    {
        rt.localScale = new Vector2(s, s);
    }
}
