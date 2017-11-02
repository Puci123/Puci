using UnityEngine;
using UnityEngine.EventSystems;

public class Upusc : MonoBehaviour, IDropHandler
{
    public Transform reka;
    public GameObject[] rzecz;
    public int rozmoiar;
    

    private void Start()
    {
       reka = GameObject.FindGameObjectWithTag("Reka").GetComponent<Transform>();
        rzecz = new GameObject[rozmoiar];
    }


    public void OnDrop(PointerEventData eventData)
    {
      
         if (!Zmienne.wyswietlam)
         {
            eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
            eventData.pointerDrag.GetComponent<Przeciagnij>().jestWupuszeniu = true;
            eventData.pointerDrag.GetComponent<Karta>().CzaryMary();
            for (int i = 0; i < rozmoiar; i++)
            {
                if (rzecz[i] == null)
                {
                    rzecz[i] = eventData.pointerDrag.gameObject;
                    break;
                }
            }
         }
        Zmienne.wyswietlam = true;
        
    }

}
