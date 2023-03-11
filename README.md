# Blue Gravity Interview Summary
Applicant: Iuri de Souza Severo Alves

## System

The game has two core mechanics: the buy/sell mechanic and the change outfit mechanic. It starts in-game, and you can move around freely using the W, A, S, D keys or arrow keys. Press 'E' to interact with objects, 'I' to open the inventory, and 'ESC' to open the menu.

There are four interactive objects and a seller: trees, bushes, rocks, and clusters of rocks. Each of these objects stores items that can be obtained by the player through interaction, including berries, hazelnuts, emeralds, diamonds, and logs. Each item can be sold for a price, and the earned money can be used to buy outfits from the seller. In the inventory, players can change their clothes.

## Thoughts

During development, my biggest concern was the clothing change mechanic, due to the art asset packages I had separated. They only had full body animations, which made it seem like swapping clothes by body part would be unfeasible. After researching extensively, I found a way to implement this mechanic using skeleton animations, but this required me to create new sprites from the art assets, add the skeleton to them, and create new animations. In the end, I was able to make it work, but there were some bugs due to the way the skeleton was assembled. If the skeleton animation approach didn't work, my backup plan was to switch the entire body outfit using the "Animator Override Controller".
    
The development of some other mechanics took longer than expected, such as the item selling mechanic. The way I organized the scripts made it difficult for the selected item in the interface to communicate with the controller that performed the sale, but this problem was solved by delegating a function that retrieved a reference to the selected item for the item selection button.

Finally, I believe I did well in the development of this game. Despite not having prior experience with Rig2D and the limited time, I was able to learn and apply it in an acceptable way, despite the bugs that remained in the project. Moreover, I was satisfied with the development of the other mechanics of the game and I really liked the result I achieved with the store interface.


## Attributions

* <a href="https://www.flaticon.com/free-icons/tshirt" title="tshirt icons">Tshirt icons created by Good Ware - Flaticon</a>
* <a href="https://www.flaticon.com/free-icons/fruit" title="fruit icons">Fruit icons created by Freepik - Flaticon</a>
* <a href="https://www.flaticon.com/free-icons/gem" title="gem icons">Gem icons created by deemakdaksina - Flaticon</a>
* <a href="https://www.flaticon.com/free-icons/wood" title="wood icons">Wood icons created by narak0rn - Flaticon</a>