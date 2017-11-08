using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomorkaAtak : PodstawowaKomorka {

    Transform tran_;
    public LayerMask enemy;

    private void Start()
    {
        if (!Physics.CheckSphere(transform.position, transform.lossyScale.x / 2 - 0.05f, enemy))
            Destroy(this.gameObject);
    }
    private void OnMouseDown()
    {
        tran_.GetComponent<Atak>().Schowaj();

    }

    override
    public void Przyjmij(Transform tran)
    {
        tran_ = tran;
    }

}
