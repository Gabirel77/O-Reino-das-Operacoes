class_name FightPlayer
extends Node2D

enum ANIMATIONS {
	idle,
	charge_attack,
	guard,
	kick_attack
}

### Nome das animações disponíveis no SpriteSheet e AnimationPlayer
const ANIMATIONS_NAME: Array[String] = [
	"idle",
	"charge_attack",
	"guard",
	"kick_attack"
]

@export var current_animation: ANIMATIONS
@export_range(0, 4, 0.1, "Velocidade da Animação") var animation_speed: float

@onready var animation_player: AnimationPlayer = $AnimationPlayer

func _ready() -> void:
	print(ANIMATIONS_NAME[current_animation])
	animation_player.play(ANIMATIONS_NAME[current_animation])
	animation_player.speed_scale = animation_speed
	return
