using DotNet.DropCap.Helpers.Output;

namespace DotNet.DropCap.Output
{
    class Error : IOut
    {
        readonly ErrorOut _outHelper = new ErrorOut();
        public string Message { get; set; }

        public void Show()
        {
            _outHelper.Show(Message);
        }
    }
}
