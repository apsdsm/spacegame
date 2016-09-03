using DataHelpers.Interfaces;

namespace SpaceGame.Validators
{
    public class WaveDataValidator : IValidator
    {
        public void Validate (ValidatorNode node, Validator validator)
        {
            // must have zero or more saucers
            if (node.AsInt32("Saucers") < 0) {
                validator.SetErrorMessage(node, "must have zero or more saucers");
            }
        }
    }
}