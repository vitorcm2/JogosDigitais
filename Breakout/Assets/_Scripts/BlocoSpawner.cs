﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Blocos;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
        
    }
    void Update()
{

    if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
   {
       gm.ChangeState(GameManager.GameState.ENDGAME);
   }
}
void Construir()
  {
     

       if (gm.gameState == GameManager.GameState.GAME)
      {
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
          for(int i = 0; i < 9; i++)
          {
              for(int j = 0; j < 4; j++){
                  Vector3 posicao = new Vector3(-7 + 1.7f * i, 4 - 0.7f * j);

                  Instantiate(Blocos, posicao, Quaternion.identity, transform);
              }
          }
      }
  }

}
