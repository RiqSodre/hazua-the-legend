using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public GameObject heart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameControl.health >= 5)
        {
            GameControl.health += 0;
        }
        else
        {
            GameControl.health += 1;
            Destroy(heart);
        }
    }
}
