using DotNet.DropCap.Core.Resources;
using DotNet.DropCap.Output;

namespace DotNet.DropCap.Helpers.Output
{
    sealed class Manual : IOut
    {
        private readonly NormalOut _outHelper = new NormalOut();

        public void Show()
        {
            _outHelper.Show(Help.AddString);
            _outHelper.Show(Help.FinishAdding);
        }
    }
}
