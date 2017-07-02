using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour {
    Vector3 pos;

    void Update()
    {
        // Komputer
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("hittable"))
                {
                    Debug.Log(hit.point);
                    gameObject.GetComponent<Transform>().position = hit.point;
                }
            }
        }
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Plane")
                {
                    Debug.Log(hit.point);
                    gameObject.GetComponent<Transform>().position = hit.point;
                }
                //Debug.Log(hit);
            }
        }
    }
}
