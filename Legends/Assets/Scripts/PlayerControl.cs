using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private Collider[] weapons;

    private CharacterController characterController;
    private Vector3 targetPosition;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        ToggleWeapons(false);
        characterController = GetComponent<CharacterController>();
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void BeginAttack()
    {
        ToggleWeapons(true);
    }

    public void EndAttack()
    {
        ToggleWeapons(false);
    }

    private void ToggleWeapons(bool enable)
    {
        foreach (Collider weapon in weapons)
        {
            weapon.enabled = enable;
        }
    }
    
    void Update()
    {
        float distToTarget = Vector3.Distance(targetPosition, transform.position);
        if (distToTarget > 0.5f && PlayerHealth.isAlive)
        {
            Vector3 direction = Vector3.Normalize(targetPosition - transform.position);
            characterController.Move(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        if (Input.GetMouseButton(0) && PlayerHealth.isAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, layerMask))
            {
                targetPosition = hit.point;
                transform.LookAt(targetPosition);
            }
        }

        if (Input.GetMouseButton(1) && PlayerHealth.isAlive)
        {
            animator.SetTrigger(("stab"));
        }
    }
}
