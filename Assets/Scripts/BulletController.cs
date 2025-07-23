using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;




    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().velocity = direction * speed;
            transform.forward = direction;
        }

        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}

