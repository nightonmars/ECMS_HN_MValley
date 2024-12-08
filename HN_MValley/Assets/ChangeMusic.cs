using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
   [SerializeField] private FMOD_Ambience ambience;

   public bool tower = true; 
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         if (tower)
         {
            ambience.FirstTower();   
         }
         else
         {
            ambience.PuzzledSolved();
         }
         
      }
   }
}
