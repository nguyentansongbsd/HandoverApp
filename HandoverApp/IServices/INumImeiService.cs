using System;
using System.Threading.Tasks;

namespace HandoverApp.IServices
{
    public interface INumImeiService
    {
        Task<string> GetImei();
    }
}
