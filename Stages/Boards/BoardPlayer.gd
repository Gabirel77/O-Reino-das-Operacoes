class_name BoardPlayerTest
extends Area2D

@onready var path_follow: PathFollow = $".."
@onready var walking_delay: Timer = $WalkingDelay

var is_running: bool
var is_enabled: bool
var is_finished: bool

@export var speed: float = 0.1

func _ready() -> void:
	is_running = false
	is_enabled = false
	is_finished = false

func _process(delta: float) -> void:
	if not is_finished:
		if path_follow.progress_ratio == 1.0:
			is_finished = true
		else:
			if not is_running and Input.is_action_just_pressed("ui_accept"):
				is_enabled = not is_enabled
				is_running = true
				walking_delay.start()
				print("Pressionado")
			if is_enabled and path_follow.progress_ratio < 1.0:
				path_follow.progress_ratio += delta * speed

func _on_timer_timeout() -> void:
	is_running = false
