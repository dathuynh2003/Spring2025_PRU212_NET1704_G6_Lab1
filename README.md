# **Lab 1: 2D Unity Game – Space Explorer**  

## **A. Game Concept**  
*Space Explorer* is a 2D space-themed game built in Unity 6, where the player controls a spaceship, navigating through space while avoiding asteroids and collecting stars to enhance their shooting ability.  

## **B. Game Elements**  

### **1. Spaceship (Player Object)**  
- **Description:**  
  A 2D spaceship that the player controls.

- **Functionality:**  
  - Move in all directions using the arrow keys.  
  - Shoot fire balls to destroy obstacles using left mouse button.
      - Form 1: Shoot red fire balls
      - Form 2: Shoot blue fire balls
  - Change the spaceship type using right mouse button.  

### **2. Asteroids**  
- **Description:**  
  Floating 2D asteroids appearing randomly in space.  

- **Functionality:**  
  - Move unpredictably within the scene.  
  - Colliding with an asteroid reduces the player's score.  
  - If the spaceship collides with an asteroid, the game ends.  

### **3. Balls (Item Drop)**  
- **Description:**  
  Collectible 2D balls scattered throughout space. Spawn every 30s. Comes in 2 forms, blue and red.

- **Functionality:**  
  - Increase the player's shooting power when collected.  
  - Enhance the gameplay experience by rewarding exploration.  

## **C. Game Flow**  

### **1. Main Menu Scene**  
- **Play Button:** Starts the game and transitions to the Gameplay Scene.  
- **Exit Button:** Closes the game.  

### **2. Gameplay Scene**  

#### **2.1 Game Elements**  
- Spaceship (player).  
- Asteroids (obstacles).  
- Balls (collectibles).  

#### **2.2 Objective**  
- Navigate the spaceship while avoiding asteroids.  
- Collect balls to improve shooting abilities.  
- The game ends when the spaceship collides with an asteroid.  

#### **2.3 UI Elements**  
- Score display to track the player's progress.  

### **3. End Game Scene**  
- Displays the player's final score.  
- Provides options to:  
  - **Return to Main Menu:** Restart the game.  
  - **Quit the Game:** Exit the application.  
