using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{

    private readonly LeaveRequestDBContext _context;
    private readonly DbSet<T> _dbSet;

    Repository(LeaveRequestDBContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Update(T entity) => _dbSet.Update(entity);
}
