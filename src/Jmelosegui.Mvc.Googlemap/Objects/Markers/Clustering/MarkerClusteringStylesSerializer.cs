﻿using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringStylesSerializer : ISerializer
    {
        private readonly MarkerClusteringStyles style;

        public MarkerClusteringStylesSerializer(MarkerClusteringStyles style)
        {
            this.style = style;
        }

        #region ISerializer Members

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            result["url"] = style.Url.AbsoluteUri;
            result["height"] = style.Height;
            result["width"] = style.Width;
            result["textSize"] = style.FontSize;
            result["textColor"] = style.FontColor.ToHtml();

            return result;
        }

        #endregion
    }
}