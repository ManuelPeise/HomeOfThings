using Database.HotContext;

namespace Logic.Shared.UnitsOfWork
{
    public abstract class AUnitOfWork: IDisposable
    {
        private readonly DatabaseContext _context;
        private bool disposedValue;

        public DatabaseContext DatabaseContext => _context;

        public AUnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
