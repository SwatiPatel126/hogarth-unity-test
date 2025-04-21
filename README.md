# hogarth-unity-test
(It's unity assessment test for Hogarth)

**Project Overview**

Title: CombatSystemSimulation  
Engine: Unity 6000.0.32f1  
Language: C#  
Description:
A simple or lightweight combat simulation game where 10 characters battle each other using ranged weapons in auto mode. Each character chooses a target randomly and continues attacking until the target dies. The last character standing wins.


**Features Implemented**  
✅ Random target selection.

✅ Character movement and rotation towards the target.

✅ Continuous attack on the target until it dies when the weapon is in range. 

✅ Weapon spawns and fires bullets towards the target.

✅ Only one bullet is fired in one cycle of weapon attack speed.
 
✅ Health damage system. Character dies when health is zero or less.

✅ Battle ends when only one character remains.

✅ Displays the winning character name in UI.

✅ Game restart option

✅ **Camera movement** (rotation and panning) to visualize characters' movement.


**Project Structure**  
    ● Animations: Contains animation for BattlePopup  
    ● Materials: Contains ground materials  
    ● Models: 3D models and textures of the Character and bullet  
    ● Prefabs: Prefabs for bullet, weapon and character  
    ● Scenes: SampleScene  
    ● Scripts: Contains all mono behaviour scripts of game  

**Primary Components**  

💠 Character.cs  
    Handles:   
    ● Health management
    ● Target selection
    ● Attack loop
    ● Death detection

    Fields:
    ● bool IsAlive
    ● int Health;
    ● float MoveSpeed
    ● float RotationSpeed
    ● Weapon weapon
    ● Character currentTarget
    
    Key Methods:
    ● RotateTowardsTarget(Vector3 targetPosition)
    ● MoveTowardsTarget(Vector3 targetPosition)
    ● DamageHealth(int damage)
    ● Die()
    ● CharacterBattle()//Attack loop
    

💠 Weapon.cs  
    Handles:   
    ● Spawn Bullet 
    ● AttacK
    
    Fields:
    ● float AttackSpeed
    ● float Range
    ● float BulletSpeed
        
    Key Methods:
    ● Attack 

💠 Bullet.cs  
    Handles:   
    ● Movement toward target(Fire)
    ● Collision Detection with a character
    ● Damage Delivery

    Fields:
    ● int Damage
    ● float Speed
    
    Key Methods:
    ● SetBullet(int damage, float speed)
    ● Fire()
    ● OnCollisionEnter(Collision collision)

💠 BattleManager.cs (singleton class)
    Handles:   
    ● Battle game play
    ● Reference list to all characters
    ● Random alive target detection 
    ● Manage character death
    ● Battle over logic
    ● Winner declaration

    Fields:
    ● List<Character> characterList
    ● bool _isBattleOver
    
    Key Methods:
    ● Character GetRandomTargetFor(Character player)
    ● OnCharacterDeath(Character character)
    ● DeclareWinner()

💠 BattleUIController.cs (singleton class)
    Handles:   
    ● Show battle over pop-up
    ● Displays a winning message with the winner's name
    ● Game Restart
    
    Fields:
    ● TextMeshProUGUI _battleOverMessage
    ● GameObject _battleOverPopup
    
    Key Methods:
    ● ShowBattleOverPopup(string messageToDisplay)
    ● OnRestart()


💠 CameraMovement.cs
    Handles:   
    ● Rotation on the left mouse button drag
    ● Panning on the right mouse button drag  
    
    Fields:
    ● float RotationSpeed
    ● float MoveSpeed
    ● Camera Cam
    
    Key Methods:
    ● RotateCamera()
    ● MoveCamera()

**Assumptions**  
    ● Characters are AI-driven; no player-controlled input.  
    ● Bullet has a lifetime if it doesn't collide with a character, it will be destroyed after some time. Immediately destroyed after collision with a character.  
    ● Only one bullet is fired per restdown cycle/Attack speed.  
    ● Targets are chosen randomly from alive characters.  
    ● Character attacks on target continuously until it dies.

**Questions**  

    ● How would your code change if weapons had special effects, like the ability to make targets catch fire?  
    ⇛Answer: There should be different classes for each effect, like(BurnEffect, WaterEffect), implementing an interface like IEffect for flexibility(Weapon can add more effects without modifying existing classes). All effects can be listed or referenced without worrying about their type, e.g., IEffect effect = new BurnEffect(); IEffect effect = new WaterEffect();

    ● How might this system be incorporated into a larger items and inventory system?
    ⇛Answer: Integrate the inventory module, which has different components like InventorySystem, InventoryUI, etc. This module should have a list of all available weapons. Weapon should hold all weapon data (like attackSpeed, range, effects) using scriptable objects. Each character can have a reference to the Inventory and can select an active weapon.

**Areas for Improvements**  
    ● Instantiate characters dynamically(runtime) at random positions, maintaining enough distance between each.  
    ● Object pooling for bullet spawning.  
    ● Add different strategies to select a target.  
    ● Character movement(characters should not overlap each other during movement).  
