using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakenDamage(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0f, MaxHealth);
        if (CurrentHealth == 0f)
        {
            Destroy(gameObject);
        }
    }
}
