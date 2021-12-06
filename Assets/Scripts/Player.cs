using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    private float bulletSpeed = 1000f;
    public CharacterController controller;
    private float playerSpeed = 10f;
    
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }
    
    void Fire()
    {
        GameObject tempBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        controller.Move(direction * playerSpeed * Time.deltaTime);
    }
}
