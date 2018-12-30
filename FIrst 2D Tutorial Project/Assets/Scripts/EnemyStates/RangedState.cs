﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState {

	private Enemy enemy;

	// Throwing knife throwCooldown
	private float throwTimer;
	private float throwCooldown = 3;
	private bool canThrow;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}

	public void Execute()
	{
		// If we have a target then
		if (enemy.Target != null)
		{
			enemy.Move();
		}
		// If no longer have target then go back to Idle
		else
		{
			enemy.ChangeState(new IdleState());
		}

		ThrowKnife();

	}

	public void Exit()
	{

	}

	public void OnTriggerEnter(Collider2D other)
	{

	}

	private void ThrowKnife()
	{
		throwTimer += Time.deltaTime;
		if (throwTimer >= throwCooldown)
		{
			canThrow = true;
			throwTimer = 0;
		}

		if (canThrow)
		{
			canThrow = false;
			enemy.MyAnimator.SetTrigger("throw");
		}

	}

}
