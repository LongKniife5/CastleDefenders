﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowLogic : MonoBehaviour {

	[SerializeField] Rigidbody2D ProjectilePrefab;
    [SerializeField] Animator animator;

	public float bowDrawSpeed;
    public int arrowSpeed;

	private bool canShoot = true;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (Input.GetMouseButtonUp(0) && canShoot == true)
		{
            animator.SetBool("isCharging", false);

			StartCoroutine(ShootingCountdown());

			Rigidbody2D projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z));

			projectile.name = "Arrow";

			projectile.velocity = transform.TransformDirection(Vector3.right * arrowSpeed);
		}

        if (Input.GetMouseButton(0) && canShoot == true)
        {
            animator.SetBool("isCharging", true);
        }

	}
	
	IEnumerator ShootingCountdown()
	{
		canShoot = false;
		yield return new WaitForSeconds(bowDrawSpeed);
		canShoot = true;
	}
}

