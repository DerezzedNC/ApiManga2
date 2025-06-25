<<<<<<< HEAD
using JaveragesLibrary.Data;
using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
=======
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 28483a396664b67121d3da7309679797e356df48

namespace JaveragesLibrary.Services.Features.Prestamos
{
    public class PrestamoService
    {
        private readonly MangaDbContext _context;

        public PrestamoService(MangaDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Prestamo>> GetAllPrestamosAsync()
        {
            return await _context.Prestamos.ToListAsync();
        }

        public async Task<Prestamo?> GetPrestamoByIdAsync(int id)
=======
        public async Task<Prestamo?> GetByIdAsync(int id)
>>>>>>> 28483a396664b67121d3da7309679797e356df48
        {
            return await _context.Prestamos.FindAsync(id);
        }

<<<<<<< HEAD
        public async Task<Prestamo> CreatePrestamoAsync(Prestamo prestamo)
        {
=======
        public async Task<Prestamo> AddAsync(Prestamo prestamo)
        {
            // Validar que el MangaId exista
            var manga = await _context.Mangas.FindAsync(prestamo.MangaId);
            if (manga == null)
                throw new ArgumentException("El MangaId proporcionado no existe.");

            // Validar que el NombreCliente no esté vacío
            if (string.IsNullOrWhiteSpace(prestamo.NombreCliente))
                throw new ArgumentException("El NombreCliente no puede estar vacío.");

>>>>>>> 28483a396664b67121d3da7309679797e356df48
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

<<<<<<< HEAD
        public async Task UpdatePrestamoAsync(Prestamo prestamo)
        {
            _context.Entry(prestamo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrestamoAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Prestamo>> SearchPrestamosByClienteAsync(string nombreCliente)
        {
            return await _context.Prestamos
                .Where(p => p.NombreCliente.Contains(nombreCliente))
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosByMangaIdAsync(int mangaId)
        {
            return await _context.Prestamos
                .Where(p => p.MangaId == mangaId)
                .ToListAsync();
        }

        public async Task<bool> PrestamoExistsAsync(int id)
        {
            return await _context.Prestamos.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamosByDateRangeAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Prestamos
                .Where(p => p.FechaPrestamo >= fechaInicio && p.FechaPrestamo <= fechaFin)
=======
        public async Task<Prestamo?> UpdateAsync(int id, Prestamo prestamo)
        {
            var existing = await _context.Prestamos.FindAsync(id);
            if (existing == null)
                return null;

            existing.NombreCliente = prestamo.NombreCliente;
            existing.MangaId = prestamo.MangaId;
            existing.FechaPrestamo = prestamo.FechaPrestamo;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
                return false;

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Prestamo>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await _context.Prestamos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
>>>>>>> 28483a396664b67121d3da7309679797e356df48
                .ToListAsync();
        }
    }
}