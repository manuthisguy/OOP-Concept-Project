using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float xRange = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * moveX);


        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }
}
