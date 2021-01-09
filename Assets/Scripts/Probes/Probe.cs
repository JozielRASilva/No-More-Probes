using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probe : MonoBehaviour
{

    public int life;
    public int maxLife = 2;

    [Range(1, 10)]
    public float pointsMultiplier = 1;

    [Range(0, 3)]
    public int shield;

    [Range(0.5f, 10)]
    public float speed;

    public List<GameObject> shields;

    public MoveStructure moveStructure;

    public Text getPoints;

    public ParticleSystem Hit;
    public ParticleSystem Explosion;

    private Animator animator;

    public string dieState = "Probe_Die";

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int value, Bullet other)
    {

        if (shield > 0)
        {
            shield--;
        }
        else
        {
            if(life - value > 0)
            {
                life -= value;
                Hit.Play();
            }
            else
            {
                life -= value;

                Die(other);
            }

        }


        other.gun.GetAmmo(1);

    }

    public void Die(Bullet other)
    {

        int point = (int)((float)CheckGainPoints(other.gameObject.transform) * pointsMultiplier);

        getPoints.text = $"+ {point}";

        //PlayerInfo.AddPoints(point);

        animator.Play(dieState);

    }

    public void Finish()
    {
        gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Bullet"))
        {
            if (IsAlive())
            {
                Bullet bullet = collision.GetComponent<Bullet>();

                TakeDamage((int)bullet.damage, bullet);

                bullet.Broke();
            }
        }
    }

    public bool IsAlive()
    {
        if(life > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CheckGainPoints(Transform other)
    {

        int finalPoints = (int)(2 / (Mathf.Abs(other.position.x - transform.position.x) + 0.5f) + 1);

        getPoints.text = "+" + finalPoints;

        return finalPoints;
    }


    public void PlayExplosion()
    {
        Explosion.Play();
    }

}
