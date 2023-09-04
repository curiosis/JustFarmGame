using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("ONE")]
    [SerializeField]
    private float interactDistance;
    [SerializeField]
    private LayerMask interactableLayer;
    [SerializeField]
    private float raycastInterval = 0.1f; // => 10 TIMES by 1s

    private InteractableObject currentInteractable = null;
    private InteractableObject tempInteract = null;
    private float tempRaycastInterval = 0.0f;

    [Header("TWO")]
    [SerializeField]
    private TextMeshProUGUI interactObjectName;
    [SerializeField]
    private TextMeshProUGUI interactObjectDesc;
    [SerializeField]
    private Sprite interactObjectIcon;
    [SerializeField]
    private GameObject interactObject;

    private void Update()
    {
        if (tempRaycastInterval < raycastInterval)
        {
            tempRaycastInterval += Time.deltaTime;
        }
        else
        {
            tempRaycastInterval = 0.0f;
            tempInteract = CastRay();
            if (tempInteract != null)
            {
                if (tempInteract != currentInteractable)
                {
                    currentInteractable = tempInteract;
                    SetInteractHUD(currentInteractable.HUD_POS, currentInteractable.NAME, currentInteractable.DESCRIPTION, currentInteractable.ICON);
                }
                CallCurrentInteract();
            } else
            {
                RemoveInteractHUD();
                if (currentInteractable)
                    currentInteractable.ResetMaterial();
                currentInteractable = null;
            }
        }
    }

    public Transform cameraTransform;
    public Transform headTransform;

    private InteractableObject CastRay()
    {
        cameraTransform = Camera.main.transform;
        Vector3 direction = headTransform.position - cameraTransform.position;
        Vector3 dir = new( headTransform.position.x, (headTransform.position - cameraTransform.position).y , headTransform.position.z);
        dir.Normalize();

        Debug.DrawRay(headTransform.position, dir * interactDistance, Color.red);

        if (Physics.Raycast(headTransform.position, direction * InteractDistance, out RaycastHit hit, InteractableLayer))
        {
            InteractableObject interactable = hit.collider.gameObject.GetComponent<InteractableObject>();

            if (interactable == null)
                return null;
            else
                return interactable;
        }
        return null;
    }

    public void SetInteractHUD(Transform HUD_POS, string name, string desc, Sprite icon)
    {
        interactObjectName.text = name;
        interactObjectDesc.text = desc;
        interactObjectIcon = icon;

        //interactObject.transform.position = HUD_POS.position;
        interactObject.SetActive(true);
    }

    public void RemoveInteractHUD()
    {
        interactObject.SetActive(false);

        interactObjectName.text = string.Empty;
        interactObjectDesc.text = string.Empty;
        interactObjectIcon = null;
    }

    public void CallCurrentInteract()
    {
        currentInteractable.Interact();
    }

    public float InteractDistance
    {
        get => interactDistance;
    }

    public LayerMask InteractableLayer
    {
        get => interactableLayer;
    }

    public InteractableObject CurrentInteractable
    {
        get => currentInteractable;
    }
}
