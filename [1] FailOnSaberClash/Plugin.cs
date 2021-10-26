using FailOnSaberClash.Installers;
using IPA;
using SiraUtil.Zenject;

namespace FailOnSaberClash
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public Plugin(Zenjector zenjector)
        {
            // We will install it into the Standard Player (Solo and Party mode).
            // We don't want to touch campaigns, multiplayer, or the tutorial.
            zenjector.Install<FailPlayerInstaller>(Location.StandardPlayer);
        }
    }
}