# CMYKlash
CMYKlash is a bullet-hell where you must master controlling a Triangle, a Line, and a Dot to earn points by defeating enemies while trying to stay alive. This submission for IcoJam 2023 takes the theme of "3... 2.. 1." by giving the player three vertices to start with before taking away one at a time as they take damage, challenging the player to gain as many points as possible before all their vertices are gone.

# Controls

* WASD to move the player model
  * W to move Upwards
  * A to move Left
  * S to move Downwards
  * D to move Right
* Left arrow rotates the player model in the counterclockwise direction
* Right arrow rotates the player model in the clockwise direction

# Gameplay

* The player starts the game off as a controllable Triangle with 3 vertices and 3 sides, each with a different color: cyan, magenta, and yellow
* Enemies will spawn at random locations at the edge of the level and will have different effects that the player must respond to
* On the map, there will be certain power-ups that the player can collect to assist them with increasing their score
* As a Triangle, the player must collide with enemies with their corresponding colors to destroy them (Ex: a magenta enemy is destroyed when collided with the Triangle's magenta-colored side). This will add points to the player's total score count
* Colliding with enemies with vertices kills enemies of both adjacent side colors (Ex: the vertex where the Triangle's cyan and yellow sides meet can destroy both cyan and yellow enemies)
* Once a player is hit with an enemy that is not of the corresponding color on that side of the Triangle (Ex: a magenta enemy hits the Triangle's cyan side, or the vertex between the cyan and yellow sides), the player will lose a vertex and two edges, turning into a Line with 2 colors and 2 endpoints instead
* As a Line, the objective remains the same, only that there are only two colors on the player character now: one on each side of the Line. Both endpoints can destroy enemies that are the same color as either side of the line
* Once a player is hit again under the same circumstances as above, they will lose an endpoint and turn into a singular Dot
* As a Dot, the objective changes to dodging all enemies, as the Dot can't destroy any enemies without any power-ups
* As the player avoids being hit as a Dot, the score will automatically increase over time
* Once a player is hit as a Dot, the game is over, and the player's high score is recorded

# Scoring System

* The Score Multiplier starts at 1 at the beginning of the run
* Every kill as a Triangle increases the score linearly by the multiplier, and every 10 kills as a Triangle increases the multiplier by 1
* Every kill as a Line increases the score linearly by the multiplier
* Every 5 seconds alive as a Dot increases the score linearly by the multiplier

# Enemy Types

* Linear (Circle): These enemies travel in a straight line from one end of the screen to the other
* Homing (Square): Upon entering the screen, these enemies follow the player until they eventually stop homing in on the player and travel in a straight line

# Power-Up Types

* Recover: Regain a vertex/endpoint, changing from a Dot to a Line, a Line to a Triangle, or a Triangle to a Tetrahedron depending on the game state. As a Tetrahedron, the player can destroy all enemies it collides with from any side, but this state is temporary
* Explode: Destroy all enemies present on the map
* Slow Down: Temporarily slow down enemies present on the map and pause enemy spawning
* Speed Up: Grant a temporary movement speed buff to the player
 
# Credits

* Programming, Unity Development, and Music: Daniel Rosenthal
* 2D Art Assets: Jellican
* 3D Art Assets: Blueboyv1
* Design and Documentation: Ryan Hiew
* Enemy Programming: Samu

# We hope you enjoy our game!
