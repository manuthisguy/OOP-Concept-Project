using UnityEngine;
using TMPro;

public class ProjectileMovement : Enemy //INHERITANCE: Inherited from Enem class
{
    private Health healhText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healhText = GameObject.Find("HealthText").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            healhText.health -= 5;
            Destroy(gameObject);
        }

    }

    public void MoveProjectile()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 30f);
    }
}
