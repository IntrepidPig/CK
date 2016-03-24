#House File Syntax
This program loads a .txt file, and parses it into the program. The file has a very specific, compact, format. Here's the example file (house.txt):
```
1.Porch:L1.1E
2.Entry Room:D1.011L2.0E
3.Living Room:W1.01W2.01W3.00W4.00L5.0L6.0E
4.Kitchen:W1.01W2.01L3.0L4.0E
5.Dining Room:W1.01L2.0L3.0E
6.Office:D1.000W2.01L3.0E
7.Hallway:L1.1E
8.Benny's Room:D1.100W2.01L3.0E
9.Bathroom:D1.001W2.01L3.0E
10.Parent's Room:D1.011W2.01W3.01L4.0L5.0L6.0E
11.Mateo's Room:D1.101W2.01W3.01L4.0E
12.Backyard:L1.0E
```

##House File Syntax Explained
You might be able to see a little of what's going on here. There are numbers in the beginning of each line, followed by a . and then the name of a room. The first number at the beginning of every line is the index of a room. (Note that using the same index for multiple rooms is untested and unsupported.) Immediately after the first ., the name of the room is typed. Then there's a :. After the : is the complex part. Everything after the : on a line are the components (lights, windows and doors) of that room. The syntax of a component is like this:
```
W3.01
```
The W means that this component is a window. Everything inbetween the type of component and the dot is the index of the component. Everything after that dot is the state of the component. In the case of windows, the first digit is the the open state of the window, and the second digit is whether the window can be opened. Data for components is treated like binary (0 is false, 1 is true). This window with the index of 3 is closed, but can be opened. The line for components doesn't have any spaces between the components.

The current types of components are:

Door (D)

Window (W)

Light (L)

You MUST put and E at the end of each line.
####Doors
Door's can be opened, locked, and can be lockable. A door that isn't lockable can't be locked.
For example
```
D1.101
```
would create a door with the index of one that is open, unlocked, and lockable. It is convention for the index of doors to be one since rooms can only have one.
####Windows
Window's can be opened and openable.
For example
```
W3.00
```
would create a window with the index of four that is closed and can't be opened. Any room can have as many windows as it wants.
####Lights
Lights can be turned on and off
For example
```
L2.1
```
would create a light with the index of two that is off

####An entire room
Here's an example of an entire room (a garage) with each of the components we just made.
```
4.Garage:D1.101W3.00L2.1E
```
This would show up in the program as:
```
[4] Garage:
        [2] Light: On
        [3] Window: Closed
        [1] Door: Open, Unlocked
```
