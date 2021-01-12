# 2d Platformer
Based on the [Bolt - Platformer tutorial](https://learn.unity.com/project/bolt-platformer-tutorial) but with most of the "Flow Machines" written in C# instead :)

## Setup
Requires the [Bolt plugin](https://assetstore.unity.com/packages/tools/visual-scripting/bolt-163802).

## What I learned

Unfortunately the Bolt <> C# integration isn't as nice as I'd hoped, so I don't think I would go this route in a real project.

Problems:

1. Tedious to convert & forward Unity Messages or Events to Bolt's Custom Events and vice versa. Luckily it's just a (annoying) [one-liner for the former](https://docs.unity3d.com/bolt/1.4/manual/bolt-events.html#triggering), and Bolt supports calling C# script methods, which covers the latter. Except...
2. Have to "Build Unit Options" every single time you add a script method you want to call from Bolt
3. No way (as far as I can tell) to access the current state of a State Machine in script (so you end up duplicating state in C#, which is highly error prone).
4. Bolt is "stringly typed", which makes refactors harder and leaves room for typos.
  * Bolt's Variables are very powerful (and [easily accessible in C#](https://docs.unity3d.com/bolt/1.4/manual/bolt-variables-api.html)), requiring [Singletons](https://blog.mzikmund.com/2019/01/a-modern-singleton-in-unity/), PlayerPrefs, static classes, etc. to replicate in code. However, due to the above, I still prefer handling this stuff myself in C#.

## License
Tutorial assets licensed under the Unity Extension Asset license (basically, you have to [go download them yourself from the Asset Store](https://assetstore.unity.com/packages/essentials/tutorial-projects/bolt-kit-platformer-tutorial-assets-168067)).

My code licensed under the [MIT license](https://opensource.org/licenses/MIT).
