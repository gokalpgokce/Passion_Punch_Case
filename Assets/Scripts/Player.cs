using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    private float bulletSpeed = 1000f;
    public CharacterController controller;
    private float playerSpeed = 10f;
    private float totalBulletCount;
    public TextMeshProUGUI totalCountText;
    
    void Update()
    {
        
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            for (int i = 0; i < Random.Range(3,8); i++)
            {
                Fire();
            }
        }
    }
    
    void Fire()
    {
        GameObject tempBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.09f,+0.08f),Random.Range(-0.09f,+0.08f),1) * bulletSpeed);
        totalBulletCount++;
        totalCountText.text = totalBulletCount.ToString();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        controller.Move(direction * playerSpeed * Time.deltaTime);
    }
}
