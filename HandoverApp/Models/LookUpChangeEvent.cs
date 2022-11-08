using System;
namespace HandoverApp.Models
{
    public class LookUpChangeEvent : EventArgs
    {
        public object Item { get; set; }
    }
}
