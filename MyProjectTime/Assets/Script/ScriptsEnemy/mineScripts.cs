using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineScripts : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MyPlayer player = other.GetComponent<MyPlayer>();
            player.Hurt(_damage);
            Destroy(gameObject);
        }
    }

}
