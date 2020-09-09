using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheck : MonoBehaviour
{
    public GameObject something;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            something = collider.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        something = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
