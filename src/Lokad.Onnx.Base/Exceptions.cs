namespace Lokad.Onnx
{
    public class RuntimeNotInitializedException : Exception
    {
        public RuntimeNotInitializedException(Runtime o) : base($"This runtime object is not initialized.") { }
    }
}


