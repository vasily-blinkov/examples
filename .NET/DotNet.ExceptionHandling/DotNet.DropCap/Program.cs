using System;
using System.Collections.Generic;
using DotNet.DropCap.Core.Abstractions;
using DotNet.DropCap.Core.Exceptions;
using DotNet.DropCap.Core.Implementations;
using DotNet.DropCap.Exceptions;
using DotNet.DropCap.Helpers;
using DotNet.DropCap.Helpers.Output;
using DotNet.DropCap.Output;

namespace DotNet.DropCap
{
    class Program
    {
        static readonly Manual _manual = new Manual();
        static readonly StringsFiller _filler = new StringsFiller();
        static readonly ICapDropper _dropper = new CapDropper();
        static readonly Result _output = new Result();
        static readonly Error _error = new Error();

        static void Main()
        {
            ShowManual();
            var strings = FillStrings();

            string result = null;
            bool ok = true;

            try
            {
                result = DropCaps(strings);
            }
            catch (OperationFailedException ex)
            {
                ShowError(ex.Message);
                ok = false;
            }

            if (ok)
                ShowResult(result);
        }

        static void ShowManual()
        {
            ShowOutput(_manual);
        }

        static IEnumerable<string> FillStrings()
        {
            _filler.Reset();
            return _filler.Fill();
        }

        /// <exception cref="OperationFailedException" />
        static string DropCaps(IEnumerable<string> strings)
        {
            try
            {
                return _dropper.DropCaps(strings);
            }
            catch (EmptyStringException ex)
            {
                throw new OperationFailedException(ex.Message, ex);
            }
        }

        static void ShowResult(string result)
        {
            _output.String = result;

            ShowOutput(_output);
        }

        static void ShowError(string message)
        {
            _error.Message = message;

            ShowOutput(_error);
        }

        static void ShowOutput(IOut output)
        {
            output.Show();
        }
    }
}
