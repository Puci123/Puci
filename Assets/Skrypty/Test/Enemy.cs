using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public bool kolejPrzeciwnika = true;
    public float movePoints;
    private float maxPunkty;
    public Transform[] patrolPoints;
    private NavMeshAgent agnent;
    private int aktualny = 0;

    void Start () {
        agnent = GetComponent<NavMeshAgent>();
        maxPunkty = movePoints;
        print(maxPunkty);
	}
	void Update () {
        Patrol();
	}

    void Patrol()
    {
        if (kolejPrzeciwnika)
        {
            if (transform.position.x == patrolPoints[aktualny].transform.position.x && transform.position.z == patrolPoints[aktualny].transform.position.z)
            {
                aktualny++;
                if (aktualny > patrolPoints.Length - 1)
                    aktualny = 0;

            }
            agnent.destination = patrolPoints[aktualny].position;

            if(movePoints >= 0)
            {
                movePoints -= 0.5f;

            }
            else if(movePoints <= 0)
            {
                agnent.Stop();
                kolejPrzeciwnika = false;
                TuraPrzeciwnika();
            }
        }
    }

    void TuraPrzeciwnika()
    {
        StartCoroutine(Czekaj(2));
        agnent.Resume();
        kolejPrzeciwnika = true;
        movePoints = maxPunkty;
    }


    IEnumerator Czekaj(float ile) {
        yield return new WaitForSeconds(ile);
    }
}
