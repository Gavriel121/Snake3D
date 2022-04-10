using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{

    public float MoveSpeed = 10;
    public float SteerSpeed = 180;
    public float BodySpeed = 10;
    public int Gap = 10;

    public GameObject BodyPrefab;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsPlace = new List<Vector3>();

    public AudioSource audioSource;
    public AudioClip Bite;

    // Start is called before the first frame update
    void Start()
    {



    }



    // Update is called once per frame
    void Update()
    {
        //Move Forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //Steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        //body parts placement
        PositionsPlace.Insert(0, transform.position);

        //Body parts movement
        int index = 0;
        foreach(var body in BodyParts)
        {
            Vector3 point = PositionsPlace[Mathf.Min(index * Gap, PositionsPlace.Count - 2)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            audioSource.PlayOneShot(Bite);
            GrowSnake();
          
        }


        if (other.tag == "InvisibleWall")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


}
