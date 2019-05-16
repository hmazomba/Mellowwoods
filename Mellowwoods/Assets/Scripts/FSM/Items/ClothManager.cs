using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM{
    public class ClothManager : MonoBehaviour
    {
        Dictionary<ClothItemType, ClothItemHook> clothes = new Dictionary<ClothItemType, ClothItemHook>();
        public void Init()
        {
            ClothItemHook[] clothItemHooks = GetComponentsInChildren<ClothItemHook>();
            foreach (ClothItemHook hook in clothItemHooks)
            {
                hook.Init();
            }
        }

        public void RegisterClothHook(ClothItemHook clothItemHook)
        {
            if(!clothes.ContainsKey(clothItemHook.clothItemType))
            {
                clothes.Add(clothItemHook.clothItemType, clothItemHook);
            }
        }
        public void LoadListOfItems(List<ClothItem> clothItems)
        {
            UnloadAllItems(clothItems);

            for (int i = 0; i < clothItems.Count; i++)
            {
                LoadItem(clothItems[i]); 
            }
        }

        public void UnloadAllItems(List<ClothItem> clothItems)
        {
            foreach (ClothItemHook hook in clothes.Values)
            {
                hook.UnloadClothItem();
            }
        }

        ClothItemHook GetClothHook(ClothItemType target)
        {
            clothes.TryGetValue(target, out ClothItemHook returnValue);
            return returnValue;
        }

        public void LoadItem(ClothItem clothItem){
            ClothItemHook itemHook = null;
            if(clothItem == null){
                return;
                
            }

            itemHook = GetClothHook(clothItem.clothItemType);
            itemHook.LoadClothItem(clothItem);
            
        }
    }

}
