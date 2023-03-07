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

1. [ ] Genre: Simulation
2. [ ] Top-down view
3. [ ] Player character that is able to walk and interact with the game world
4. [ ] Clothes Shop
    1. [ ] Talk to the shopkeeper
    2. [ ] Buying/selling items
    3. [ ] Item icons 
    4. [ ] Item prices
5. [ ] Outfits that are equipped should be visible on the character itself

After listing the requirements, I made a list of tasks that I should do before starting the code development.

### Tasks to be done

1. [ ] Get art assets for top-down view enviroment
2. [ ] Get player art assets
3. [ ] Get art assets for the cloth shop
    1. [ ] Figure out a way to fit all outfit related conditions
    2. [ ] Find art assets that fit what were planned

> Some questions about the game design were raised while writing this document, which will be answered later:
> - How the player will get the money to buy the clothes?
> - The player will get inside the shop (as the seeds shop in Stardew Valley)?
> - The game will have combat with animals?