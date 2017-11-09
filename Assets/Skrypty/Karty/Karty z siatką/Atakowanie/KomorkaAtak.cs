using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomorkaAtak : PodstawowaKomorka {

    Transform tran_;
    public LayerMask enemy;
    private bool jestWrog;
    private Transform other;

   

    private void Start()
    {
        if (!Physics.CheckSphere(transform.position, transform.lossyScale.x / 2 - 0.1f, enemy))
        {
            Destroy(this.gameObject);
        }else
         ZnajdzPrzeciwnika();
        
    }
    private void OnMouseDown()
    {
        other.GetComponent<Przeciwnik>().PryjmijObrażenia(1);
        tran_.GetComponent<Atak>().Schowaj();
    }


    override
    public void Przyjmij(Transform tran)
    {
        tran_ = tran;
    }

    void ZnajdzPrzeciwnika()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (item.transform.position.x == transform.position.x && item.transform.position.z == item.transform.position.z)
            {
                other = item.transform;
                break;
            }
        }
    }

}
