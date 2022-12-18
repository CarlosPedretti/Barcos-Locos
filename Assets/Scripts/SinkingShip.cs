using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SinkingShip : MonoBehaviour
{

    [SerializeField] public GameObject floater;
    [SerializeField] public GameObject floater1;
    [SerializeField] public GameObject floater2;
    [SerializeField] public GameObject floater3;
    [SerializeField] public GameObject floater4;
    [SerializeField] public GameObject floater5;
    [SerializeField] public GameObject Ship;

    [SerializeField] public TMP_Text Hundido;

    public PosibleBarquito scriptPosibleBarquito;

    public GameObject[] ships;

    void Start()
    {
        ships = GameObject.FindGameObjectsWithTag("Ship");
    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "CannonBall")
        {
            floater.SetActive(true);
            floater1.SetActive(true);
            floater2.SetActive(false);
            floater3.SetActive(false);
            floater4.SetActive(false);
            floater5.SetActive(true);

            Destroy(Ship, 20);

            scriptPosibleBarquito.enabled = false;


        }
    }

    void Update()
    {
        ships = GameObject.FindGameObjectsWithTag("Ship");

        if (ships.Length == 1)
        {
            Hundido.gameObject.SetActive(true);
        }
    }

}
