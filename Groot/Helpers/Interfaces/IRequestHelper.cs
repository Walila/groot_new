using System.Threading.Tasks;

namespace Groot.Helpers.Interfaces;

public interface IRequestHelper
{
    Task Simulate(string url, object request = null);
    Task Post(string url, object request = null);
}