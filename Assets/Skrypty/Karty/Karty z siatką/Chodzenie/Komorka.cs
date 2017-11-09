using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komorka : PodstawowaKomorka {

    public LayerMask nieChodliwy;
    public LayerMask przeciwnik;

    private Idz idz;

    private void Start()
    {
        if (Physics.CheckSphere(transform.position, transform.lossyScale.x / 2 - 0.05f, nieChodliwy) || transform.position == idz.gracz.position)
        {
            Destroy(gameObject);
        }else if(Physics.CheckSphere(transform.position, transform.lossyScale.x / 2 - 0.05f, przeciwnik)){
            Destroy(gameObject);

        }
    }

    override
    public void Przyjmij(Transform tran)
    {
        idz = tran.gameObject.GetComponent<Idz>();
    }

    private void OnMouseDown()
    {
        idz.Przejdz(transform.position);
        idz.Schowaj();
        
    }
}
