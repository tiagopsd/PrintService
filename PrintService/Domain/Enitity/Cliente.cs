using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Enitity
{
    public class Cliente : IEntidade
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
