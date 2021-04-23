
| Josiah Hartley|
| :---          	|
| s208046     	|
| Computer Programming |
| Cross Platform Assessment |

## I. Requirements

1. Description of Problem

	- **Name**: Computer Programming Project

	- **Problem Statement**: 
	For this assessment you are required to create a game using either Unity 3D or Unreal Engine 4 and build it for multiple platforms.

	- **Problem Specifications**:  
    You are to create a document that states the target deployment hardware and outlines proposed solutions for cross-platform development issues that may arise. This assessment also 
    includes requirements for a pre-implementation planning document, internal code documentation, and a 5-8 minute progress presentation delivered mid-way through the project.  


2. Input Information
- Mouse Left Click - Presses Buttons
- Hover Mouse Cursor - Direct Player



1.  Output Information
- Player is a rectangular skatboard like model that hovers towards the mouse location
- There is a pause button located in the upper left corner and a kill count in the upper right
   

## II. Design

 _System Architecture_

Main Game Flow
The Player Spawns -> Enemies Spawn Routinely -> <-Player Kills Enemies


### Object Information

   **File**: GameUIManager.cs

     
  **Attributes**

        Name: Score
             Description: Displays total number of enemies killed by the player
             Type: Text
        Name: _score
             Description: Contains the information of how many enemies the player has killed
             Type: float
        Name: _pause
             Description: Contains the information of whether or not the game has been paused
             Type: bool
        Name: IncrementScore()
             Description: Adds a single value point to _score
             Type: void
        Name: DecrementScore()
             Description: Removes a single value point from _score
             Type: void
        Name: Pause()
             Description: Toggles the bool _pause, then sets the time scale to either 0 or 1 depending on the bool _pause
             Type: void
        Name: Update()
             Description: Updates the kill count
             Type: void

**File**: LookAt.cs

     
  **Attributes**

        Name: _gameObject
             Description: A selectable gameObject to set this Forward to face
             Type: GameObject
        Name: Update()
             Description: Updates this gameObjects forward to face toward _gameObject
             Type: void

**File**: FollowPlayer.cs

     
  **Attributes**

        Name: _player
             Description: A reference to the gameObject of player
             Type: GameObject
        Name: _distance
             Description: The distance vector that the camera will maintain from the player ignoring the y - axis which is static
             Type: Vector3
        Name: Start()
             Description: Sets the _player reference to be the [should be] only GameObject with the tag "Player"
             Type: void
        Name: Update()
             Description: Sets the position of this agent to be (x units away, y units high, z units away)
             Type: void

**File**: DieInTaggedZone.cs

     
  **Attributes**

        Name: Tag
             Description: Allows for the programmer to easily set what Tagged gameObjects this agent will die in
             Type: string
        Name: GameManager
             Description: A reference to the game manager to keep up with the death count
             Type: GameObject
        Name: _gameUIManager
             Description: Contains a reference to the code within the game manager to keep up with the death count
             Type: GameUIManager.cs
        Name: _counted()
             Description: Bool that is toggled when this unit dies and adds a value to the _score in the gameManager to prevent bug where multiple points were added instead of one
             Type: bool
        Name: Start()
             Description: Initializes the GameManager to be the [should be] only GameObject with the tag "GameManager" and _gameUIManager to be the GameUIManager component of GameManager
             Type: void
        Name: Destroy()
             Description: Deletes this instance of gameObject since it "died" in the "tagged" zone
             Type: void
        Name: OnTriggerEnter(Collider other)
             Description: checks to see if other is the Tag that this agent should die in, if it is, set counted to true, count a point, and delete this agent
             Type: void

**File**: ChaseBehavior.cs

     
  **Attributes**

        Name: _target
             Description: A reference to the game object that this agent will be path seeking towards
             Type: GameObject
        Name: _agent
             Description: A reference to the path seeking component of this agent
             Type: NavMeshAgent
        Name: _rigidBody
             Description: A reference to the rigid body component of this agent
             Type: RigidBody
        Name: Start()
             Description: Initializes _rigidBody, _agent, and if no Target was set, _target is set to seek Player
             Type: void
        Name: Update()
             Description: If there is a target, seek a path towards the targets position
             Type: void

**File**: Spawner.cs

     
  **Attributes**

        Name: spawnThis
             Description: A reference to the game object [prefab] that this agent will be creating instances of
             Type: GameObject
        Name: spawnBuffer
             Description: The seconds inbetween each initialization of spawnThis
             Type: float
        Name: GameOver
             Description: The Toggle Variable for whether the spawners should spawn [currently static]
             Type: bool
        Name: Start()
             Description: Initializes a courotine of SpawnEnemies
             Type: void
        Name: SpawnEnemies()
             Description: While the game is not over, initialize a spawnThis at the location of this agent after spawnBuffer seconds of ingame time dalation
             Type: IEnumerator

**File**: Roll.cs

     
  **Attributes**

        Name: Update
             Description: Rotates counter clockwise on the forward rotation of this agent
             Type: void

**File**: PlayerMovements.cs

     
  **Attributes**

        Name: _moveSpeed
             Description: The movement speed of the player
             Type: float
        Name: _camera
             Description: A reference to the main camera used for raycasting [player movement]
             Type: Camera
        Name: _rigidbody
             Description: A reference to this agents rigid body
             Type: RigidBody
        Name: Start()
             Description: Initializes the _rigidbody
             Type: void
        Name: FixedUpdate()
             Description: Creates a invisible ray starting from the camera to the mouse for the player to move towards, 
             Type: void

**File**: KillTaggedInZone.cs

     
  **Attributes**

        Name: TagName
             Description: The tag of the gameObjects that we want to destroy in _boxCollider
             Type: string
        Name: _boxCollider
             Description: A reference to the box Collider component that will act as a kill zone
             Type: BoxCollider
        Name: onTriggerEnter(collider other)
             Description: Checks to see if other is a tagged game object that we want to destroy, if it is, call that objects DieInTaggedZone function
             Type: void