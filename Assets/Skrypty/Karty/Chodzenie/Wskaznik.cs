using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wskaznik : MonoBehaviour {

	void Start () {

        DoGracza();  
	}

    void DoGracza()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void Przestaw(Vector3 pos)
    {
        transform.position = pos;
    }
}
