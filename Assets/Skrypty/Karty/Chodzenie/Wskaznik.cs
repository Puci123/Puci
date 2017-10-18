using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wskaznik : MonoBehaviour {

	void Start () {

        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
}
