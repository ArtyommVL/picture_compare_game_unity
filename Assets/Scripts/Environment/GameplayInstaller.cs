using CustomInput.CustomInputReceiver;
using CustomInput.CustomInputSender;
using CustomInput.CustomInputSender.Commands;
using Network.Receiver;
using Network.Sender;
using PlayerController.Mover;
using Zenject;

namespace Environment
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputService();
            UdpService();
            MoverService();
        }

        private void UdpService()
        {
            Container.BindInterfacesAndSelfTo<UdpClientSender>().AsSingle();
            Container.BindInterfacesAndSelfTo<UdpClientModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<UdpClientReceiver>().AsSingle();
            Container.BindInterfacesAndSelfTo<CustomInputReceiver>().AsSingle();
        }
    
        private void InputService()
        {
            Container.Bind<AttackCommand>()
                .ToSelf()
                .AsSingle();

            Container.Bind<BackCommand>()
                .ToSelf()
                .AsSingle();

            Container.Bind<LeftCommand>()
                .ToSelf()
                .AsSingle();

            Container.Bind<MoveForwardCommand>()
                .ToSelf()
                .AsSingle();

            Container.Bind<RightCommand>()
                .ToSelf()
                .AsSingle();
        
            Container.Bind<CustomInputHandler>()
                .FromMethod
                (context =>
                {
                    var attackCommand = context.Container.Resolve<AttackCommand>();
                    var backCommand = context.Container.Resolve<BackCommand>();
                    var leftCommand = context.Container.Resolve<LeftCommand>();
                    var moveForwardCommand = context.Container.Resolve<MoveForwardCommand>();
                    var rightCommand = context.Container.Resolve<RightCommand>();

                    var commands = new ICommand[]
                    {
                        attackCommand,
                        backCommand,
                        leftCommand,
                        moveForwardCommand,
                        rightCommand
                    };

                    return new CustomInputHandler(commands);
                });
        }


        private void MoverService()
        {
            Container.BindInterfacesAndSelfTo<MoveBack>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveForward>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveRight>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveLeft>().AsSingle();
        }
    }
}