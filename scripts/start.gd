extends StaticBody2D
@onready var span_pos = $SpawnPosition
func get_spawn_pos():
	return span_pos.global_position
