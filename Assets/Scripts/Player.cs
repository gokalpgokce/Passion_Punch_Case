using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    private float bulletSpeed = 1000f;
    public CharacterController _controller;
    private float playerSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            _controller.Move(direction * playerSpeed * Time.deltaTime);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tempBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        }
    }
}
