namespace Src.Infrastructure.ErrorSafeHelpers
{
    public interface IErrorSafeResponse
    {
        bool Succeed { get; }
    }

    public interface IErrorSafeResponse<out T>
    {
        bool Succeed { get; }
        T Value { get; }
    }

    public class ErrorSafeResponse : IErrorSafeResponse
    {
        public ErrorSafeResponse(bool succeed)
        {
            SucceedStatus = succeed;
        }

        public static IErrorSafeResponse Succeed()
        {
            return new ErrorSafeResponse(true);
        }
        public static IErrorSafeResponse Failed()
        {
            return new ErrorSafeResponse(false);
        }

        public static IErrorSafeResponse<T> Succeed<T>(T value)
        {
            return new ErrorSafeResponse<T>(true, value);
        }
        public static IErrorSafeResponse<T> Failed<T>()
        {
            return new ErrorSafeResponse<T>(true, default(T));
        }

        private bool SucceedStatus { get; }

        bool IErrorSafeResponse.Succeed => SucceedStatus;
    }

    public class ErrorSafeResponse<T> : IErrorSafeResponse<T>
    {
        internal ErrorSafeResponse(bool succeed, T value)
        {
            InnerSucceed = succeed;
            Value = value;
        }

        bool IErrorSafeResponse<T>.Succeed => InnerSucceed;
        public T Value { get; }
        private bool InnerSucceed { get; }
    }
}
