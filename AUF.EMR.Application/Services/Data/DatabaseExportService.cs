using AUF.EMR.Application.Contracts.Services.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services.Data
{
    public class DatabaseExportService : IDatabaseExportService
    {
        private readonly string _connectionString;
        private readonly string _backupDirectory;

        public DatabaseExportService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _backupDirectory = configuration["BackupDirectory"];
        }

        public void ExportDatabase()
        {
            using var conn = new MySqlConnection(_connectionString);
            using var cmd = new MySqlCommand();
            using var mb = new MySqlBackup(cmd);

            var backupFileName = $"aufemrdb_{DateTime.Now:yyyyMMddHHmmss}.sql";
            var directory = Path.Combine(_backupDirectory, backupFileName);

            cmd.Connection = conn;
            conn.Open();
            mb.ExportToFile(directory);
            conn.Close();
        }
    }
}
