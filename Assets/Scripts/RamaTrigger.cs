using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamaTrigger : MonoBehaviour
{
   public bool ramaA;
   public bool ramaB;
   public bool ramaC;

   public bool tengoHijo;

   void Update()
   {
      if (this.gameObject.transform.childCount >= 1)
      {
         tengoHijo = true;
      }

      else
      {
         tengoHijo = false;
      }
   }
}
