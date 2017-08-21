﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleStoreLogic : MonoBehaviour
{
	[SerializeField] int CastleArmorCost;
	[SerializeField] int UpgradeBowDamageCost;
	[SerializeField] int UpgradeBowFireRateCost;


	[SerializeField] GameObject Bow;

	[SerializeField] Text CastleArmorCostText;
	[SerializeField] Text UpgradeBowDamageCostText;
	[SerializeField] Text UpgradeBowFireRateCostText;

	private void Start()
	{
		CastleArmorCostText.text = "Upgrade Castle: " + CastleArmorCost + " Gold";
		UpgradeBowDamageCostText.text = "Upgrade Bow Damage: " + UpgradeBowDamageCost + " Gold";
		UpgradeBowFireRateCostText.text = "Upgrade Bow FireRate: " + UpgradeBowFireRateCost + " Gold";
	}

	public void UpgradeCastleArmor()
	{
		if (GetComponent<GameLogic>().currency >= CastleArmorCost)
		{
			GetComponent<GameLogic>().currency -= CastleArmorCost;
			GetComponent<GameLogic>().castleArmour += 1;
		}
	}

	public void UpgradeBowDamage()
	{
		if (GetComponent<GameLogic>().currency >= UpgradeBowDamageCost)
		{
			GetComponent<GameLogic>().currency -= UpgradeBowDamageCost;
			Bow.GetComponent<BowLogic>().damage += 25;
		}
	}

	public void UpgradeBowFireRate()
	{
		if (GetComponent<GameLogic>().currency >= UpgradeBowFireRateCost)
		{
			GetComponent<GameLogic>().currency -= UpgradeBowFireRateCost;
			Bow.GetComponent<BowLogic>().bowDrawSpeed -= .25f;
		}
	}


}