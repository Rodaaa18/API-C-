using MediatR;


namespace Service.EventHandlers.Command
{
    public class CreateCentrodeCostoCommand : INotification
    {
        public string CentrodeCosto { get; set; }
        public string Obs { get; set; }
        public int Tipo { get; set; }
        public int codigobas { get; set; }
        public long idEstadoUnidad { get; set; }
    }
}
