﻿using Detached.Mappers.Samples.RestApi.Models;
using Detached.Mappers.Samples.RestApi.Models.Inputs;
using Detached.Mappers.Samples.RestApi.Models.Outputs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Detached.Mappers.EntityFramework;

namespace Detached.Mappers.Samples.RestApi.Stores
{
    public class InvoiceStore
    {
        readonly MainDbContext _context;

        public InvoiceStore(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceListItem>> GetAsync()
        {
            return await _context.Project<Invoice, InvoiceListItem>(_context.Invoices).ToListAsync();
        }

        public async Task SaveAsync(SaveInvoiceInput input)
        {
            await _context.MapAsync<Invoice>(input);
            await _context.SaveChangesAsync();
        }
    }
}