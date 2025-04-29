class_name PathFollow
extends PathFollow2D

var is_enabled: bool = false
var is_finished: bool = false

@export var speed: float = 0.1
#
#func _process(delta: float) -> void:
	#if not is_finished:
		#if progress_ratio == 1.0:
			#is_finished = true
		#else:
			#if Input.is_action_pressed("ui_accept"):
				#is_enabled = !is_enabled
			#if is_enabled and progress_ratio < 1.0:
				#progress_ratio += delta * speed
