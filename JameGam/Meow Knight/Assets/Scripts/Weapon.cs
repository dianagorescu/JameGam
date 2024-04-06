using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firingPoint;
    public GameObject bulletPrefab;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //pew pew logic
        animator.SetBool("IsAttacking", true);
        Invoke("CreateBullet", 0.25f);
    }
    void CreateBullet()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        animator.SetBool("IsAttacking", false);

    }
}
