using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komorka : MonoBehaviour {

    public LayerMask nieChodliwy;

    private Wskaznik wskaznik;
    private Idz idz;

    private void Start()
    {
        wskaznik = GameObject.Find("Wskaznik").GetComponent<Wskaznik>();
        if (Physics.CheckSphere(transform.position, transform.lossyScale.x / 2 - 0.1f, nieChodliwy))
        {
            Destroy(gameObject);
        }
    }

    public void Przyjmij(Idz _idz)
    {
        idz = _idz;
    }

    private void OnMouseDown()
    {
        idz.Schowaj();
        wskaznik.Przestaw(transform.position);
    }
}
