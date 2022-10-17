using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    [SerializeField] private GameObject endTrig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endTrig.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
