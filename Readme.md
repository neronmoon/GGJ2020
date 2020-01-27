# TemplateGame Game!

###
How to get the code:
```
git clone --recursive git@github.com:neronmoon/GGJ2020.git
```

### What to do:
* Add GameConfig to scene
* Make fill TemplateGame/GameData class (make subclasses same file or move them into GameData separate)

# Principles
* Keep your ECS code unity independent; The only feature that should be dependent is `RenderFeature`
* Make non-unique Entities with Factories
* Don't add FeatureX's components in FeatureY's systems. Make a command OR publish a message about event and make FeatureX do it's job
* Don't mutate entitites from views. Call a command or publish a message

## Entity <-> GameObject linking
* To create game object from Entity -- add `UnityResourceComponent` to it.
* If you want to create link existing game object to Entity -- create EntityView component and make render in it 

## What's inside
* [DefaultECS](https://github.com/Doraku/DefaultEcs/) -- Cool ECS and EventBus framework
* [GData](https://github.com/neronmoon/GData/) -- Google sheets game data accessor
* [MinIoC](https://github.com/microsoft/MinIoC) -- Simple IoC Container
* [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) -- Nice attributes for nice inspector
* TextMeshPro, DOTWeen -- Standard assets for all Unity projects

### Structure
```
* Plugins (External plugins)
* Prefabs (Hold all prefabs here)
* Resources (folder for sprites, audio, fonts and other resources)
* Scenes (All scenes of game)
* Source (Source code)
    * Common (Common classes. Keep it engine independent)
    * TemplateGame (Game logic code here. ECS, ok? Rename it to your game title)
        * Commands (Commands that will mutate your entities from views)
        * Factories (Classes for creating typical entities)
        * Features (Game features. IMPLEMENT GAME HERE)
        * Messages (EventBus messages)
* Unity (All unity-dependent stuff)
    * Common (Common unity-dependent classes)
    * DataObjects 
    * View 
```
