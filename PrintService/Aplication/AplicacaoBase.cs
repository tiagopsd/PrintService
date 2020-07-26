using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintService.Aplication
{
    public class AplicacaoBase
    {
        protected IContext _context;
        protected IRepository _repository;
        protected IEnumerable<IImpressao> _impressoes;
        protected readonly ILogger<Worker> _logger;

        public AplicacaoBase(IRepository repository,
            IEnumerable<IImpressao> impressoes,
            IContext context,
            ILogger<Worker> logger)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
            _impressoes = impressoes;
        }
    }
}
