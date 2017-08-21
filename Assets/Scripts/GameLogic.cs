﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

	#region Variables
	private int castleMaxHealth = 100;
	public float castleHealth;
	public int currency = 100;
	private int waveReward;
	public int waveNumber;
	public int castleArmour = 5;
    public bool Dead = false;
	#endregion

	#region GameObjectReferences
	[SerializeField] private Text waveNumberText;
	[SerializeField] private Text currencyText;
	[SerializeField] private RectTransform castleHealthFill;
	#endregion

	private void Awake()
	{
		castleHealth = castleMaxHealth;
	}

	private void Update()
	{
		castleHealth = Mathf.Clamp(castleHealth, 0f, castleMaxHealth);

		if (castleHealth<=0 && Dead == false)
		{
			die(waveNumber);
		}

		SetCastleHealthFill(castleHealth/castleMaxHealth);

		currencyText.text = "Gold: " + currency.ToString();

		waveNumberText.text = "Wave: " + waveNumber.ToString();
	}

	private void SetCastleHealthFill(float _amount)
	{
		castleHealthFill.localScale = new Vector3(_amount, 1f);
	}

	public void castleTakeDamage(int damage)
	{
		castleHealth -= (damage - castleArmour);
	}

	private void die(int _waveNumber)
	{
        Dead = true;
		Debug.Log("Died on wave " + _waveNumber);
	}
}
