using BlogApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }


        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
