using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public GameObject heart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameControl.health += 1;
        if(GameControl.health > 5)
        {
            GameControl.health += 0;
        }
        Destroy(heart);
    }
}
