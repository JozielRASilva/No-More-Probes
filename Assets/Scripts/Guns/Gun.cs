using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public new string name;

    public const int BULLETS_LIMIT = 15;
    public const int SPEED_LIMIT = 30;

    [Range(0, BULLETS_LIMIT)]
    public int bullets;

    public Weapon infoWeapon;


    private float currentTime;


    public IPipe pipe;

    public Bounds touchArea;

    private Vector2 EndPoint;

    public float securitySpace = 20;

    [Header("UI Info")]
    public List<Image> AmmoUI;
    public Color myAmmo;
    public Color extraAmmo;

    private void Start()
    {
        if (pipe == null)
            pipe = GetComponent<IPipe>();

        EndPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        touchArea.size = new Vector3(EndPoint.x * 2, EndPoint.y * 2 - (securitySpace / 10));
        touchArea.center = new Vector2(touchArea.center.x, touchArea.center.y - (securitySpace / 20));

    }

    private void Update()
    {

        if (CheckTouch())
        {

            if (bullets >= infoWeapon.costByBullet.GetValue(infoWeapon.level) && currentTime < Time.time)
            {

                
                pipe.Shoot(this);

                bullets -= (int)infoWeapon.costByBullet.GetValue(infoWeapon.level);

                currentTime = Time.time + infoWeapon.coolDown.GetValue(infoWeapon.level);

            }

        }

        UpdateAmmoUI();
    }



    private bool CheckTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (touchArea.Contains((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.cyan;

        Gizmos.DrawWireCube(touchArea.center, touchArea.size);

    }

    public void StartBullets(int extraBullets)
    {
        bullets = (int)infoWeapon.maxBullets.GetValue(infoWeapon.level);

        if (bullets + extraBullets > BULLETS_LIMIT)
        {
            bullets = BULLETS_LIMIT;
        }
        else
        {
            bullets += extraBullets;
        }

    }

    public void UpdateAmmoUI()
    {
        for (int i = 0; i < AmmoUI.Count; i++)
        {
            if (i + 1 <= bullets)
            {
                AmmoUI[i].gameObject.SetActive(true);

                if (i + 1 > (int)infoWeapon.maxBullets.GetValue(infoWeapon.level))
                {
                    AmmoUI[i].color = extraAmmo;
                }
                else
                {
                    AmmoUI[i].color = myAmmo;
                }

            }
            else
            {
                AmmoUI[i].gameObject.SetActive(false);
            }
        }
    }

    public void GetAmmo(int value)
    {
        if (bullets + value > (int)infoWeapon.maxBullets.GetValue(infoWeapon.level))
        {
            bullets += value;
        }
        else
        {
            bullets = (int)infoWeapon.maxBullets.GetValue(infoWeapon.level);
        }

    }

}

[System.Serializable]
public class Status
{
    public float value;

    public float multiplier = 0.5f;

    public float GetValue(float level)
    {
        return value + level * multiplier;
    }
}
