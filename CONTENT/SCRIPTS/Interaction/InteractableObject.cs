using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteract
{
    public string NAME;
    public string DESCRIPTION;
    public Sprite ICON;
    public Transform HUD_POS;
    public Material InteractMaterial;

    public Material startMaterial;
    public MeshRenderer meshRenderer;

    public void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        startMaterial = meshRenderer.material;
    }

    public virtual void Interact()
    {
        if (meshRenderer && InteractMaterial)
            meshRenderer.material = InteractMaterial;
        Debug.Log($"INTERACTION: {NAME}, DESC: {DESCRIPTION}, HAS ICON? -> {ICON == true}");
    }

    public void ResetMaterial()
    {
        meshRenderer.material = startMaterial;
    }
}
