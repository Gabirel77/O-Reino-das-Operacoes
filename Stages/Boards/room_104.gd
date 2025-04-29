class_name Room104
extends Area2D

func _on_area_exited(area: Area2D) -> void:
	if area is BoardPlayerTest:
		printt("Player saiu! UFA!!!", "Descansarei em paz")
		queue_free()
