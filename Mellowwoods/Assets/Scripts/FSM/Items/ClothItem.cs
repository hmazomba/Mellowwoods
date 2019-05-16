using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "/FSM/Items/ClothItem")]
    public class ClothItem : ScriptableObject {
        public ClothItemType clothItemType;
        public Mesh mesh;
        public Material clothMaterial;
    }
}
