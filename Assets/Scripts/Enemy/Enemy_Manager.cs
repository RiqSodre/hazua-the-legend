using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    public GameObject playerHealth;   // Referencia a vida do player.
    public GameObject enemy;          // Prefab do enemy para o spawn.
    public float spawnTime = 3f;      // Tempo entre os spawns.
    public Transform[] spawnPoints;   // Pontos em que o enemy pode spawnar.


    void Start()
    {
        //Chama a função de spawn depois de um tempo e continua chamando.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (GameControl.health <= 0)
        {
            return;  //Sai da função
        }
        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}