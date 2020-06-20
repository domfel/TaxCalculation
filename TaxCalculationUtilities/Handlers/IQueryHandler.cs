namespace TaxCalculationUtilities.Handlers
{
    /// <summary>
    /// Interface for marking query handlers
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IQueryHandler<TIn, TOut>
    {
        TOut Execute(TIn query);
    }
}
