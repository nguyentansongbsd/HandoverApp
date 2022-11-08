using System;
using System.Threading.Tasks;

namespace HandoverApp.IServices
{
    public interface IPdfService
    {
        Task View(string url, string name);
    }
}
