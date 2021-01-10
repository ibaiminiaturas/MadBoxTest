# MadBoxTest

-The time it took you to perform the exercise:

5 hours. I spent all the time trying to add new features, cleaning code and looking for assets etc.

-The parts that were difficult for you and why

The most difficult part it's been doing something playable in the time given. What I mean is that the difficult part it's been finding the balance between trying to do good clean code but also finish the level and try to get cool 
assets on it. For sure everything could be done better but the balance is important

-The parts you think you could do better and how

I wuold have divided the player way more. An input controller, a movement controller etc. This way there would not be a "player". There would be a "runner" and it would get the commands from input or from a AI or even from the internet in multiplayer mode.
So we could instantiate N number of runners and the game would not break, It would scalate perfectly. But didnt have the time :-(

Alse the route generator. I would have used nice splines so we could make nice curves etc. The track chunks would have the anchors on them so It wouldn't be a terrible list with transforms. 

The camera control. Right now is quite dull. I had already in mind that when reaching a checkpoint an event with an offset and rotation would be sent to the listeners. And the camera would be listening so it would update the offset and rotation
The values would be simple monobehaviours attached to the checkpoints. This is not the best way at all, but 5 hours is not enough to do it perfect :-)

The UI is always a pain and I left it for the end. So I would calculate better the distance travelled by the player and how much of the total distance this is and the I would update the minimap player face acordingly

I would have loved to do the physics better, but that is a lot of tweaking until you hit the sweetspot were feels nice and fun but also powerfull and impactfull. Like fall guys for example.

-What you would do if you could go a step further on this game

First off all make a good level design system. Where a designer can "paint" in the editor the race-track and add obstacles in an easy way. That would give space for fast design iteration. 
All this would be stored in data mode. No a whole scene with all the prefabs etc. That is the tool. When the designer is ready he can export the data to a JSON. And the game reads the JSON and spawns everything at the correct place etc.
This makes much managable the project and the updates and could even serve levels from a backend with no update needed.

Second is of course going multiplayer. Or at least play against a bot. Competition is always fun and users can love it. A very simple AI system could be done and the runners go on "rails" so is quite easy to implement. 

Third would be add the social layer. Some leaderboards etc. Not too much, it can be really annoying when is too much. But just sending your best time of the track and see where are you positioned. Could be really cool.

-Any comment you may have

It's been an interesting test. Usually as a developer we just do code and many times the test are even not "Unity3D". It's been quite fun going against the clock to search for sprites, a character, change the animator, look for obstacles etc.
I totally understand the point. As I said before finding the balance between "good code" and "working code + more features" is really important. Over Engineering can be very very dangerous.

Thank you so much and I hope you like my test
