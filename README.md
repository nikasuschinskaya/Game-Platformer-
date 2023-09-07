# Game-Platformer-
Game Platformer is a dekstop game written in the C# programming language and its own game engine that uses the OpenTK wrapper library of the OpenGL graphics library.

## User Interface

After launching the developed game application, the main menu window appears, which contains a pleasant-looking background, the name of the game and four buttons: "Start the game", "About the author", "Help" and "Exit".

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/5187291c-1338-4f60-8334-6897c73db144)

## Initial character characteristics:
- number of lives – 10 units;
- the number of health points is 100 units;
- the number of keys is (n–1) pieces, where n is the level number;
- speed – 0.

## Types of blocks
- solid block – impassable;
- block platform – with the possibility of passing through it;
- block-stairs – it is only possible to go down and up;
- block-stairs with a platform – with the ability to stand on it;
- blocks-spikes – take a life;
- block key - transition to a new level.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/a4079903-fc48-4fb6-a153-673f5fbc2bc4)

## Enemies
The player's goal is also survival. In this he is hindered by his enemies.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/cf726dff-ed1c-4dfa-a3ae-7d76b938599a)

The first enemy in the drawing is a horizontally moving enemy, the second is changing its size, and the third is shooting.
When touching any of the enemies, one health point is taken away. The total number of health points removed will depend on the duration of contact with the enemy.
The shooting enemy has an infinite number of bullets in his arsenal, which he shoots about once every 1.5 seconds. When bullets hit a player, 10 health points are removed from him.

## Gameplay

After clicking on the "Start Game" button, the OpenTK library window opens with the first level of the game application loaded. At the first level, the main goals for the player are to master the control of the character, to get to know the enemies, as well as to observe what health points are taken away for and get their first key. The key is a block-a transition to the next level.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/d9ebebef-6ddc-46ba-ad5b-04d507d5d1e7)

It is worth noting that the entire level cannot be seen. To preserve the intrigue and interest of the player, there is a scope of visibility. The visibility area of the level is approximately ten blocks from all sides. This is enough to dodge enemy attacks and see the obstacles further.
The number of lives, health points and the number of keys are displayed in the name of the window.
After passing the first level, the player meets the second one. At the second level, the difficulty increases, as the "spikes" object appears, which removes the whole life.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/bd1ee9e4-7ac9-4eaa-a24b-74e97c2bd8d9)

At this stage, it is worth noting that at each level, the number of lives and health points are updated.
At the second level, the player is met, in addition to spike blocks, platform blocks. You can both stand on these blocks and walk through them, if necessary. This feature can be used in cases where the thorns are so that it is difficult to jump over them.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/7519a857-aa1c-40e7-83a7-6c7a12643e09)

You can also observe changes in the panel at the top of the window. Now the player has one key, he is stubbornly moving towards victory. However, if the player runs out of lives, then a pop-up window will be waiting for him with an offer to complete the game again.  When you click on the "Yes" button, the game will start again from the first level, and if you click on the "No" button, then you will exit the game.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/f68a903a-82ad-4693-b288-5701f1d774b6)

But if you managed to pass the second level without losing, then the player meets the most difficult final third level.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/9f03110a-0226-4795-a5bf-30928fe2728c)

This level is characterized by its maximum complexity, so for its passage it is necessary to carefully calculate each step and jump.
At the third level, you can also observe a change in the number of keys in the header. Now the player has two keys, and it remains to get the third key to win. 

The player's fall from the platforms is implemented in such a way that if the character's fall time is more than 5/6 seconds, then (t-40) health points are taken away, where t is the time of falling from the block.
Upon successful completion of all levels and obtaining the last key, the player will be greeted with a victorious pop-up window with congratulations.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/74cd62a5-23e9-491f-a22e-42d77e8feff0)

When you click on the "OK" button, the program will end.

## Testing

The Platformer Game Tests project for unit tests contains tests for important and complex functional classes.
This project allows you to check whether the developed classes and their methods and properties work correctly.

![image](https://github.com/nikasuschinskaya/Game-Platformer-/assets/92970744/b6020bfc-c1d0-4070-8ff5-d6971720fbfa)






