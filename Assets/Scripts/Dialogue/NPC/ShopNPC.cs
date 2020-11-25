using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : NPC
{

    [SerializeField] private Shop shop;
    public override void Interact()
    {
        shop.showShop = true;
        Debug.Log("Shop NPC");
    }
}
