using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{

    [SerializeField] private int HP;
    public void Hurt(int damage)
    {
        Debug.Log("Hit :" + damage);
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
