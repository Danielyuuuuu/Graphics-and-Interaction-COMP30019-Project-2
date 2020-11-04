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
| Yifei Yu           |                          Main game environment, Instructions UI, Start menu, Enemy AI, Enemy wave spawner, Game store                           | Mostly finished |
| Juntong(Angel) Tan | Shooting mechanism, Weapons, Bullets, Particle system effect(Damage explosion, Burning fire with smoke/sparks/flame/glow), Shader, Sound effect |     Almost done |
| Adrian Tang        |                                                                                                                                                 |                 |

## Explanation of the game

**Outpost Defence** is a top-view survival shooter game where the player is trapped in a military outpost in the middle of the desert. He has to fight his way out of waves and waves of enemies who are trying to invade the outpost. Luckily, there are still some weapons and equipments left behind to help him survive the enemy swarm.

_Are you dare to take the challenge and help us defend the outpost at all cost?_ :skull:

## Game Instruction and control

## Game Control:

W, A, S, D – Movement: Use these keys to move forward (W), left (A), backwards (S), and right (D).

Q or Mouse Wheel – Change Weapon: Swap the weapon by either pressing the Q key or rolling the Mouse Wheel up or down.

Mouse – Aim/Look: Move the mouse around to have your character look around or aim a weapon.

Left Mouse Button – Fire Weapon: This expels projectiles from your weapon's chamber.

## Goal:

-Kill the enemy waves and survive.

-There are five game levels, survive the five levels to win the game.

-If the level count down time becomes zero, you need to kill the remaining enemies on the map before leveling up.

## Notes:

-You can purchase new weapons and health packs in the game store using the in-game currency earned by killing the enemies. The game store is the yellow military tent on the middle left of the map with a shop icon jumping up and down. The shop menu will pop up when you walk near the yellow military tent.

-After purchasing any new weapons, you can either pressing the Q key or rolling the Mouse Wheel up or down to change weapons.

-If the weapon is out of ammo, purchase the same weapon again to restock the ammo.

-The revolver has infinite amount of ammos.

## Objects & Entities model

psaifjsaokfj

### Animation

slakfjlsaf

## Graphics pipeline & Camera motion

### Graphics pipeline

sadfjsafkj

### Camera

laskdfjlaksf

## Shaders

### Radial blur shader

sjadfkljsaf

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
