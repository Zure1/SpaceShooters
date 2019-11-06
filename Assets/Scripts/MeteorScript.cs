using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public AudioClip AudioClipMeteorDestroyed;
    public ParticleSystem MeteorParticleExplosion;
    public bool IsStartGame;

    private void OnDestroy()
    {
        var healthScript = GetComponent<HealthScript>();
        if (healthScript?.CurrentHealth != 0)
        {
            return;
        }
        GameObject gameObj = new GameObject();
        gameObj.AddComponent<GameObjectAutoDestroy>();
        if (IsStartGame)
        {
            gameObj.AddComponent<StartGameOnDestroy>();
        }

        var audioSource = gameObj.AddComponent<AudioSource>();
        audioSource.clip = AudioClipMeteorDestroyed;
        audioSource.Play();
        Instantiate(MeteorParticleExplosion, transform.position, Quaternion.identity);
    }
}
