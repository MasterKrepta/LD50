using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidRecpies : MonoBehaviour
{
    public GameObject recpies;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)/* && recpies.activeInHierarchy*/)
        {
            recpies.transform.GetChild(0).gameObject.SetActive(!recpies.transform.GetChild(0).gameObject.activeInHierarchy);
            //recpies.SetActive(!recpies.activeInHierarchy);
        }
    }
}
