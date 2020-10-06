using DotNet.DropCap.Helpers.Output;

namespace DotNet.DropCap.Output
{
    public class Result : IOut
    {
        readonly NormalOut _outHelper = new NormalOut();
        public string String { get; set; }

        public void Show()
        {
            _outHelper.Show(String);
        }
    }
}
