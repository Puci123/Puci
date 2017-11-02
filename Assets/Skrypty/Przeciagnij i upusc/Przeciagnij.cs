using UnityEngine;
using UnityEngine.EventSystems;

public class Przeciagnij : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public bool siatkaIstneje = false;
    public bool jestWupuszeniu = false;

    public int pozycja;
  
    private Transform reka;
    private Transform gui;


   

    private void Start()
    {
        reka = GameObject.FindGameObjectWithTag("Reka").GetComponent<Transform>();
        gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (siatkaIstneje)
            GetComponent<Karta>().Zniszcz();
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        jestWupuszeniu = false;
        ZmienRodzica(gui);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (!jestWupuszeniu)
            ZmienRodzica(reka);
    }

    public void ZmienRodzica(Transform t)
    {
        GetComponent<Transform>().parent = t;
    }

    public void CzyJestWTali(bool czyJestWtali)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = !czyJestWtali;
    }
}
