class_name BoardPlayerPrototype
extends Area2D

@onready var path_follow: PathFollow2D = $".."
@onready var walking_delay: Timer = $WalkingDelay

@export var speed: float = 0.1

func _ready() -> void:
	path_follow = self.get_parent()
	return

func _process(delta: float) -> void:
	path_follow.progress_ratio += speed * delta
	return
