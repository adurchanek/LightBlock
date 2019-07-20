
- ULTIMATE VFX (v3.2.0):

DOCUMENTATION: http://www.mirzabeig.com/products/ultimate-vfx/

Prefabs can be found under...

- "Mirza Beig/Particle Systems/Ultimate VFX/Prefabs/"

- "Mirza Beig/Particle Systems/Ultimate VFX/Expansions/XP - ACTION/Prefabs/"
- "Mirza Beig/Particle Systems/Ultimate VFX/Expansions/XP - STORM/Prefabs/"
- "Mirza Beig/Particle Systems/Ultimate VFX/Expansions/XP - SHOCKWAVES/Prefabs/"
- "Mirza Beig/Particle Systems/Ultimate VFX/Expansions/XP - TITLES/Prefabs/"
- "Mirza Beig/Particle Systems/Ultimate VFX/Expansions/XP - CONSTR. KIT/Prefabs/"

>> PLEASE MAKE SURE TO ENABLE THE PREFAB / GAMEOBJECT. 
>> SOME MAY BE DISABLED BY DEFAULT FOR THE DEMO.

Tools:

- Window -> Mirza Beig

Hidden controls:

- Holding left-clicking when in "oneshot" particle mode will continously spawn the current prefab.

XX -- CHANGE LOG -- XX

v3.5.1:

- Minor fix for missing materials on some of the realistic explosion prefabs.

v3.5.0:

- Added 180+ prefabs as part of a new expansion (VFX Construction Kit).

v3.2.0:

- Updated documentation to a live Google Doc (much easier to push updates).

- Added new prefabs for epic explosions using the newest realistic/cinematic textures.
- Added new prefabs for a sword weapon effect from the "Weapon Effect Electric-Spark Blood" tutorial I made.

- New awesome galaxy prefab using Unity 2018.1 features.

- Fixed a few shader category placements (now correctly under MirzaBeig/Particles/...").

- Removed experimental multi-threaded versions of force affectors.

- Updated Particle Plexus.

v3.1.0:

- Updated fire and explosion effects with sharper, higher resolution textures.
- Added some new prefabs for Action VFX using the new textures.

- Awesome new custom texture distortion and noise shader for particles (additive + alpha blended).

- New "Particle Force Field" asset now included.
- New "Particle Plexus" asset now included.

v3.0.0:

- Massive update!

- Several new textures and shaders for realistic/cinematic fire, smoke, fog, explosions, etc.
- Of course, there are also several new prefabs showing off how to use these new additions :)

v2.7.3:

- Fixed some more missing material issues (Titles XP).
- Added several new particle shader variations for animation blending and distance fade.

v2.7.2:

- Fixed missing material on several prefabs.
...
 -- This was caused by deletion of old distortion presets in v2.7.1.
 
 - Revamped some of the prefabs with the new distortion shader.
 - Specifying particles on a force affector will make it only apply to those systems even if attached to a particle system directly.
 
 - Updated expansion version numbers (because of new distortion shader and prefab updates).

v2.7.1:

- New snow textures.

- Massively improved distortion shader.

- Changed material naming convention.
- Fixed an error caused by incorrectly included external files.

v2.7.0:

- Beginning preperations for version 3.0 (yes, it will be a free update).
- A few more prefabs... of course :)

- Nicer looking demo scenes.
- Several new demos added (Gravity Clock, Comet Ocean, etc.).

- Updated to using Unity's new Post-Processing Stack.
...
-- Still using the old Global Fog because editor fog is really bad.
-- Profile is included! You can get the same look for demos just by having the asset in your project.

v2.6.5:

- New component: PARTICLE PLEXUS!
...
-- Refer to documentation for more details.

- Significant improvements to force affectors.
...
-- Performance (faster + no persistent GC allocations).
-- Several bugfixes due to simulation spaces and scale modes.

- Some more prefabs.

v2.6.2:

- Total of 300+ prefabs.
- Updated distortion shaders.

- Updated and added new trail textures.
- Updated snow sheet textures.

- Updated Particle Scaler for 5.5. New features!

- Cleaned/removed some textures.
- Updated material variations.

- Optimized original texture formats (64 bit -> 32 bit).

- Almost all prefabs can now be FULLY previewed in the editor (without hitting play).

- Fully Unity 5.5 compatible (non-beta!).

v2.6.0:

- Several prefabs added: total is now over 270!
- Fixed some more issues with the custom particle force affectors.

- Fully Unity 5.5 compatible (tested with beta versions).
- Updated scripts to remove/update deprecated particle code.

- Updated some textures for better performance (overdraw).
- Updated texture import settings for balancing quality and size/compression.

v2.5.1 (unreleased):

- Several new prefabs added to the XP Titles expansion pack.
- Some bug fixes with GLOBAL force affectors. Local force affectors are unaffected.

- Note that the new particle forces components in Ultimate VFX are NOT the same as the new modules in Unity 5.5. 
...
-- These will not be removed or deprecated since they offer new functionality that Unity/Shuriken doesn't have natively.

- The included Particle Lights component will be removed when Unity 5.5 is fully released (not beta!) since Shuriken will support particle lights natively in that version and onwards.

v2.5.0:

- Updated particle force manipulators for optimization.
...
-- Now featuring attraction, vortex, and turbulence!
-- Experimental GPU-powered variants added. 

- More prefabs - mostly showing off the new force affectors.

- Particle lights! 

v2.2.0:

- Added several material variations for quick fx building.
- And of course... more prefabs! Keep those suggestions going.

- Total prefab count now exceeds 220.

- Preparing release for new FREE expansion, "Titles XP".
...
-- Great for full-screen game menu, credits, title screens, etc.

- Preparing release for new FREE expansion, "Shockwave XP".
...
-- Great for epic sci-fi impacts.

- Some of the newer prefabs use Particle Playground. 
...
-- They can be used as-is, but can only be *fully* tweaked 
   if you have Particle Playground imported into your project.
   
-- These prefabs are marked by starting with the "pp-" prefix.
-- This is an experimental add-on, so only a few of the effects use PP.

- Added some experimental force manipulators for attraction and vortices.
...
-- These are not yet optimized, but still fun to play with.

- Added some much needed documentation under _DOCS.

v2.1.0:

- Folder architecture clean-up (based on user feedback).
...
-- All external files/assets removed.
-- All scripts are now local and in a single folder.

- Some more prefabs.
- Material naming scheme update to reflect varied soft particle settings.

v2.0.0:

- Finalized v2.0.0 upgrade from v1.8.0.
- Almost 200 prefabs, several demos, and two expansions added.
- XP Action, and XP Storm.

v1.8.0 (unreleased):

- "Beta" for v2.0!
- Biggest update yet...

- Folder design/architecture overhaul in preparation for expansion packs.

- Added a new interactive demo game, "Starfall".
- Added a new title screen demo scene for the demo game.
- Total of 135+ unique, high quality prefabs.
- Added a time scale controller to the interface.

v1.5.0:

- Another major update!
- Demo scene overhaul.
- Total of 125+ unique, high quality prefabs.
- Total of 180+ unique, high quality textures (up to 8192^2).
- Updated existing prefabs for distortion.
- Emphasis on expanding fire, water/liquid/blood/splatter effects.
- Added several custom particle shaders.
- Added standard and custom post-effects.

v1.2.0:

- Massive update :)
- Interface and code overhaul.
- +54 unique, high quality prefabs.
- Optimized and improved existing prefabs.
- Updated bonus asset Advanced Particle Scaler.
- Added bonus asset Particle Twister.

v1.1.0: 

- +20 spritesheets and textures.
- 14 new prefabs including fire, lasers, galaxy, storm, and leaves.
- Added multi-particle scaler (Advanced Particle Scaler).
- Changed texture import options for faster loading.
- Updated interface.

v1.0.0: 

- Initial release.
