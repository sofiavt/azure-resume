namespace api.Function
{
    public interface IVisitorCounterService
    {
        Counter IncrementCounter(Counter counter);
    }

    public class VisitorCounterService : IVisitorCounterService
    {
        public Counter IncrementCounter(Counter counter)
        {
            if (counter == null)
            {
                throw new ArgumentNullException(nameof(counter));
            }

            counter.Count += 1;
            return counter;
        }
    }
}