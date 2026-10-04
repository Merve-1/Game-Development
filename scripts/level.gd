extends Node2D
@onready var start = $Start
@onready var player= $Player
@onready var exit = $Exit
@onready var death_zone = $DeathZone
@export var level_time = 20
@onready var hud = $UILayer/HUD
@export var is_final_level: bool = false
@onready var ui_layer = $UILayer
var time_left
var timer_node = null
var win = false
@export var next_level: PackedScene = null
func _ready():
	player.global_position = start.get_spawn_pos()
	exit.body_entered.connect(_on_exit_body_entered)
	death_zone.body_entered.connect(_on_death_zone_body_entered)
	time_left = level_time
	hud.set_time_label(time_left)
	timer_node = Timer.new()
	timer_node.name = "Level Timer"
	timer_node.wait_time = 1
	timer_node.timeout.connect(_on_Level_timer_timeout)
	add_child(timer_node)
	timer_node.start()
func _on_Level_timer_timeout():
	if win == false:
		time_left -= 1
		hud.set_time_label(time_left)
		print(time_left)
		if time_left <= 0:
			reset_player()
			time_left = level_time
func _process(delta):
	if Input.is_action_just_pressed("quit"):
		get_tree().quit()
	elif Input.is_action_just_pressed("reset"):
		get_tree().reload_current_scene()
func _on_death_zone_body_entered(body: Node2D) -> void:
	reset_player()
func _on_trap_touched_player() -> void:
	reset_player()
func reset_player():
	player.velocity = Vector2.ZERO
	player.global_position = start.get_spawn_pos()
func _on_exit_body_entered(body):
	if body is Player:
		if is_final_level || (next_level != null): 
			exit.animate()
			player.active = false
			win = true
			if is_final_level:
				ui_layer.show_win_screen(true)
			else:
				get_tree().change_scene_to_packed(next_level)
	
