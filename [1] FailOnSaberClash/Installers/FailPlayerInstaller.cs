using FailOnSaberClash.Managers;
using Zenject;

namespace FailOnSaberClash.Installers
{
    // This is our installer. It is one of the ways we can communicate to Zenject what to run and how to instantiate our classes.
    internal class FailPlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            // We are registering our manager class so it can work when the player is in a level. Let's break down what's happening here.

            // Container                          | We access the current container. This is defined in one of the base classes that Installer inherits.
            // BindInterfacesTo<ClashFailManager> | We tell the container to bind the type (ClashFailManager)'s interfaces (ITickable) to the container.
            //                                      Zenject now knows that it's an ITickable and will call it's Tick method, allowing us to run code every frame.
            // AsSingle()                         | This registers it as a single instance inside this container. Meaning, you can ensure that only one of this object will exist at a time.

            Container.BindInterfacesTo<ClashFailManager>().AsSingle();
        }
    }
}