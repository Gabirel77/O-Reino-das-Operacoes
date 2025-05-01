class_name AutoBoardPlayer
extends CharacterBody2D

@onready var path_follow: PathFollow2D = $".."

var is_running: bool

@export var speed: float = 0.1

func _ready() -> void:
	is_running = true
	return

func _process(delta: float) -> void:
	if is_running and path_follow.progress_ratio < 1.0:
		path_follow.progress_ratio += delta * speed
	return
