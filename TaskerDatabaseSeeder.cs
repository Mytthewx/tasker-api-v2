using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskerAPI.Models;

namespace TaskerAPI
{
    public class TaskerDatabaseSeeder
    {
        private readonly TaskerContext _context;

        public TaskerDatabaseSeeder(TaskerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Database.CanConnect())
            {
                return;
            }

            var pendingMigrations = _context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                _context.Database.Migrate();
            }
        }
    }
}
