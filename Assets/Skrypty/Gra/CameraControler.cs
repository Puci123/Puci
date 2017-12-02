using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public float speed;

	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed,0);		
	}
}
