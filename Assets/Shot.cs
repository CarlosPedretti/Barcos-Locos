using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject Ship;
    public GameObject bullet;
    public Transform spawnPoint;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    public int Municiones = 0;

    private float shotRateTime = 0;




    public void OnTriggerEnter(Collider collision)
    {

         if (collision.gameObject.tag == "Ammo")
         {
            Destroy(collision.gameObject);
            Municiones = Municiones + 1;
         }
    }   


    void Update()
    {
         if (Municiones >= 1)
         {
            if (Input.GetKeyDown("space"))
            {
                Municiones = Municiones - 1;
                if (Time.time > shotRateTime)
                {
                    GameObject newBullet;

                    newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                    newBullet = Instantiate(bullet, spawnPoint1.position, spawnPoint1.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint1.forward * shotForce);

                    newBullet = Instantiate(bullet, spawnPoint2.position, spawnPoint2.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint2.forward * shotForce);

                    newBullet = Instantiate(bullet, spawnPoint3.position, spawnPoint3.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint3.forward * shotForce);

                    shotRateTime = Time.time + shotRate;

                    Destroy(newBullet, 1);
                }
            }

         }
    }
}