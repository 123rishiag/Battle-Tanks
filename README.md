# Battle Tanks

Battle Tanks is a strategic action game where players control various tanks to engage in intense battles. This project follows the Model-View-Controller (MVC) architecture, emphasizing modular design, an efficient bullet system, and wave-based gameplay.

## Features

### Game Mechanics

- **Tanks**: Players can choose from various tank types, each with distinct attributes for a customizable playstyle:
  - **Green Tank**: High health, moderate movement speed, and uses Explosion-type bullets for area-of-effect damage.
  - **Blue Tank**: High health, slower movement speed, and equipped with Normal-type bullets for standard damage.
  - **Red Tank**: High health, fast movement speed, and utilizes Piercing-type bullets for high damage output.
  - **Grey Tank**: Low health, lowest speed among all tanks, using Normal-type bullets for basic attacks.

- **Bullets**: Three types of bullets with distinct attributes:
  - **Normal**: Lowest speed and damage, suitable for quick engagements.
  - **Explosion**: Moderate speed and damage, causing area-of-effect damage.
  - **Piercing**: Highest speed and damage, designed to penetrate tougher enemies.

- **Wave System**: Spawns waves of enemy tanks with increasing difficulty, challenging players' strategic and tactical skills.

## Project Structure

### Core Components

- **TankSpawner**: Responsible for spawning and managing player and enemy tanks, ensuring their proper placement and initialization in the game world.
  - **TankController**: Handles tank-specific behaviors and game logic.
    - **PlayerTankController**: Manages player-controlled tank actions and interactions.
    - **EnemyTankController**: Controls AI behavior for enemy tanks.
  - **TankModel**: Manages data related to tank attributes, including health, speed, and bullet types.
  - **TankView**: Handles the visual representation, animations, and effects for tanks.
  - **TankTypes**: Enum defining different tank classifications and their respective properties.

- **BulletSpawner**: Manages bullet instantiation, ensuring bullets are properly created and tracked during gameplay.
  - **BulletController**: Controls bullet behavior, including movement, collisions, and interactions.
  - **BulletModel**: Stores data and properties related to bullets.
  - **BulletView**: Manages the visual effects and animations of bullets.
  - **BulletTypes**: Enum categorizing bullet types with distinct properties.

- **WaveSpawner**: Manages the spawning and progression of enemy waves, creating increasing challenges for the player.

- **GameManager**: Oversees the overall game state, including level transitions and core game logic management.

- **UI Management**:
  - **GameHudController**: Manages HUD elements, such as health, wave number, and the number of enemies left.
  - **GameOverMenuController**: Controls the game-over screen and related UI interactions.
  - **TankSelection**: Handles player tank selection within the game menu.

### Auxiliary Components

- **OwnerTypes**: Enum distinguishing between player and enemy-owned assets.
- **SoundManager**: Manages background music and sound effects to enhance player experience.

## Learning Outcomes

- **Model-View-Controller (MVC) Architecture**: Applied a modular approach to separate data handling (Model), game logic (Controller), and rendering (View) for clear separation of concerns and maintainability.
- **Modular Services**: Created distinct services such as TankSpawner, BulletSpawner, and WaveSpawner for centralized, streamlined game logic.
- **Bullet System Design**: Developed a flexible, color-based bullet system with consistent physics behavior, simplifying bullet management without the need for prefab swapping.

## Setting Up the Project

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/123rishiag/Battle-Tanks.git
   ```
2. Open the project in Unity.

---

## __Video Demo__

[__Watch the Video Demo__](https://www.loom.com/share/f7d5c72f2ae541c5808a964e1c0c2cbe?sid=d2a9e142-beb9-47f0-89ce-1ee39f4c3c6b)

## __Play Link__

[__Play the Game__](https://outscal.com/narishabhgarg/game/play-battle-tanks-34-game)