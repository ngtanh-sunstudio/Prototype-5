# Prototype 5

A target-slicing game completed during the Unity Junior Programmer pathway.

## What I Learned

### [Lesson 5.1 - Clicky Mouse](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-1-clicky-mouse-1?version=6.3)

**New functionality**

- **Random objects are tossed into the air on intervals:** [GameManager](Assets/Scripts/GameManager.cs) repeatedly spawns a random target.
- **Objects are given random speed, position, and torque:** [Target](Assets/Scripts/Target.cs) applies randomized upward force, spawn position, and rotation.
- If you click on an object, it is destroyed.

**New concepts & skills**

- 2D View.
- **`AddTorque`:** applies rotational force to each target's Rigidbody in [Target](Assets/Scripts/Target.cs).
- **Game Manager:** a central [GameManager](Assets/Scripts/GameManager.cs) coordinates spawning, scoring, lives, and game state.
- **Lists:** the target prefabs are stored in a `List<GameObject>` in [GameManager](Assets/Scripts/GameManager.cs).
- While loops.
- **Mouse events:** [Blade](Assets/Scripts/Blade.cs) reads `Mouse.current` through Unity's new Input System.

### [Lesson 5.2 - Keeping Score](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-2-keeping-score?version=6.3)

**New functionality**

- **There is a UI element for score on the screen:** [GameManager](Assets/Scripts/GameManager.cs) holds and updates the TextMeshPro score label.
- **The player's score is tracked and displayed when a target is hit:** [Target](Assets/Scripts/Target.cs) passes its point value to [GameManager](Assets/Scripts/GameManager.cs).
- **There are particle explosions when the player gets an object:** [Target](Assets/Scripts/Target.cs) instantiates its configured particle effect when sliced.

**New concepts & skills**

- **TextMeshPro:** `TextMeshProUGUI` renders the score and lives text updated by [GameManager](Assets/Scripts/GameManager.cs).
- Canvas.
- Anchor Points.
- **Import Libraries:** [GameManager](Assets/Scripts/GameManager.cs) imports the `TMPro` namespace to use TextMesh Pro types.
- Custom methods with parameters.
- **Calling methods from other scripts:** [Target](Assets/Scripts/Target.cs) calls `GameManager.UpdateScore`.

### [Lesson 5.3 - Game Over](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-3-game-over-2?version=6.3)

**New functionality**

- **A functional Game Over screen with a Restart button:** [GameManager](Assets/Scripts/GameManager.cs) displays the game-over overlay when lives reach zero.
- **When the Restart button is clicked, the game resets:** `RestartGame` reloads the active scene in [GameManager](Assets/Scripts/GameManager.cs).

**New concepts & skills**

- **Game states:** [GameManager](Assets/Scripts/GameManager.cs) tracks whether the game is active or paused.
- Buttons.
- **On Click events:** the Restart button invokes the public `RestartGame` method configured through the Inspector.
- **`SceneManagement` Library:** [GameManager](Assets/Scripts/GameManager.cs) uses `SceneManager` to reload the current scene.
- **UI Library:** [DifficultyButton](Assets/Scripts/DifficultyButton.cs) uses `UnityEngine.UI.Button`.
- **Booleans to control game states:** `isGameActive` and `isPaused` gate spawning and slicing in [GameManager](Assets/Scripts/GameManager.cs) and [Target](Assets/Scripts/Target.cs).

### [Lesson 5.4 - What's the Difficulty?](https://learn.unity.com/pathway/junior-programmer/unit/user-interface/tutorial/lesson-5-4-what-s-the-difficulty-2?version=6.3)

**New functionality**

- **Title screen that lets the user start the game:** choosing a difficulty hides the main-menu overlay and starts play in [GameManager](Assets/Scripts/GameManager.cs).
- **Difficulty selection that affects spawn rate:** [DifficultyButton](Assets/Scripts/DifficultyButton.cs) sends the selected value to [GameManager](Assets/Scripts/GameManager.cs), which divides the base spawn interval by it.

**New concepts & skills**

- **`AddListener()`:** [DifficultyButton](Assets/Scripts/DifficultyButton.cs) registers and removes its button callback in code.
- **Passing parameters between scripts:** [DifficultyButton](Assets/Scripts/DifficultyButton.cs) publishes the selected integer difficulty for [GameManager](Assets/Scripts/GameManager.cs).
- Divide/Assign (`/=`) operator.
- **Grouping child objects:** related title-screen UI elements are grouped so the whole overlay can be shown or hidden together.

## Extra

- **Slicing mechanism:** holding the left mouse button moves a collider-backed blade and trail in [Blade](Assets/Scripts/Blade.cs), replacing the original click-to-destroy interaction.
- **Lives system:** missed good targets remove a life, and the game ends at zero in [Target](Assets/Scripts/Target.cs) and [GameManager](Assets/Scripts/GameManager.cs).
- **Pause support:** the Pause action in [InputSystem_Actions.inputactions](Assets/InputSystem_Actions.inputactions) triggers [PauseEvent](Assets/Scripts/PauseEvent.cs), which pauses gameplay through [GameManager](Assets/Scripts/GameManager.cs).
- **Volume control:** [VolumeSlider](Assets/Scripts/VolumeSlider.cs) sends slider changes to [GameManager](Assets/Scripts/GameManager.cs) to update the music volume.
- **Input implementation:** gameplay and UI use Unity's new Input System; [ProjectSettings](ProjectSettings/ProjectSettings.asset) permits both the new Input System and old Input Manager for compatibility, but active prototype input does not call the old `UnityEngine.Input` API.
