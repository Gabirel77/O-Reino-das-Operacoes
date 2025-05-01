class_name PointAndClickBoardPlayer
extends CharacterBody2D

@export var speed: float = 300.0

var follow_direction: Vector2

func _ready() -> void:
	self.follow_direction = self.global_position
	return

func _input(event: InputEvent) -> void:
	if event.is_action_pressed("left_click"):
		follow_direction = get_global_mouse_position()
	return

func _process(delta: float) -> void:
	self.velocity = (follow_direction - self.global_position).clamp(Vector2(-speed, -speed), Vector2(speed, speed))
	move_and_slide()
	return
