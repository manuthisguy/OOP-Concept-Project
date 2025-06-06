using UnityEngine;

public class RedEnemy : Enemy //INHERITANCE: Inherited from Enemy class
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ABSTRACTION
        GetPlayer();
        SetSpeed(5f);

        InvokeRepeating("Shoot", 2f, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        //ABSTRACTION
        MoveTowardsPlayer();
        CheckBounds();   
    }

    //POLYMOPHISM
    public override void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
