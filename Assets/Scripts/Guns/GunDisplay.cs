using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{

    public Weapon currentWeapon;
    public Gun gun;


    private SpriteRenderer GunSpriteRender;

    private void Awake() {
        
        GunSpriteRender = GetComponent<SpriteRenderer>();

    }

    private void Start() {
        SetWeaponSettings(currentWeapon);
    }

    public void SetWeaponSettings(Weapon weapon){

        GunSpriteRender.sprite = weapon.image;

        gun.infoWeapon = weapon;
        gun.bullets = (int)weapon.maxBullets.GetValue(weapon.level);       

    }


}
