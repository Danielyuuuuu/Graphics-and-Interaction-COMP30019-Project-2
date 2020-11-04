**The University of Melbourne**

# COMP30019 – Graphics and Interaction

Final Electronic Submission (project): **4pm, Fri. 6 November**

Do not forget **One member** of your group must submit a text file to the LMS (Canvas) by the due date which includes the commit ID of your final submission.

You can add a link to your Gameplay Video here but you must have already submit it by **4pm, Sun. 25 October**

# Project-2 README

You must modify this `README.md` that describes your application, specifically what it does, how to use it, and how you evaluated and improved it.

Remember that _"this document"_ should be `well written` and formatted **appropriately**. This is just an example of different formating tools available for you. For help with the format you can find a guide [here](https://docs.github.com/en/github/writing-on-github).

**Get ready to complete all the tasks:**

- [x] Read the handout for Project-2 carefully

- [ ] Brief explanation of the game

- [ ] How to use it (especially the user interface aspects)

- [ ] How you modelled objects and entities

- [ ] How you handled the graphics pipeline and camera motion

- [ ] Descriptions of how the shaders work

- [ ] Description of the querying and observational methods used, including: description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

- [ ] Document the changes made to your game based on the information collected during the evaluation.

- [ ] A statement about any code/APIs you have sourced/used from the internet that is not your own.

- [ ] A description of the contributions made by each member of the group.

## Table of contents

- [Team Members](#team-members)
- [Explanation of the game](#explanation-of-the-game)
- [Game Instruction and control](#game-instruction-and-control)
- [Objects & Entities model](#objects-&-entities-model)
- [graphics pipeline & camera motion](#graphics-pipeline-&-camera-motion)
- [Shaders](#shaders)
- [Evaluation methods](#evaluation-methods)
- [Changes made from feedback](#changes)
- [Reference](#reference)
- [Technologies](#technologies)
- [Using Images](#using-images)
- [Code Snipets ](#code-snippets)

## Team Members

| Name               |                                                                      Task                                                                       |           State |
| :----------------- | :---------------------------------------------------------------------------------------------------------------------------------------------: | --------------: |
| Yifei Yu           |              Main game environment, Instructions scene, Start menu scene, Enemy AI, Enemy wave spawner, Game store, Options scene               | Mostly finished |
| Juntong(Angel) Tan | Shooting mechanism, Weapons, Bullets, Particle system effect(Damage explosion, Burning fire with smoke/sparks/flame/glow), Shader, Sound effect |     Almost done |
| Adrian Tang        |                                                                                                                                                 |                 |

## Explanation of the game

**Outpost Defence** is a top-view survival shooter game where the player is trapped in a military outpost in the middle of the desert. He has to fight his way out of waves and waves of enemies who are trying to invade the outpost. Luckily, there are still some weapons and equipments left behind to help him survive the enemy swarm.

_Are you dare to take the challenge and help us defend the outpost at all cost?_ :skull:

## Game Instruction and control

### Game Control:

W, A, S, D – Movement: Use these keys to move forward (W), left (A), backwards (S), and right (D).

Q or Mouse Wheel – Change Weapon: Swap the weapon by either pressing the Q key or rolling the Mouse Wheel up or down.

Mouse – Aim/Look: Move the mouse around to have your character look around or aim a weapon.

Left Mouse Button – Fire Weapon: This expels projectiles from your weapon's chamber.

### Goal:

-Kill the enemy waves and survive.

-There are five game levels, survive the five levels to win the game.

-If the level count down time becomes zero, you need to kill the remaining enemies on the map before leveling up.

### Notes:

-You can purchase new weapons and health packs in the game store using the in-game currency earned by killing the enemies. The game store is the yellow military tent on the middle left of the map with a shop icon jumping up and down. The shop menu will pop up when you walk near the yellow military tent.

-After purchasing any new weapons, you can either pressing the Q key or rolling the Mouse Wheel up or down to change weapons.

-If the weapon is out of ammo, purchase the same weapon again to restock the ammo.

-The revolver has infinite amount of ammos.

## Objects & Entities model

### Model

All the models used in the game are acquired from various packages in unity store. Those include but not limited to the prefabs shaping our game environment, characters and weapons.

### Animation

All humanoid animation files (.fbx) are obtained from [Mixamo.com](https://www.mixamo.com/#/). Then we create our own animator component to control the states for each animations and assign it to the script so that our characters can perform the appropriate animation in the game.

## Graphics pipeline & Camera motion

### Graphics pipeline

The graphics pipeline used in this game will be Direct3D 11 and its process is the following: Firstly, the `vertex shader` handles the mesh data of objects (vertices). Then in the `rasterizer stage`, we performed _occlusion culling_ where any non visible objects that are currently can't be seen by the camera will not be rendered. After that, the `fragment shader` produces colour and lighting for the objects. The final projection undergoes transformations and then converted to the screen space.

### Camera

Camera is placed above the player pointing downward to mimic a `top-down/God view` style. It is setup to trace the player location so that it is always in the center of the screen.

## Shaders

### Radial blur shader

<p align="left">
  <img src="Gifs/blur-example.PNG" height="300"  >
</p>

This is an `image effect` shader that adds a post-processing effect on the final image shown on the screen. The blur effects will become visible once the player's health drops to a certain point. The lower the health is, the more blurriness it will appear. It is used to indicate how injured the player currently is and hopefully makes him feels more engaged in the game.

```C#
Properties
{
  _MainTex ("Texture", 2D) = "white" {}
  // determines how many times the main texture will be sampled
  _Samples("Samples", Range(4, 32)) = 16
  // determines how intense the effect is going to be
  _EffectAmount("Effect amount", float) = 1
  // determines the center around which the radial blur will occur,
  // in screen space coordinates, now it is hard-coded to be center.
  _CenterX("Center X", float) = 0.5
  _CenterY("Center Y", float) = 0.5
  // determines the radius of the area that is unaffected by the blur.
  _Radius("Radius", float) = 30
}
```

These are the properties controlling the amount of radial blur effect. `_Samples` determines the number of times the texture should be sampled. `_EffectAmount` determines the strength of each sampling. `_CenterX` and `_CenterY` specifies the screen position where the blur should takes place. In this case, it is set to the center of the screen since that is where the player will be positioned. `_Radius` decides how large the non blury area is.

```C#
fixed4 frag (v2f i) : SV_Target
{
  fixed4 col = fixed4(0,0,0,0);
  /**
    * for the current pixel, find its distance from the defined center,
    * by subtracting the center of blur from the uv coordinates of the current pixel,
    * the result vector is the direction incidate which way to offset each sample.
    */
  float2 dist = i.uv - float2(_CenterX, _CenterY);
  // Sampling the camera's main texture a bunch of times,
  // result of each sampling will be added together.
  for(int j = 0; j < _Samples; j++) {
      float scale = 1 - _EffectAmount * (j / _Samples)* (saturate(length(dist) / _Radius));
      col += tex2D(_MainTex, dist * scale + float2(_CenterX, _CenterY));
  }
  col /= _Samples;
  return col;
}
```

Since the shader is all about sampling the camera's texture multiple times, we can leave the vertex shader unchanged and works on the fragment shader to get the desired effect. To get the radial blur effect, basically we are sampling the screen pixel coordinates according to their positions, making them offset outwards in each sampling procedure.

First of all, we obtain the vector of a pixel by subtracting it from our specified center. This gives us the direction indicates which way to offset each sample. Then within each sampling, we calculate the scale that each sample needs to be offset and store the sampling result into `col`.

- In each iteration, the sample will be offset by a fraction of the total offset. This is done by the expression of `_EffectAmount * (j / _Samples)`. Without the fraction, the effect will become magnifying as the pixels are offsetted out of the screen.
- `saturate()` clamps the result between 0 and 1 and is used to decide the amount of scale depending how far the pixel is from the center. The closer the pixel is to the center, the lesser the offset amount.
- `tex2D` does the job of sampling by multiplying the screen pixel (`_MainTex`) with the direction of the offset and its scale. And it is added the center location to return the appropriate offsetted pixel in the screen.

Finally the sampling result is divided by the number of samples to return the correct texture.

### Water flow shader

laksdjflaksjfdlj

## Evaluation methods

### Methodology

#### Observational method: Post-task walkthroughs

Questions we have asked: https://forms.gle/7ENU1zoBeCBV6G6w8

##### What did we have participants do:

We let the participants play our game, and then we watch them play without giving any hints. We ask them questions and seek comment from them straight after they finish playing, to make sure the problems they struggled with are still fresh in mind.

##### How did we record the data:

Rather than asking "yes or no" closed questions, the questions we ask the participants are mostly "open questions" which do not have a predetermined format. We ask them specific questions based on their performance in the game and mark down their answers while they giving us feedback. Eventually, we will combine all the participants' results to analyse.

##### Why we chose this method:

We chose this method because the participants have time to focus on relevant incidents. And being able to avoid excessive interruption of the task.

#### Querying technique: Questionnaires

Form link: https://forms.gle/Pd9VuR32tdNVCc156

##### What did we have participants do:

We have carefully designed a questionnaire by considering what information we require and how answers can be analyzed. The questionnaire includes a set of fixed questions. Then we let the participants play our game by themselves. After they finish playing, we provide the questionnaire for them to complete. They can play the game and complete the questionnaire at any time, and play it for as long as they want, which provide them with more freedom and more flexibility.

##### How did we record the data:

After the participants completing the questionnaire, we collect all the responses through Google Form and analyze them together. The styles of questions are mostly scalar and multi-choice, which are easier to record and analyze.

##### Why we chose this method:

We chose this method because it's easier and quicker to reach relevant large participant group. We can ask more participants to take the questionnaire at the same time frame. And we can analyze the results more rigorously.

### Participants description

Participants are ......

### Feedback

sfosafhkn soifj

## Changes

1. Added a floating shop icon on top of the shop, to make the shop more recognizable.
2. Added a pop up message to tell the player to buy the weapon in the shop when reaching a certain amount of in game currency.
3. Added more game instructions.
4. Fixed walking over the water tank bug.
5. Fixed the enemy spawn inside the water tank bug.
6. Added a difficulty slider for player to change the game difficulty.
7. Fixed UI scaling issue.
8. Slowed the enemy spawn speed.
9. Reduced the game levels.
10. Extended the survival time needed for each level.
11. The player will restore to full health after completing each level.
12. Made the enemy collider a little bit bigger.
13. Added a black background to the pop up message.

## Reference

asldfkjaosdibjlabjalkj

## Technologies

Project is created with:

- Unity 2019.4.3f1
- Ipsum version: 2.33
- Ament library version: 999

## Using Images

You can use images/gif by adding them to a folder in your repo:

<p align="center">
  <img src="Gifs/Q1-1.gif"  width="300" >
</p>

To create a gif from a video you can follow this [link](https://ezgif.com/video-to-gif/ezgif-6-55f4b3b086d4.mov).

## Code Snippets

You can include a code snippet here, but make sure to explain it!
Do not just copy all your code, only explain the important parts.

```c#
public class firstPersonController : MonoBehaviour
{
    //This function run once when Unity is in Play
     void Start ()
    {
      standMotion();
    }
}
```
