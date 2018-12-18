using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem Main;
    public ParticleSystem[] Ring;
    public SparkParticles Sparks;
    public ParticleSystem Flash;
    public ParticleSystem[] Debris;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

    public void Play()
    {
        Main.Play();
        for (int i = 0; i < Ring.Length; i++)
            Ring[i].Play();
        Sparks.Play();
        Flash.Play();
        for (int i = 0; i < Debris.Length; i++)
            Debris[i].Play();
    }
}

