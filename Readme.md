# Shhh - Silence!
Simple gameplay, where you have to live quietly with your neighbor but items in your home will make it hard. 

## Gameplay 
Don't be loud. Your neighbor is sleeping and you don't want to wake him up. So silence everything you need. Try to silence as many loud corruption noises as possibly, but longer you try to stay silent, the often they come.

## Implementation
### Controller
- Using Unity old input system, controls are defined in PlayerControlsProvider;
- Using Character controller;

### Audio
Using Unity3D standard solution. Utilizing Audio System, Physics System and Scriptable Objects.

#### Sound data
I'm storing sounds with additional parameters like volume and pitch in Scriptable Object called ***AudioData***. Volume and pitch are defined in min / max, and sound clip is defined in array. It defines custom method ***GetSound()*** for picking sound.

![Audio Data](Docs/AudioData.PNG)

#### Unity Audio Mixer with groups
##### Mixer groups
Changing mixer group on fly for dynamic and pickable items. I'm using Unity Collider / Rigidbodies for checking if object should change it's mixer group, and I store those mixer group in Scriptable Object called ***AudioAmbience***, as I want additional security when asset is picked (for example I don't want level entity that uses *Master* or *Menu* mixer group.)
- Mixer groups
  - Menu
  - Level (AudioZone)
    - Default
    - Bedroom
    - Bathroom
    - Living Room
    - WC

##### Audio Enviroment
It is BoxCollider with isTrigger = true. It has script ***AudioEnviroment*** which handles changing mixer groups of items within it.

![Audio Enviroment](Docs/AudioEnviroment.PNG)

##### Audio Ambience Item
Currently to register change of enviroment on item I use OnTriggerEnter / Exit / Stay on ambient zones, which is quite resource intensive, but due to time constraint and complexity of other solution I stayed by using colliders mixed with rigidbodies. So if there is no colliders / rigidbodies within gameobject with component ***AudioAmbienceItem***, then they will be created via code. 

It creates AudioSource per AudioAmbienceItem with RequireComponent, so it is one AudioSource per item. I prefered having multiple AudioSource to handle multiple interactions as Opening, Picking Up, Closing or Turning On / Off.

#### Player
##### FootstepController
Plays AudioData of default ground or sound specified in custom component when specified period of time elapsed and Player is moving and grounded. 


### Gameplay
WIP

## Using
### Utilities
- DOTween
- Quick Outline

### 3D models 
- Kenneys Furniture Pack

### Audio
- Kenneys UI Audio
- Sounds from freesounds.org
- Music from Freepd.com
  