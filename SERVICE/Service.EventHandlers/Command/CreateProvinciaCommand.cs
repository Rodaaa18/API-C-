using MediatR;
namespace Service.EventHandlers.Command
{
    public class CreateProvinciaCommand: INotification
    {
          
        public string Provincia { get; set; }

    }
}
