using UnityEngine;

public class LevelCompleteParticleSystemController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ParticleSystem _burstParticleSystem;
    [SerializeField] private ParticleSystem _loopParticleSystem;

    public void StartBurstParticleSystem()
    {
        _burstParticleSystem.Play();
    }

    public void StartLoopParticleSystem()
    {
        _loopParticleSystem.Play();
    }

    public void ResetParticleSystems()
    {
        _burstParticleSystem.Stop();
        _loopParticleSystem.Stop();
    }
}
