using Grid;

namespace PlayerController.Mover
{
    public interface IAbility
    {
        public void ApplyAbility(IInteractable interactableUnit,bool isAbilityState);
    }
}