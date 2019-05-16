using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
   
   
   [CreateAssetMenu(menuName = "/FSM/Items/ClothItemType")]
   public class ClothItemType : ScriptableObject {
        public bool isDisabledWhenNoItem;
   }
}