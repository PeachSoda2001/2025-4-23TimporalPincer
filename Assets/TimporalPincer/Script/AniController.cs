using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AniController : MonoBehaviour
{
    [SerializeField] InputAction Movement;
    Animator animator;

    int isWalkingParam;
    public bool isWalkingbool;
    
    int hasWeaponParam;
    public bool hasWeaponbool;
    
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform weaponSocket;
    private GameObject currentWeapon;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingParam = Animator.StringToHash("isWalking");
        hasWeaponParam = Animator.StringToHash("hasWeapon");
    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
            isWalkingbool = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
            isWalkingbool = false;
        }

        //f for weapon toggle
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleWeapon();
        }
    }

    void ToggleWeapon()
    {
        hasWeaponbool = !hasWeaponbool;
        animator.SetBool("hasWeapon", hasWeaponbool);

        if (hasWeaponbool)
        {
            SpawnWeapon();
        }
        else
        {
            DespawnWeapon();
        }
    }

    void SpawnWeapon()
    {
        // spawn weapon
        currentWeapon = Instantiate(weaponPrefab, weaponSocket);
        // Position and rotate relative to socket
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
    }

    void DespawnWeapon()
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
            currentWeapon = null;
        }
    }
}