using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AniController : MonoBehaviour
{
    [SerializeField]
    InputAction Movement;
    Animator animator;
    int isWalkingParam;

    float verticalInput = Input.GetAxis("Vertical");

    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingParam = Animator.StringToHash("isWalking");
    }

    private void OnEnable()
    {
 //     Movement.performed
    }

    void Update()
    {
        
   //   if (Movement.IsPressed)
        {
            animator.SetBool("isWalking", true);
        }
        
        float currentSpeed = verticalInput;
    }

    /*
    private Animator animator;
    private ThirdPersonMovement movementScript;

    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private Transform weaponSocket;
    [SerializeField] private bool hasWeapon = false;

    [SerializeField] private float minMoveSpeed = 0.1f;

    private readonly string isWalking = "isWalking";
    private readonly string hasWeaponParam = "hasWeapon";

    private GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (movementScript == null)
            movementScript = GetComponent<ThirdPersonMovement>();

        // Ensure animation state is set to no weapon at start
        animator.SetBool(hasWeaponParam, false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementAnimations();

        // Check for weapon toggle
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleWeapon();
        }
    }

    private void UpdateMovementAnimations()
    {
        // Set walking animation based on movement speed
        if (movementScript != null)
        {
            bool isMoving = movementScript.currentSpeed > minMoveSpeed;
            animator.SetBool(isWalking, isMoving);
        }
    }

    public void ToggleWeapon()
    {
        hasWeapon = !hasWeapon;

        // Update animator parameter
        animator.SetBool(hasWeaponParam, hasWeapon);

        // Instantiate or destroy weapon based on state
        if (hasWeapon)
        {
            EquipWeapon();
        }
        else
        {
            UnequipWeapon();
        }
    }

    private void EquipWeapon()
    {
        // Only create weapon if we have valid references
        if (weaponPrefab != null && weaponSocket != null)
        {
            // Remove existing weapon if any
            UnequipWeapon();

            // Create new weapon at the socket position
            currentWeapon = Instantiate(weaponPrefab, weaponSocket.position, weaponSocket.rotation, weaponSocket);
        }
        else
        {
            Debug.LogWarning("Missing weapon prefab or socket reference");
        }
    }

    private void UnequipWeapon()
    {
        // Destroy the current weapon if it exists
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
            currentWeapon = null;
        }
    }
    */
}
