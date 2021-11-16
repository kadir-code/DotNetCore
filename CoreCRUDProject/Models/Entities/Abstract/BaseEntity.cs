using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUDProject.Models.Entities.Abstract
{
    public enum Status { Active = 1, Modified = 2, Passive = 3 }

    public class BaseEntity
    {
        public int Id { get; set; }

        DateTime _createTime = DateTime.Now;
        public DateTime CreateDate { get => _createTime; set => _createTime = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

    }
}
