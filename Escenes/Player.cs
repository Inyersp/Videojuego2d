using Godot;
using System;

public class Player : KinematicBody2D
{
	private AnimatedSprite animatedSprite;
	private float moveSpeed = 100f;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _Process(float delta)
	{
		var input = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

		if (input != 0)
		{
			animatedSprite.Play("walk");
			var velocity = new Vector2(input * moveSpeed, 0);
			MoveAndSlide(velocity);
		}
		else
		{
			animatedSprite.Play("idle");
		}

		if (Input.IsActionPressed("ui_up"))
		{
			animatedSprite.Play("jump");
			var velocity = new Vector2(0, -moveSpeed);
			MoveAndSlide(velocity);
		}
	}
}
