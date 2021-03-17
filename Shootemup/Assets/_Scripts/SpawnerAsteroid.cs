using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{
    GameManager gm;
    public GameObject Asteroid;
    // Start is called before the first frame update
    void Start()
{   
    gm = GameManager.GetInstance();
    if (gm.gameState != GameManager.GameState.GAME) return;
    for(int i = 0; i < 40; i++)
    {
        for(int j = 0; j < 2; j++){
            float number = Random.Range (-4f, 4f);
           Vector3 posicao = new Vector3(4 + 12f * i, number*j);
           Instantiate(Asteroid, posicao, Quaternion.identity, transform);
          }
    }
}

}
