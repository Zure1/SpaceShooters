using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    AudioSource audSource;
    public AudioClip audioClipMeteorDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        audSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySound(AudioClip soundClip)
    {
        audSource.clip = soundClip;
        audSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound(audioClipMeteorDestroyed);
        var renderer = GetComponent<SpriteRenderer>(); // gets sprite renderer
        renderer.enabled = false;
        var poly = GetComponent<PolygonCollider2D>();
        poly.enabled = false;
        Destroy(gameObject, audioClipMeteorDestroyed.length);
    }
}
