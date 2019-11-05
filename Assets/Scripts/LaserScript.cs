using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    Vector2 screenBounds;
    Vector3 laserDirection = Vector3.up;
    Vector3 movePosition;
    float laserHeight;
    float laserSpeed = 0.10f;
    AudioSource audSource;

    [SerializeField]
    AudioClip audioClipLaserShot;

    public ParticleSystem LaserHitExplosion;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        laserHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        movePosition = new Vector3(transform.position.x, screenBounds.y + laserHeight);
        audSource = GetComponent<AudioSource>();
        PlaySound(audioClipLaserShot);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, movePosition, laserSpeed);
        transform.position = newPos;

        if (transform.position == movePosition)
        {
            Destroy(gameObject);
        }
    }

    void PlaySound(AudioClip soundClip)
    {
        audSource.clip = soundClip;
        audSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(LaserHitExplosion, transform.position, Quaternion.identity);

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
