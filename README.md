# CS410-assignment-2

CS410: Game Programming Assignment 2 | John Lemon's Haunted Jaunt Extended

## Setup

- All assests from the John Lemon's Haunted Jaunt Package are located in `/Assets/UnityTechnologies/3DBeginnerComplete`
- Populate the scence by dragging and dropping `Assets/UnityTechnologies/3DBeginnerComplete/Scenes/MainScence` into the Unity Editor Hierarchy

## Work Distribution

### Ryan Jacques

- Created repository and built initial project
- Created particle system (Ghost poop). Players can interact with particles, and position is updated via the `ParticleModifier.cs` script.

### Joseph Erlinger

Added **sprint feature** to `PlayerMovement.cs` that uses **interpolation** to smoothly transition from walking speed to running speed. To sprint, the player can press the shift button while moving using the WASD keys. 

In `PlayerMovement.cs`
- Created `Lerp()`.
- Created `walkLerpUpdate()`.
- Modified `FixedUpdate` to detect presses to the shift button.
- Modified `OnAnimatorMove` to increase speed of player when sprinting.

### Jerin Spencer
- added "Thud Machine"
    - picture of obama
    - trigger that makes obama visible and plays "vine boom" when something moves through it
