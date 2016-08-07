using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class GravityServiceFake : UFake, IGravityService
    {
        public void Deregister (IPhysical entity) 
        {
            Evaluate(Call("Deregister").With(entity)); 
        }

        public void Flush () 
        {
            Evaluate(Call("Flush")); 
        }

        public IPhysical[] Targets () 
        { 
            return Evaluate<IPhysical[]>(Call("Targets")); 
        }

        public void Register (IPhysical entity) 
        {
            Evaluate(Call("Register").With(entity)); 
        }
    }
}