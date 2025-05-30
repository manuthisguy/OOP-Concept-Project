using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;

    public float zBound = 8.5f;
    public float xBound = 18.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy detected!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playCenter = new Vector3(0f, 0f, 0f);
        Vector3 cubeGizmoSize = new Vector3(xBound * 2, 0f, zBound * 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playCenter, cubeGizmoSize);
    }
}
