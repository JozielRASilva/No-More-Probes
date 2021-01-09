using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Features/Weapons", order = 0)]
public class Weapon : ScriptableObject
{
    public new string name;

    [Range(0, 5)]
    public int level = 1;

    public Status damage;

    public Status speed;

    public Status coolDown;

    public Status maxBullets;

    public Status costByBullet;

    public Sprite image;

}
