using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gameplay : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());

        Invoke("SpawnCar", 3);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject == null)
        {
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        int indexRespawn = Random.Range(0, respawns.Length);
        if (respawns[indexRespawn].GetComponent<RespawnCheck>().something == null)
            PhotonNetwork.Instantiate("Car", respawns[indexRespawn].transform.position,respawns[indexRespawn].transform.rotation, 0);
        else
            Invoke("SpawnCar", 0.1f);
    }
    public IEnumerator Loading()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        loadingScreen.SetActive(false);
    }

}
