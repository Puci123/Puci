using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {
  
    public float size;
    private RectTransform rt;
    private bool collision = false, odwiedzono = false;
    private RectTransform drag;
    private List<Collision2D>colList = new List<Collision2D>();

	void Start () {
        rt = gameObject.GetComponent<RectTransform>();
        drag = null;
	}
	
	void FixedUpdate() {
        if(drag != null && drag.anchoredPosition != rt.anchoredPosition)
           SprawdzPozycje(drag);

    }
    public void SetSize(float s)
    {
        rt.localScale = new Vector2(s,s);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //if(colList.Count < 1)
        //colList.Add(other);
        //else
        //{
        //    colList[0].gameObject.GetComponent<Drag>().ReturnToStart();
        //    colList.Remove(colList[0]);
        //    colList.Add(other);
        //}
        

        if (drag == null)
        {
            SetSize(size);
            drag = other.gameObject.GetComponent<RectTransform>();
            collision = true;
        }
        else if(drag != other.gameObject.GetComponent<RectTransform>())
        {

            other.gameObject.GetComponent<Drag>().ReturnToStart();
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (drag != null)
        {
            other.gameObject.GetComponent<RectTransform>().anchoredPosition = rt.anchoredPosition;
            collision = true;
        }
        else if (drag != other.gameObject.GetComponent<RectTransform>())
        {

            other.gameObject.GetComponent<Drag>().ReturnToStart();
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        print("Objekt : " + other.gameObject.transform.name + " wyszedł z kolizji z objektem :" + transform.name);
        if (drag == other.gameObject.GetComponent<RectTransform>())
        {
            SetSize(1);
            collision = false;
            drag = null;
        }
        else
        {
            other.gameObject.GetComponent<Drag>().ReturnToStart();
        }
    }

    public RectTransform Collision()
    {
        return drag;
    }
    public bool isEmpty()
    {
        return collision;
    }
    void SprawdzPozycje(RectTransform otherPos)
    {
        if(otherPos.anchoredPosition != GetComponent<RectTransform>().anchoredPosition && !drag.GetComponent<Drag>().IsDraging() )
        {
            SetSize(1);
            collision = false;
            drag = null;
            print("Sprawdzono pozycje");
        }
    }
}
