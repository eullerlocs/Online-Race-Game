using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TerrainConfig : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("colidiu");
            Destroy(car);
            PhotonNetwork.Instantiate("car", transform.position, Quaternion.identity, 0);
        }
    }
}
