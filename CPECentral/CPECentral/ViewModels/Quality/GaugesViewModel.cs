using System.Collections.Generic;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels.Quality
{
    public class GaugesViewModel
    {
        public class Item
        {
            public int Id { get; set; }

            public string Reference { get; set; }

            public string Name { get; set; }

            public string GaugeType { get; set; }

            public Gauge Gauge { get; set; }
        }

        public List<Item> Items { get; } = new List<Item>();

        public void AddItem(Gauge gauge)
        {
            Items.Add(new Item
            {
                Id = gauge.Id,
                Name = gauge.Name,
                Reference = gauge.Reference,
                GaugeType = gauge.GaugeType.Name,
                Gauge = gauge
            });
        }
    }
}