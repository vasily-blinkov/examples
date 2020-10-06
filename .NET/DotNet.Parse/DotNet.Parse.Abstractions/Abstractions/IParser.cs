namespace DotNet.Parse.Core.Abstractions
{
    public interface IParser<TResult> where TResult : struct
    {
        TResult Parse(string image);
    }
}
