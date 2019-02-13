using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebServideAccesDonneesHub
{
    public class AsyncLock : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Verrouille une portion de code de façon asynchrone
        /// </summary>
        /// <returns>L'objet qui libèrera le verrou à l'appel de la méthode Dispose()</returns>
        public async Task<IDisposable> LockAsync()
        {
            await _semaphoreSlim.WaitAsync();
            return this;
        }

        /// <summary>
        /// Verrouille une portion de code de façon Synchrone
        /// </summary>
        /// <returns>L'objet qui libèrera le verrou à l'appel de la méthode Dispose()</returns>
        public IDisposable Lock()
        {
            _semaphoreSlim.Wait();
            return this;
        }

        /// <summary>
        /// Libère le verrou
        /// </summary>
        public void Dispose()
        {
            _semaphoreSlim.Release();
        }
    }
}
