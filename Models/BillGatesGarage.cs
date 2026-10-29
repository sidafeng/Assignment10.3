using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Assignment10._3.Models
{
    public class BillGatesGarage
    {
        [Key]
        public int GarageID { get; set; }
        public string Location { get; set; }

        public virtual ObservableCollectionListSource<Car> Cars { get; set; }

        public override string ToString()
        {
            return Location;
        }


    }
}
