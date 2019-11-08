using System;
using System.Collections.Generic;
using System.Text;

namespace app.Models
{
    class Track
    {
        public Uri TrackUri { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Rank { get; set; }
        public Uri ImageUri { get; set; }
    }
}
