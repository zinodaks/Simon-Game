# Simon Game 

A self-imposed challenge that I took on to recreate the classic [Simon memory game](https://en.wikipedia.org/wiki/Simon_(game)) using Unity Game Engine. It's a 2D game that consists of just the simon board with it's four colors turned off.

I got a little help from Photoshop to play with the colors in order to make the light on light off effect. The game randomly chooses colors in the beginning that I made sure would not be repetitive by disallowing consecutive same color light on. 

The players objective is to retain the color sequence that the game generates and repeat it back on the simon board by clicking on the appropriate colors in the right sequence. Everytime the player repeats back the right sequence of colors the level of the game increments and one more color is added to the sequence. 

The game is won when the player reaches the 20th level which is very difficult level to reach.

I was able to grasp the concept of [Coroutines in Unity](https://docs.unity3d.com/Manual/Coroutines.html) by creating this simple game. 

Part of the challenge was to create this game in the simplest way possible and I believe that I conquered that challenge by creating the whole game around a simple image that I downloaded from Google. By cropping out the lights on the simon board and a little bit of photoshop , I was able to mimick the lights turning on and off by just switching the images according to a random sequence that the game generates to simulate the light blinking on and then back off. This approach helped me spend less time on creating the board all alone and instead I spent more time turning the simple image into a game. The lights also blink on the board when the player clicks on them to repeat the sequence.

The highest level I have been able to reach is level 6 , can you beat my highscore ?