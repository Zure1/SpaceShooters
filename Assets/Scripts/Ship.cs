using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float Speed;
    public AudioClip AudioClipShipDestroyed;
    public ParticleSystem ParticleSystemShipDestroyed;
    public Vector3 ShootingDirection;
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

        //var parentGroupController = transform.parent.gameObject.GetComponent<GroupController>();
        //if (parentGroupController != null)
        //{
        //    parentGroupController.ListChildren.Remove(gameObject);
        //}
    }
}
