# Development Notes

## Preparation

Before I start the task, I asked the recruiter (Marina) about the art components, if it would be given to me or if I would have to work with what I have. After she answered me, I started looking for asset packs for GUI, sprites, icons, fonts, musics and sound effects. The choosen assets were:

- **GUI**
    - https://free-game-assets.itch.io/pixel-art-2d-game-ui
- **Sprites**
    - https://free-game-assets.itch.io/villager-portraits-pixel-art
    - https://free-game-assets.itch.io/farming-pixel-art-pack
- **Icons**
    - https://free-game-assets.itch.io/40-food-icons
    - https://free-game-assets.itch.io/40-pixel-art-icons-for-field-location
    - https://free-game-assets.itch.io/40-icons-for-crafting-pixel-art-pack
- **Fonts**
    - https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
    - https://assetstore.unity.com/packages/2d/gui/icons/20-logo-templates-with-customizable-psd-vector-sources-174999
- **Musics**
    - https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943
    - https://assetstore.unity.com/packages/audio/music/25-fantasy-rpg-game-tracks-music-pack-240154
    - https://assetstore.unity.com/packages/audio/ambient/forest-sounds-2023-lite-230097
- **Sound Effects**
    - https://assetstore.unity.com/packages/audio/sound-fx/dialog-text-sound-effects-222079
    - https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116
    - https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879

It's valid to point that not all this assets will be used. They were selected in case they were needed.

## First Steps

After reading the task, my first thougth were to priorize the requirements considering its difficulty (and start this doc, to have trace of my actions).

> My biggest concern at this point is about the clothes shop, because it needs a lot of sprites that I don't have in hand, so I'll have to figure out how I'll do it. The condition of "The outfits that are equipped should be visible on the character itself." makes everything harder.

### Requirements

1. [X] Genre: Simulation
2. [X] Top-down view
3. [X] Player character that is able to walk and interact with the game world
4. [X] Clothes Shop
    1. [X] Talk to the shopkeeper
    2. [X] Buying/selling items
    3. [X] Item icons 
    4. [X] Item prices
5. [X] Outfits that are equipped should be visible on the character itself

After listing the requirements, I made a list of tasks that I should do before starting the code development.

### Tasks to be done

1. [X] Get art assets for top-down view enviroment

    Four tilesets were picked for complete this task. They were: [RPG Tropical Tileset](https://free-game-assets.itch.io/rpg-tropical-tileset), [RPG Summer Tileset](https://free-game-assets.itch.io/rpg-summer-tileset), [RPG Winter Tileset](https://free-game-assets.itch.io/rpg-winter-tileset) and [RPG Autumn Tileset](https://free-game-assets.itch.io/rpg-autumn-tileset).

2. [X] Get player art assets

    The player art assets were found along with the clouthes assets

3. [X] Get art assets for the cloth shop
    1. [X] Figure out a way to fit all outfit related conditions

        To make changeable outfits, the player game object needs to have separated components for head, hair, torso and feet. 

    2. [X] Find art assets that fit what were planned

        Several asset packs the follow the desired conditions were found. To start the development, three were selected: [Seller NPC Character Sprites](https://free-game-assets.itch.io/seller-npc-character-sprites), [Wizard 4-Direction Game Characters](https://free-game-assets.itch.io/wizard-4-direction-game-characters) and [Archer 4-Direction Characters](https://free-game-assets.itch.io/archer-4-direction-characters). Depending on   how the development goes, more will be added.

> Some questions about the game design were raised while writing this document, which will be answered later:
> - How the player will get the money to buy the clothes?
> - The player will get inside the shop (as the seeds shop in Stardew Valley)?
> - The game will have combat with animals?

## Development

The plan for the development were to start doing the necessary for the map construction, create the tiles and palletes needed. After that, the aproach were to develop the core functions, starting by the walk, followed by the interaction with other objects.

After the moviment was complete and the basic interaction was made, I started to think about how the player will get money to buy the clothes. The initial idea was to make the interaction with the environment return some items that could be selled, like fruits, logs or gems. However, to reach out this idea, is necessary to first develop an Item class, that will be used for most interactable objects.

After doind some more research I found a way of doind the clothes changing with Rig animation, however to accomplish that I would have to create the Rig of my player and recreate the used animations, what would cost a lot of time. As some core mechanics are not ready yet, they'll be priority, because the full body clothes change is already working, but the idea is to finish these mechanics and then start the Rig.

The development of the selling mechanic, selling UI and invetory spent more time than planned, what made me change the plans around the creation of a Rig for the player. Despite the mechanics of purchase not being ready, doind the Rig became priority because it will influence on how the buy will be made. If the outfit's creation is successful, updates to the outfit changing mechanic will be made, as well as their interfaces. Finally, the purchase mechanism, its interfaces and the interaction with the seller will be made.

Several hours were spent to create the sprites and animations with bones and it wasn't 100%. Some bugs appeared when switching sprites, the bones weren't rebind right, what caused problems in the animations. However, the other mechanics need to be done, so the focus now is to finish the buy mechanics and UI, the change outfit UI and the shopkeeper interaction. After finishing that I'll add some components that are necessary for every game, but that were left aside due to this development being being aimed at creating a prototype, like a menu, sounds, conversations and a tutorial.

At the end, after adding the buy mechanic, the shop keeper and the change clothes UI, there wasn't much time left. The final implementations were aimed at a better user experience, so a tutorial and visual feedback for item collection were added.

### Tasks to be done

- [X] World building (tiles, palletes, colliders...)
- [X] Movimentation
    - [X] Improve Movimentation Animation
- [X] Interaction with other objects
    - [X] Interaction with Trees
    - [X] Interaction with Bushes
    - [X] Interaction with Rocks
    - [X] Interaction with Cluster of Stones
    - [X] Interaction with Shopkeeper
- [X] Items: An item has a name, a type, a price and a "Use" function (that can be nothing)
- [X] Inventory
    - [X] Inventory UI
    - [X] Change clothes UI
- [X] Changing clothes mechanics
    - [X] Redo Changing clothes mechanics with Rig
- [X] Shop UI
    - [X] Sell UI
    - [X] Buy UI
- [X] Buy / Sell mechanics
    - [X] Sell mechanics
    - [X] Buy mechanics

### Problems found

- The assets selected for the player just have full body animations, what limits the chaging clothes mechanics to full body changes
- After creating new sprites and trying to add bones to it, some bugs appeared after chaging sprites

### Comments

- A decision a made to save time was the use o Scriptable Objects to Items. In a real systems I believe that using a Factory Pattern that receives an external document, like a JSON.

## Self-evaluation

- I figure out a way to do the cloting change mechanics and I liked the way I did it, but at the start I wanted to make something better, where the user would be able to change the outfit from specific parts of the body. I actually figure out a way of doing it, but it didn't consider moviments and when I saw that the asset pack animations were full body, it threw me off.
- I don't thing the way I handled the interaction between the player and other objects was the best, but I was losing too much time trying to think on a better approach. One idea I had was to pass the PlayerObject as parameter to the handler functions, but since the game is single player, I chose to call its instance directly in the function.
- Despite I didn't had a previous experience with Rig2D, I figure out a way of adding bones to the sprites e make the animations. They weren't the best and had some bugs, but I believe they make do.

## List of used Asset Packs

- **GUI**
    - https://free-game-assets.itch.io/pixel-art-2d-game-ui
- **Sprites**
    - https://free-game-assets.itch.io/rpg-summer-tileset
    - https://free-game-assets.itch.io/seller-npc-character-sprites
    - https://free-game-assets.itch.io/wizard-4-direction-game-characters
    - https://free-game-assets.itch.io/archer-4-direction-characters
- **Icons**
    - https://free-game-assets.itch.io/farming-pixel-art-pack
    - https://free-game-assets.itch.io/40-pixel-art-icons-for-field-location
    - https://free-game-assets.itch.io/40-icons-for-crafting-pixel-art-pack
