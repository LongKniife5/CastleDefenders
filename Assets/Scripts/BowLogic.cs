﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BowLogic : MonoBehaviour {

	[SerializeField] Rigidbody2D ProjectilePrefab;
    [SerializeField] Animator animator;

	private float startTime = 0f;

	public float bowDrawSpeed;
    public int arrowSpeed;

	private bool canShoot = true;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
		startTime = 0f;
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

			if(animator.GetCurrentAnimatorClipInfo(0).Length == .75f)
				projectile.velocity = transform.TransformDirection(Vector3.right * arrowSpeed);


			if(animator.GetCurrentAnimatorClipInfo(0).Length == 1)
				projectile.velocity = transform.TransformDirection(Vector3.right * arrowSpeed/2);
		}

        if (Input.GetMouseButton(0) && canShoot == true)
        {
            animator.SetBool("isCharging", true);
			
			Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);
        }

	}
	
	IEnumerator ShootingCountdown()
	{
		canShoot = false;
		yield return new WaitForSeconds(bowDrawSpeed);
		canShoot = true;
	}
}

