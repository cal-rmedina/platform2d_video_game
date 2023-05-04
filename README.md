# 2D Platform video game example 

2D video game fully developed with [Unity](https://unity.com), the game was
developed using the Unity engine [Unity-Hub](https://unity.com/unity-hub).

## Features

Some features of this model:

- C# code for the video game mechanics.
- Images, animations, and music are taken from the [Unity Assets
  Store](https://assetstore.unity.com), using only free assets for the whole
game.

## Dependencies

The version used was [Unity 2021
LTS](https://docs.unity3d.com/2021.3/Documentation/Manual/WhatsNew2021LTS.html)
but it should run with any latest version.

## Assets (`./Assets/`)

- Characters, traps, tileset combinations and other small elements are taken from
[Pixel Adventure
1](https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360).
- Sound effects are taken from [Casual Game
  Sounds](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116).
- Background music for each level is taken from [Casual Game BGM
  5](https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943).

## Files structure

### Code (`./Assets/Scripts/*.cs`)

>The code is divided in several <b>C#</b> files, containing the functions
that control the different mechanics taking places during the game
execution. The <b>file name</b> can guide the curious user to know the
purpose of each script, e.g., `PlayerLife.cs` contains the
triggered functions once the player touches a deadly object. 

```cs
    private void Die()
    {
       deathSoundEffect.Play();
       rb.bodyType = RigidbodyType2D.Static; 
       anim.SetTrigger("death");
     }
```

>A fragment of the `PlayerLife.cs` code is taken to illustrate function
>structure inside each script.

## Playing the video game

For checking/modifying the structure, debbuging or simply playing the video
game, Unity installed in your computer is needed, check the [installation
link](https://unity.com/download) and follow the instructions for your OS.

Clone the github repository typing on the terminal the following commands, the
first (`pwd`) will tell you the directory where the termial is, and the second
will download the repository on that directory

```
$pwd;git clone https://github.com/cal-rmedina/platform2d_video_game.git 
``` 
Or simply download it directly from the
[webpage](https://github.com/cal-rmedina/platform2d_video_game).

Open the directory directly with UnityHub: click on the `Open` button,
and select the repository.

Some useful shortcuts depending on your OS can be found on the [Shortcuts
Manager](https://docs.unity3d.com/Manual/ShortcutsManager.html).

