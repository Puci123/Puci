using UnityEngine;
using UnityEngine.EventSystems;

public class Przeciagnij : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public bool siatkaIstneje = false;
    private bool czyJestNaRece = false;
  
    private Transform reka;
    private Transform gui;


   

    private void Start()
    {
        reka = GameObject.FindGameObjectWithTag("Reka").GetComponent<Transform>();
        gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.parent = gui;

        if(transform.parent != reka && siatkaIstneje) //sprawdz czy karta jest aktualnie uzywana 
        {
            GetComponent<Karta>().Zniszcz();
            Zmienne.wyswietlam = false; 
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (czyJestNaRece == true)
        {
            transform.parent = reka;
        }
        czyJestNaRece = true;

    }

    public void ZmienRodzica(Transform t)
    {
        czyJestNaRece = false;
        GetComponent<Transform>().parent = t;
    }

    public void CzyJestWTali(bool czyJestWtali)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = !czyJestWtali;
    }
}
