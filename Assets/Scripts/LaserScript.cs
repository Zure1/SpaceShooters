using UnityEngine;

public class LaserScript : MonoBehaviour
{
    Vector2 screenBounds;
    public Vector3 LaserDirection;
    Vector3 movePosition;
    float laserHeight;
    float laserSpeed = 0.03f;
    float damageAmount = 1f;
    AudioSource audSource;

    public AudioClip audioClipLaserShot;
    public ParticleSystem LaserHitExplosion;
    public bool IsHostile;

    public void SetLaserDirection(Vector3 direction)
    {
        LaserDirection = direction;
        
    }

    void SetMovePosition()
    {
        if (LaserDirection == Vector3.up)
        {
            movePosition = new Vector3(transform.position.x, screenBounds.y + laserHeight);
        }
        else if (LaserDirection == Vector3.down)
        {
            movePosition = new Vector3(transform.position.x, -screenBounds.y - laserHeight);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        laserHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        SetMovePosition();

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
        if (IsHostile && collision.gameObject.tag == "HostileShip")
        {
            return;
        }
        Instantiate(LaserHitExplosion, transform.position, Quaternion.identity);

        var healthScript = collision.gameObject.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.TakenDamage(damageAmount);
        }
        Destroy(gameObject);
    }
}
