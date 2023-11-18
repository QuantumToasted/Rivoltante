namespace Rivoltante.Core;

public static class SemaphoreExtensions
{
    public static async ValueTask<SemaphoreDisposable> EnterAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
    {
        await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        return new SemaphoreDisposable(semaphore);
    }
    
    public sealed class SemaphoreDisposable(SemaphoreSlim semaphore) : IDisposable
    {
        public void Dispose()
            => semaphore.Release();
    }
}