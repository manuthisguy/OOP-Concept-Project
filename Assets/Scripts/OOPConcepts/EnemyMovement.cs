using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;

    public GameObject player;

    public float xBound = 18.5f;
    public float zBound = 8.5f;


    [SerializeField] private Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = player.transform.position - transform.position;

        if (moveDirection.magnitude < 3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            transform.Translate(moveDirection.normalized * Time.deltaTime * enemySpeed);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playCenter = new Vector3(0f, 0f, 0f);
        Vector3 cubeGizmoSize = new Vector3(xBound * 2, 0f, zBound * 2);

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(playCenter, cubeGizmoSize);

        Gizmos.DrawRay(transform.position, moveDirection);

    }
}
