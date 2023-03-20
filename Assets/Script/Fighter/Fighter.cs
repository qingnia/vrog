using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public BaseAttribute baseAttribute;

    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    void Awake()
    {
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }
    void Start()
    {
        if (DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);

        if (IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);
    }

    public void Dead()
    {
        Debug.LogFormat("fighter dead, {0}", name);
        gameObject.SetActive(false);
        //计分
    }
    public void Damaged(int add)
    {
        baseAttribute.AddBlood(add);
        if (HitPlayer != null)
            HitPlayer.PlayRandom();

        Vector3 position = transform.position;

        //the audiosource of the target will get destroyed, so we need to grab a world one and play the clip through it
        if (HitPlayer != null)
        {
            var source = WorldAudioPool.GetWorldSFXSource();
            source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }

        if (DestroyedEffect != null)
        {
            var effect = PoolSystem.Instance.GetInstance<ParticleSystem>(DestroyedEffect);
            effect.time = 0.0f;
            effect.Play();
            effect.transform.position = position;
        }

        if (baseAttribute.curHealth <= 0)
        {
            Dead();
        }
    }
}
