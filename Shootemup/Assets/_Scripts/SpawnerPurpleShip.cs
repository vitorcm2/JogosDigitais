using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPurpleShip : MonoBehaviour
{

    public GameObject Nave;
    // Start is called before the first frame update
    void Start()
{
    for(int i = 0; i < 10; i++)
    {
        for(int j = 0; j < 2; j++){
           Vector3 posicao = new Vector3(2 + 10f * i, 3f - 6f * j);
           Instantiate(Nave, posicao, Quaternion.identity, transform);
          }
    }
}

}
