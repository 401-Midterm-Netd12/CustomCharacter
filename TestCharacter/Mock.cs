using CustomCharacter.Data;
using CustomCharacter.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestCharacter
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly CustomCharacterContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            _db = new CustomCharacterContext(
                new DbContextOptionsBuilder<CustomCharacterContext>()
                .UseSqlite(_connection)
                .Options);
            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        
    }
}
