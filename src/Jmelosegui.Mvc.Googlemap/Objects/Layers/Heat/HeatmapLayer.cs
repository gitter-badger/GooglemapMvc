﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class HeatmapLayer : Layer, ILocationContainer
    {
        private readonly List<Location> data;

        public HeatmapLayer(Map map) : base("heatmap", map)
        {
            Gradient = new Collection<Color>();
            data = new List<Location>();
        }

        public ReadOnlyCollection<Location> Data
        {
            get
            {
                return new ReadOnlyCollection<Location>(data);
            }
        }

        public bool Dissipating { get; set; }

        public Collection<Color> Gradient { get; private set; }

        public int MaxIntensity { get; set; }

        [Range(0, 1)]
        public decimal Opacity { get; set; }

        public int Radius { get; set; }

        public override LayerSerializer CreateSerializer()
        {
            return new HeatmapLayerSerializer(this);
        }

        public void AddPoint(Location point)
        {
            if (point == null) throw new ArgumentNullException("point");
            data.Add(point);
        }

        internal void BindTo<TLocationContainer, TDataItem>(IEnumerable<TDataItem> dataSource, Action<LocationBindingFactory<TLocationContainer>> action) where TLocationContainer : class, ILocationContainer
        {
            if (action == null) throw new ArgumentNullException("action");
            if (dataSource == null) throw new ArgumentNullException("dataSource");

            var factory = new LocationBindingFactory<TLocationContainer>();

            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                factory.Binder.ItemDataBound(this as TLocationContainer, dataItem);
            }
        }

        
    }
}