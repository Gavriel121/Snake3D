using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMechanics : MonoBehaviour
{
    public GameObject apple;

    public Transform[] spawnPoints;

    public GameObject SpawnEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Head")
        {
            Destroy(gameObject);
            Spawn();
            Instantiate(SpawnEffect, transform.position, SpawnEffect.transform.rotation);
        }

        void Spawn()
        {
            int spawnPointX = Random.Range(-10, 10);
            int spawnPointZ = Random.Range(-10, 10);
            int spawnPointY = Random.Range(1, 1);

            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
            Instantiate(apple, spawnPosition, Quaternion.identity);
        }


    }


}
