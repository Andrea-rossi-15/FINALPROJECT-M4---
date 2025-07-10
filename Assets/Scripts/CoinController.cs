using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        {
            UIController counter = FindObjectOfType<UIController>();
            if (collision.collider.CompareTag("Player") && counter != null)
            {
                counter.AddCoin();
                Destroy(gameObject);
            }
        }
    }

}
