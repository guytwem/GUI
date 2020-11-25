﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{ 
    Food,
    Weapon,
    Apparel,
    Crafting,
    Ingredients,
    Potions,
    Scrolls,
    Quest,
    Money


}

[System.Serializable]
public class Item
{
    #region Private Variables
    private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int value;
    [SerializeField] private int amount;
    [SerializeField] private Texture2D icon;
    [SerializeField] private GameObject mesh;
    [SerializeField] private ItemType type;
    [SerializeField] private int damage;
    [SerializeField] private int armour;
    [SerializeField] private int heal;
    #endregion

    #region Public Properties
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public Texture2D Icon
    {
        get { return icon; }
        set { icon = value; }

    }

    public GameObject Mesh
    {
        get { return mesh; }
        set { mesh = value; }
    }


    public ItemType Type
    {
        get { return type; }
        set { type = value; }

    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Armour
    {
        get { return armour; }
        set { armour = value; }
    }
    public int Heal
    {
        get { return heal; }
        set { heal = value; }
    }
    #endregion

    public Item()
    {

    }

    public Item(Item copyitem, int copyAmount)
    {
        name = copyitem.Name;
        description = copyitem.Description;
        value = copyitem.Value;
        amount = copyAmount;
        icon = copyitem.Icon;
        mesh = copyitem.Mesh;
        type = copyitem.Type;
        damage = copyitem.Damage;
        armour = copyitem.Armour;
        heal = copyitem.Heal;
    }

}
