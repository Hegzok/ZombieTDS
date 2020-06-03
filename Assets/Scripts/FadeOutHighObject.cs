using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutHighObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private float fadeAmount = 0.5f;

    [SerializeField] private Transform player;
    [SerializeField] private float fadeDistance;

    public bool faded = false;

    private void Start()
    {
        player = DataStorage.Player.gameObject.transform;
    }

    private void Update()
    {
        CheckForDistance();
    }


    public void FadeIn()
    {
        if (faded)
        {
            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material.SetFloat("_alphaAmount", 1f);
            }

            faded = false;
        }
    }

    public void FadeOut()
    {
        if (!faded)
        {
            foreach (var meshRenderer in meshRenderers)
            {
                meshRenderer.material.SetFloat("_alphaAmount", fadeAmount);
            }

            faded = true;
        }
    }

    private void CheckForDistance()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, player.position);

        if (distance < fadeDistance)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
    }
}
