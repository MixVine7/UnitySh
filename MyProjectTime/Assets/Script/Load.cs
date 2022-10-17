using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    public int level;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Application.LoadLevel(level);
        }
    }
}
