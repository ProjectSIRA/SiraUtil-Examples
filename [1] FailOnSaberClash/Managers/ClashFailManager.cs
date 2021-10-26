using System;
using UnityEngine;
using Zenject;

namespace FailOnSaberClash.Managers
{
    // We inherit ITickable so we can process stuff each frame. This is very similar to the player loop Update()
    // method in Unity, and they should be treated similarly.
    internal class ClashFailManager : ITickable
    {
        private readonly SaberClashChecker _saberClashChecker;
        private readonly StandardLevelGameplayManager _standardLevelGameplayManager;

        // The SaberClashChecker is a class the base game uses to... well... detect saber clashes. By putting it in the constructor
        // of this class, we are saying that this class has a dependency on the SaberClashChecker. Zenject recognizes this and when instantiating
        // our class, will fill all the dependencies in the constructor. To get a list of dependencies from the base game that you can use, go to https://container.project-sira.tech
        //
        // The same logic above can be applied to the StandardLevelGameplayManager
        public ClashFailManager(SaberClashChecker saberClashChecker, StandardLevelGameplayManager standardLevelGameplayManager)
        {
            // We store the SaberClashChecker and StandardLevelGameplayManager in their own private variable within our class so we can use them elsewhere.
            _saberClashChecker = saberClashChecker;
            _standardLevelGameplayManager = standardLevelGameplayManager;
        }

        // This method gets called every frame. Similar to Update(), you shouldn't do expensive operations inside of this method.
        public void Tick()
        {
            // This is where we check to see if the sabers are clashing. The base game uses this method to calculate where
            // to spawn the sparkle effects. We can ALSO use it to fail the level when they class.
            if (_saberClashChecker.AreSabersClashing(out Vector3 _))
            {
                // We want to emulate what happens when you fail a level, so
                // we call a method which triggers the level failed sequence.
                _standardLevelGameplayManager.HandleGameEnergyDidReach0();
            }
        }
    }
}