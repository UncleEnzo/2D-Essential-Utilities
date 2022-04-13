# 2D-Essential-Utilities

Hello!
Thank you for downloading the 2D Essential Utils package. I hope this package jumpstarts your
journey in 2D game development. The code for this package is heavily commented on, so this
document will act as a high level overview of the package features and why you want to use
them.

Features:

● Example Scene to demonstrate how the event system and Global Persistent Values can
be implemented

● An Event System that supports void and various parameter signatures

● Global Persistent Values stored outside of your scenes which can also be reset on scene
load

● Global Persistent Lists stored outside of your scenes, which can be reset on scene load

● Unity Utility methods that I commonly use in my 2D projects

● Unity Extension methods to make working with a 3D-oriented engine easier for 2D
developers

Event System:
The event system allows you to invoke Unity events without requiring a listener. This is useful
for decoupling code throughout the project and makes the project more modular. The event
system permits sending void events and events with data that the receivers can use in their
response.

Global Persistent Values And Lists:
Global Persistent Values and Lists allow you to store globally accessible data outside of your
scene and lets you access it without the need of In-game reference objects like game
managers. This helps by reducing the dependencies between game objects and global data
because a common issue with singletons and monosingleton patterns is that they form
dependency chains which lead to NPEs.
The Global Persistent values and lists are only referenced by the objects that need them, and
do not care if they are referenced between scenes. They also come with a handy Reset On
Scene Load feature that lets you reset them to preselected default values whenever a new
scene loads.
