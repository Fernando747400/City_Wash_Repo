using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCleaner : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private LayerMask _dirtyMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SendRay();
        }
    }

    private void SendRay()
    {
        RaycastHit hit;
        InteractiveDirt interactDirt;
        if (Physics.Raycast(this.transform.position, -this.transform.up,out hit,2f,_dirtyMask.value) && hit.collider != null)
        {
            interactDirt = hit.collider.gameObject.GetComponent<InteractiveDirt>();
            if (!interactDirt.cleaned)
            {
                interactDirt.CleanDirt(hit.point);
            }
        }
    }


}
