using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class GravityServiceFake : UFake, IGravityService
    {
        public void Deregister (IPhysical entity) { evaluateMethod("Deregister", entity); }

        public void Flush () { evaluateMethod("Flush"); }

        public IPhysical[] Targets () { return evaluateMethod<IPhysical[]>("Targets"); }

        public void Register (IPhysical entity) { evaluateMethod("Register", entity); }
    }
}