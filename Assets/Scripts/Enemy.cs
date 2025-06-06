using UnityEngine;

public class Enemy : MonoBehaviour
{
    //ENCAPSULATION
    private float enemySpeed { get; set; }
    
    private GameObject player { get; set; }

    public GameObject GetPlayer()
    {
        player = GameObject.Find("Player");
        return player;
    }

    public float SetSpeed(float speed)
    {
        enemySpeed = speed;
        return enemySpeed;
    }

    private float xBound = 18.5f;
    private float zBound = 8.5f;

    private Vector3 moveDirection;

    public GameObject projectile;
    public float shootTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        CheckBounds();
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playCenter = new Vector3(0f, 0f, 0f);
        Vector3 cubeGizmoSize = new Vector3(xBound * 2, 0f, zBound * 2);

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(playCenter, cubeGizmoSize);

        Gizmos.DrawRay(transform.position, moveDirection);

    }

    public void MoveTowardsPlayer()
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

            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }

    public void CheckBounds()
    {
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

    //POLYMOPHISM
    public virtual void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }




}
