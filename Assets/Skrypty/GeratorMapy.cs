using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeratorMapy : MonoBehaviour {

    public float x, y;
    public Transform komorka;
    public Transform rodzic;

	void Start () {
        Generuj();
	}
	
	void Update () {
		
	}

    void Generuj()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Instantiate(komorka, pos, Quaternion.identity).SetParent(rodzic);
                pos.x += komorka.transform.lossyScale.x;
            }
            pos.z += komorka.transform.lossyScale.y;
            pos.x = pos.x - pos.x;
        }
    }
}
