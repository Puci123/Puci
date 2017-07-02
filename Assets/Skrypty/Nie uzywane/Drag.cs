using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    private Vector2 startPos;
    private RectTransform rt;
    private bool isDraging;
    private Drop drop;

	void Start () {
        rt = gameObject.GetComponent<RectTransform>();
        drop = GameObject.Find("Drop").GetComponent<Drop>();
        startPos = rt.anchoredPosition;
	}
	
	void FixedUpdate () {
        if (isDraging)
        {
            rt.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
	}

    public void DoThings()
    {
        isDraging = true;
        GetComponent<BoxCollider2D>().enabled = true;

    }
    public void UndoThngs()
    {
        isDraging = false;
        bool h = false;
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Drop");
        foreach (GameObject d in drops)
        {
            Drop _drop = d.GetComponent<Drop>();
            if (rt == (_drop.Collision()) && _drop.isEmpty())
            {
                h = true;
            }
        }
        if (!h)
        {
            rt.anchoredPosition = startPos;
        }
    }

    public void ReturnToStart()
    {
        rt.anchoredPosition = startPos;
    }
    public bool IsDraging()
    {
        return isDraging;
    }
}
