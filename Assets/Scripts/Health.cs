using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;

        if(health <= 0)
        {
            health = 0;
        }
    }
}
