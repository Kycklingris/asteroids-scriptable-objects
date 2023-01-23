# asteroids-scriptable-objects
As a mainly solo programmer, the use of scriptable objects isn't exactly revolutionary considering that the end result is 
essentially the same as using a static and public class to store the data.

But, I can easily see why using scriptable objects is incredibly useful, mainly because of collaboration, both between programmers and non programmers.
For collaboration between programmers, to make sure that everyone can easily understand the architecture of the code already present, and just as easily expand without breaking anything, 
you need to either follow a strict project specific guideline that is well documented, or use the guidelines and best practices already established in the language or engine that is being used.
In this case, using scriptable objects over a static c# class is one such way to at least largely lessen the amount of explanation needed for a new programmer to begin work.
Using scriptable objects also makes sure that the methods inherited from parent classes are present as another programmer might expect.

For non programmers it is helpful to have a easily usable GUI for both simple programming esque tasks such as adding health to a new type of enemy, 
as well as making editing of values simple to do without the help of programming knowledge. Making it possible for a progammer to set the limits of what can be changed within the correct parameters.
These things can also be helpful for a programmer but it usually isn't a problem if it needs to be done through code, especially considering the speed of iteration when making small balance adjustments,
as unity doesn't need to recompile/reload between each and every change.

The custom editor, while useful, is usually not needed at least in the scope of such a small game as the asteroids game, it can however amplify all the good parts previously mentioned, 
but it can also make it much worse if not well implemented, and often times just having [SerializeField] on a scriptable object will be a very similar and less buggy experience.
It is of course very important for say, a level editor or similar larger scale tools.

With all that said, in this small game, it probably would have been enough to just have [SerializeField] in the scripts and to edit the values in the inspector while selecting the right game object, 
and while it may have slowed down development a tiny bit, just having the habit of following best practices/guidelines is way more important.

## VG Points:
- Utilize advanced features of Unity editor tools, such as custom... This should be easy to find in Assets/_Game/Scripts/Editor/SpaceEditor.cs particularly with the minmaxsliders + value fields (although I would have liked to make them their own custom VisualElement, I didn't have time)
- Reflect on the process... above
- Create a well-organized and easy-to-use... Window -> UIToolkit -> SpaceEditor
- Incorporate error handling, undo/redo functi... (Unsure about) undo and redo does seem to work, but just from not doing anything extreme, it wasn't added manually for anything and it shouldn't give any errors.

otherwise, the scriptable object instances are placed in Assets/_Game/Components/(Asteroid/Ship) and everything new (not just changed to work with SOs) in Assets/_Game/Scripts/Editor
