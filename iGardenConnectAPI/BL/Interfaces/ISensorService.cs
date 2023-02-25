using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ISensorService
    {
        public IEnumerable<SensorDTO> Get();
        public SensorDTO Get(int id);

        public bool Add(SensorDTO dto);

        public bool Update(SensorDTO dto);
        public bool Remove(SensorDTO dto);



    }

}
