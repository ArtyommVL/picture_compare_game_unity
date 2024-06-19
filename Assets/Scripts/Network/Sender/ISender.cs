using System.Threading.Tasks;

namespace Network.Sender
{
    public interface ISender
    {
        Task Send();
    }
}