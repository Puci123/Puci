using UnityEngine;
using UnityEngine.EventSystems;

public class Upusc : MonoBehaviour, IDropHandler
{
    public Transform reka;
    public GameObject rzecz = null;
    

    private void Start()
    {
       reka = GameObject.FindGameObjectWithTag("Reka").GetComponent<Transform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!Zmienne.wyswietlam)
        {
            if (transform.childCount == 0)
            {
                eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
                eventData.pointerDrag.GetComponent<Karta>().CzaryMary();
                rzecz = eventData.pointerDrag;
 
            }
            else if (transform.childCount > 0)
            {
                rzecz.transform.parent = reka;
                rzecz = null;
                eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
                eventData.pointerDrag.GetComponent<Karta>().CzaryMary();
                rzecz = eventData.pointerDrag;

            }
            Zmienne.wyswietlam = true;
        
        }
    }

}
