# House Controller
Here's a program I wrote. It's nothing to do with networking, but I love it all the same. Basically, it has all the info about my house. There are rooms with doors, lights, and windows. Every objects has a state, that is printed to the console everytime something is changed. This is what the console looks like:

```
[1] Porch:
        [1] Light: On

[2] Entry Room:
        [2] Light: Off
        [1] Door: Closed, Locked

[3] Living Room:
        [5] Light: Off
        [6] Light: Off
        [1] Window: Closed
        [2] Window: Closed
        [3] Window: Closed
        [4] Window: Closed

[4] Kitchen:
        [3] Light: Off
        [4] Light: Off
        [1] Window: Closed
        [2] Window: Closed

[5] Dining Room:
        [2] Light: Off
        [3] Light: Off
        [1] Window: Closed

[6] Office:
        [3] Light: Off
        [2] Window: Closed
        [1] Door: Closed, Unlocked

[7] Hallway:
        [1] Light: On

[8] Benny's Room:
        [3] Light: Off
        [2] Window: Closed
        [1] Door: Open, Unlocked

[9] Bathroom:
        [3] Light: Off
        [2] Window: Closed
        [1] Door: Closed, Unlocked

[10] Parent's Room:
        [4] Light: Off
        [5] Light: Off
        [6] Light: Off
        [2] Window: Closed
        [3] Window: Closed
        [1] Door: Closed, Locked

[11] Mateo's Room:
        [4] Light: Off
        [2] Window: Closed
        [3] Window: Closed
        [1] Door: Open, Unlocked

[12] Backyard:
        [1] Light: On


lighttoggle 12.1
```

I have typed in `lighttoggle 12.1`. I have yet to press enter to execute the command and turn the backyard light off.

#Saving Data
As of yet, there is now way to save the house state and open it like that next time. That is next on my to-do list. There is, however, a funtion to load a house state. You can read about house files in HouseFileSyntax.md.
