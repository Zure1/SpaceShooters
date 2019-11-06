using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float Speed;
    public int HP;
    public AudioClip AudioClipShipDestroyed;
    public ParticleSystem ParticleSystemShipDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - Speed, transform.position.y);
    }

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + Speed, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            HP--;
            if (HP == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        var healthScript = GetComponent<HealthScript>();
        if (healthScript?.CurrentHealth != 0)
        {
            return;
        }
        GameObject gameObj = new GameObject();
        gameObj.AddComponent<GameObjectAutoDestroy>();

        var audioSource = gameObj.AddComponent<AudioSource>();
        audioSource.clip = AudioClipShipDestroyed;
        audioSource.Play();
        Instantiate(ParticleSystemShipDestroyed, transform.position, Quaternion.identity);
    }
}
