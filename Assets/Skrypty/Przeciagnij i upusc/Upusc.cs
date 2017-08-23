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

        if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
            rzecz = eventData.pointerDrag;
        }
        else if (transform.childCount > 0)
        {
            rzecz.transform.parent = reka;
            rzecz = null;
            eventData.pointerDrag.GetComponent<Przeciagnij>().ZmienRodzica(GetComponent<Transform>());
            rzecz = eventData.pointerDrag;
        }

    }
}
