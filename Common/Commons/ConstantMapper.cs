using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commons
{
    public class ConstantMapper
    {
        public static IMapper mapper = null;
        public IMapper GetMapper()
        {
            return mapper;
        }
    }
}
