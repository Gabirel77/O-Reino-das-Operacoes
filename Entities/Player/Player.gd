class_name Player
extends Node2D

const MAX_SPEED: int = 300

func _process(delta: float) -> void:
	# Movimentação simples, para testes
	var direction: Vector2 = Vector2.ZERO
	if (Input.is_action_pressed("ui_right")):
		direction.x += 1
	if (Input.is_action_pressed("ui_left")):
		direction.x -= 1
	if (Input.is_action_pressed("ui_down")):
		direction.y += 1
	if (Input.is_action_pressed("ui_up")):
		direction.y -= 1
	
	if (direction.length() > 0):
		self.global_position.x += direction.normalized().x * MAX_SPEED * delta
		self.global_position.y += direction.normalized().y * MAX_SPEED * delta
	
	return
