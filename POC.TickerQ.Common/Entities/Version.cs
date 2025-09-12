using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.TickerQ.Common.Entities
{
    public class VersionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EffectiveFromDate { get; set; }
        public bool IsActive { get; set; }
    }
}
